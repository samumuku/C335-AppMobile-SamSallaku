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
    public partial class DeckCRUDViewModel : ObservableObject
    {

        public ObservableCollection<Deck> Decks { get; } = new ObservableCollection<Deck>();

        [ObservableProperty]
        private string deckName;
        partial void OnDeckNameChanged(string value)
        {
            AddDeckCommand.NotifyCanExecuteChanged();
        }
        [ObservableProperty]
        private string description;

        partial void OnDescriptionChanged(string value)
        {
            AddDeckCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand(CanExecute = nameof(AddDeckCanExecute))]
        private async Task AddDeck(string definition)
        {
            await App.Current.MainPage.DisplayAlert("Deck Created", $"Name: {DeckName}", "OK");

            if (string.IsNullOrWhiteSpace(DeckName) || string.IsNullOrWhiteSpace(Description))
            {
                await App.Current.MainPage.DisplayAlert("Validation","Name and description are needed", "OK");
                return;
            }
            var deck = new Deck
            {
                Name = DeckName,
                Description = Description,
            };

            using (var dbContext = new FlashquizzContext())
            {
                dbContext.Add(deck);
                await dbContext.SaveChangesAsync();
            }

            Decks.Add(deck);

            DeckName = string.Empty;
            Description = string.Empty;
        }

        private bool AddDeckCanExecute()
        {
            return !string.IsNullOrEmpty(DeckName) && !string.IsNullOrEmpty(Description);
        }

    }
}
