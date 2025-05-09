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
        [ObservableProperty]
        private string description;
        [ObservableProperty]
        private string imagePath;

        [RelayCommand(CanExecute = nameof(AddDeckCanExecute))]
        private async Task AddDeck(string definition)
        {
            if (string.IsNullOrWhiteSpace(deckName) || string.IsNullOrWhiteSpace(description))
            {
                await App.Current.MainPage.DisplayAlert("Validation","Name and description are needed", "OK");
                return;
            }
            var deck = new Deck
            {
                Name = deckName,
                Description = description,
                ImagePath = imagePath,
            };

            using (var dbContext = new FlashquizzContext())
            {
                dbContext.Add(deck);
                await dbContext.SaveChangesAsync();
            }

            Decks.Add(deck);

            deckName = "";
            description = "";
            imagePath = null;
        }

        private bool AddDeckCanExecute()
        {
            return !string.IsNullOrEmpty(deckName) && !string.IsNullOrEmpty(description);
        }

        [RelayCommand]
        private async Task PickImage()
        {
            var fileResult = await FilePicker.PickAsync(new PickOptions { PickerTitle = "Select an image", FileTypes = FilePickerFileType.Images });

            if (fileResult != null)
            {
                imagePath = fileResult.FullPath;
            }
        }
    }
}
