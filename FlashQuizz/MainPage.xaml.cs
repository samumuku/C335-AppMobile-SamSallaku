using FlashQuizz.ViewModels;
using FlashQuizz.Models;
using FlashQuizz.Views;

namespace FlashQuizz
{
    public partial class MainPage : ContentPage
    {
        private DecksViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new DecksViewModel();
            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadDecks(); // reload every time we return
        }
        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("DeckForm");
        }
        private async void OnDeckSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Deck selectedDeck)
            {
                ((CollectionView)sender).SelectedItem = null; // Optional: deselect after tap
                await Navigation.PushAsync(new DeckDetailPage(selectedDeck));
            }
        }


    }

}
