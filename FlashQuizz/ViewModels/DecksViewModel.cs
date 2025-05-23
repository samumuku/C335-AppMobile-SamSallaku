using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashQuizz.Models;
using FlashQuizz.Services;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FlashQuizz.Views;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashQuizz.ViewModels
{
    public partial class DecksViewModel : ObservableObject
    {
        public ObservableCollection<Deck> Decks { get; } = new ObservableCollection<Deck>();

        [RelayCommand]
        public async Task LoadDecks()
        {
            Decks.Clear();
            using var db = new FlashquizzContext();
            var allDecks = db.Decks.ToList();
            foreach (var deck in allDecks)
                Decks.Add(deck);
        }

        [RelayCommand]
        public async Task NavigateToDeck(Deck deck)
        {
            if (deck == null)
                return;

            await Application.Current.MainPage.Navigation.PushAsync(new DeckForm());
        }

        [RelayCommand]
        private async Task OpenDeck(Deck deck)
        {
            if (deck == null) return;
            await Shell.Current.Navigation.PushAsync(new DeckDetailPage(deck));
        }

        [RelayCommand]
        private async Task EditDeck(Deck deck)
        {
            string newName = await App.Current.MainPage.DisplayPromptAsync("Edit Deck", "New name:", initialValue: deck.Name);
            if (newName == null) return;

            string newDesc = await App.Current.MainPage.DisplayPromptAsync("Edit Deck", "New description:", initialValue: deck.Description);
            if (newDesc == null) return;

            using var db = new FlashquizzContext();
            var dbDeck = await db.Decks.FindAsync(deck.Id);
            if (dbDeck != null)
            {
                dbDeck.Name = newName;
                dbDeck.Description = newDesc;
                await db.SaveChangesAsync();

                // Update UI
                deck.Name = newName;
                deck.Description = newDesc;
                OnPropertyChanged(nameof(Decks));
                await LoadDecks();
            }
        }

        // Delete Deck Command (unchanged)
        [RelayCommand]
        public async Task DeleteDeck(Deck deck)
        {
            if (deck == null)
                return;

            using var db = new FlashquizzContext();
            var dbDeck = db.Decks.FirstOrDefault(d => d.Id == deck.Id);
            if (dbDeck != null)
            {
                db.Decks.Remove(dbDeck);
                await db.SaveChangesAsync();
            }

            Decks.Remove(deck);
        }
    }
}
