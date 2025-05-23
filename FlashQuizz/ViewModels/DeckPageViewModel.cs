using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashQuizz.Models;
using FlashQuizz.Services;
using FlashQuizz.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlashQuizz.ViewModels
{
    public partial class DeckPageViewModel : ObservableObject
    {
        public readonly Deck _deck;

        public DeckPageViewModel(Deck deck)
        {
            _deck = deck;
            Flashcards = new ObservableCollection<Flashcard>(_deck.Flashcards ?? new List<Flashcard>());
        }

        public string DeckName => _deck.Name;

        public ObservableCollection<Flashcard> Flashcards { get; set; }

        [RelayCommand]
        private async Task EditDeck()
        {
            await App.Current.MainPage.DisplayAlert("Edit", "Edit Deck clicked", "OK");
        }

        [RelayCommand]
        private async Task DeleteDeck()
        {
            bool confirm = await App.Current.MainPage.DisplayAlert("Confirm", "Delete this deck?", "Yes", "No");
            if (!confirm) return;

            using var db = new FlashquizzContext();
            db.Decks.Remove(_deck);
            await db.SaveChangesAsync();

            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task ReloadFlashcardsAsync()
        {
            using var db = new FlashquizzContext();
            var freshDeck = await db.Decks
                .Include(d => d.Flashcards)
                .FirstOrDefaultAsync(d => d.Id == _deck.Id);

            if (freshDeck != null)
            {
                Flashcards.Clear();
                foreach (var flashcard in freshDeck.Flashcards)
                {
                    Flashcards.Add(flashcard);
                }
            }
        }

        [RelayCommand]
        private async Task StartExercise()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ExercisePage(Flashcards.ToList()));
        }

        [RelayCommand]
        private async Task DeleteFlashcard(Flashcard flashcard)
        {
            bool confirm = await App.Current.MainPage.DisplayAlert("Confirm", $"Delete flashcard '{flashcard.Question}'?", "Yes", "No");
            if (!confirm) return;

            using var db = new FlashquizzContext();
            db.Flashcards.Remove(flashcard);
            await db.SaveChangesAsync();

            Flashcards.Remove(flashcard);
        }

        [RelayCommand]
        private async Task EditFlashcard(Flashcard flashcard)
        {
            string newQuestion = await App.Current.MainPage.DisplayPromptAsync("Edit Question", "Update question:", initialValue: flashcard.Question);
            if (newQuestion == null) return;

            string newAnswer = await App.Current.MainPage.DisplayPromptAsync("Edit Answer", "Update answer:", initialValue: flashcard.Answer);
            if (newAnswer == null) return;

            flashcard.Question = newQuestion;
            flashcard.Answer = newAnswer;

            using var db = new FlashquizzContext();
            db.Flashcards.Update(flashcard);
            await db.SaveChangesAsync();

            // Refresh UI
            int index = Flashcards.IndexOf(flashcard);
            Flashcards.RemoveAt(index);
            Flashcards.Insert(index, flashcard);
        }

    }
}
