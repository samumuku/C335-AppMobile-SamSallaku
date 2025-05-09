using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashQuizz.Models;
using FlashQuizz.Services;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            // Navigate to Deck Page (e.g., to add flashcards)
            await Shell.Current.GoToAsync($"deck/{deck.Id}");
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
