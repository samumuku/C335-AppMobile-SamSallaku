using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashQuizz.Models;
using FlashQuizz.Services;
using System.Threading.Tasks;

namespace FlashQuizz.ViewModels
{
    public partial class FlashcardViewModel : ObservableObject
    {
        private readonly Deck _deck;

        [ObservableProperty]
        private string question;

        [ObservableProperty]
        private string answer;

        public FlashcardViewModel(Deck deck)
        {
            _deck = deck;
        }

        [RelayCommand]
        private async Task AddFlashcard()
        {
            if (string.IsNullOrWhiteSpace(Question) || string.IsNullOrWhiteSpace(Answer))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Question and Answer are required.", "OK");
                return;
            }

            var flashcard = new Flashcard
            {
                Question = Question,
                Answer = Answer,
                DeckId = _deck.Id
            };

            using var db = new FlashquizzContext();
            db.Flashcards.Add(flashcard);
            await db.SaveChangesAsync();

            await App.Current.MainPage.DisplayAlert("Success", "Flashcard added!", "OK");
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
