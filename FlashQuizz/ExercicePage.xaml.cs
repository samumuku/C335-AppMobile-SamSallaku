using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FlashQuizz.Models;

namespace FlashQuizz.Views
{
    public partial class ExercisePage : ContentPage
    {
        private List<Flashcard> _originalFlashcards;
        private List<FlashcardStats> _flashcardStats;
        private Queue<Flashcard> _flashcardQueue;
        private Flashcard _currentFlashcard;
        private Stopwatch _stopwatch;
        private bool _showingQuestion = true;
        private bool _isShakeProcessing = false;

        public ExercisePage(List<Flashcard> flashcards)
        {
            InitializeComponent();

            _originalFlashcards = flashcards.OrderBy(f => Guid.NewGuid()).ToList();
            _flashcardStats = _originalFlashcards.Select(f => new FlashcardStats(f)).ToList();
            _flashcardQueue = new Queue<Flashcard>(_originalFlashcards);

            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            DisplayNextFlashcard();

            Accelerometer.ShakeDetected += OnShakeDetected;
            Accelerometer.Start(SensorSpeed.Game);
        }

        private void DisplayNextFlashcard()
        {
            if (_flashcardQueue.Count == 0)
            {
                _stopwatch.Stop();
                ShowResultsPage();
                return;
            }

            _currentFlashcard = _flashcardQueue.Dequeue();
            _showingQuestion = true;
            FlashcardLabel.Text = _currentFlashcard.Question;
            FlashcardFrame.RotationY = 0; // reset rotation if needed
        }

        private async void OnFlashcardTapped(object sender, EventArgs e)
        {
            await FlashcardFrame.RotateYTo(90, 300);

            FlashcardLabel.Text = _showingQuestion ? _currentFlashcard.Answer : _currentFlashcard.Question;

            _showingQuestion = !_showingQuestion;

            await FlashcardFrame.RotateYTo(0, 300);
        }

        private void OnCorrectClicked(object sender, EventArgs e)
        {
            // Mark current card correct in stats
            var stat = _flashcardStats.First(s => s.Flashcard.Id == _currentFlashcard.Id);
            stat.CorrectAttempts++;

            DisplayNextFlashcard();
        }

        private async void OnShakeDetected(object sender, EventArgs e)
        {
            if (_isShakeProcessing) return; // Ignore shakes while processing

            _isShakeProcessing = true;

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                var stat = _flashcardStats.First(s => s.Flashcard.Id == _currentFlashcard.Id);
                stat.IncorrectAttempts++;

                _flashcardQueue.Enqueue(_currentFlashcard);

                DisplayNextFlashcard();

                // Wait before allowing another shake
                await Task.Delay(2000);

                _isShakeProcessing = false;
            });
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Accelerometer.ShakeDetected -= OnShakeDetected;
            Accelerometer.Stop();
        }

        private async void ShowResultsPage()
        {
            // Prepare stats
            var totalCards = _flashcardStats.Count;
            var correctCards = _flashcardStats.Count(s => s.IncorrectAttempts == 0);
            var successRate = (double)correctCards / totalCards * 100;

            var hardestCard = _flashcardStats.OrderByDescending(s => s.IncorrectAttempts).FirstOrDefault()?.Flashcard;

            var results = new ExerciseResults
            {
                TimeTaken = _stopwatch.Elapsed,
                HardestCardQuestion = hardestCard?.Question ?? "N/A",
                HardestCardErrors = _flashcardStats.Max(s => s.IncorrectAttempts),
                CorrectCardsCount = correctCards,
                TotalCards = totalCards,
                SuccessRate = successRate
            };

            await Navigation.PushAsync(new ExerciseResultsPage(results));
        }
    }

    public class FlashcardStats
    {
        public Flashcard Flashcard { get; }
        public int CorrectAttempts { get; set; } = 0;
        public int IncorrectAttempts { get; set; } = 0;

        public FlashcardStats(Flashcard flashcard)
        {
            Flashcard = flashcard;
        }
    }

    public class ExerciseResults
    {
        public TimeSpan TimeTaken { get; set; }
        public string HardestCardQuestion { get; set; }
        public int HardestCardErrors { get; set; }
        public int CorrectCardsCount { get; set; }
        public int TotalCards { get; set; }
        public double SuccessRate { get; set; }
    }
}
