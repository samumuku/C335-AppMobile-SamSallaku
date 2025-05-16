using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashQuizz.Models;
using FlashQuizz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashQuizz.ViewModels
{
    public partial class DeckPageViewModel : ObservableObject
    {
        public readonly Deck _deck;

        public DeckPageViewModel(Deck deck)
        {
            _deck = deck;
        }

        [ObservableProperty]
        private string question;

        [ObservableProperty]
        private string answer;

        [RelayCommand]
        public async Task AddFlashcard()
        {
            if (string.IsNullOrWhiteSpace(Question) || string.IsNullOrWhiteSpace(Answer))
            {
                await App.Current.MainPage.DisplayAlert("Validation", "Both question and answer are required", "OK");
                return;
            }

            var flashcard = new Flashcard
            {
                Question = Question,
                Answer = Answer,
                DeckId = _deck.Id
            };

            using var db = new FlashquizzContext();
            try
            {
                db.Add(flashcard);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Database Error", ex.InnerException?.Message ?? ex.Message, "OK");
            }

            // Clear inputs after adding the flashcard
            Question = "";
            Answer = "";
        }
    }
}
