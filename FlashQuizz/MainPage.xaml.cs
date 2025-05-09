using FlashQuizz.ViewModels;

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
            await Shell.Current.GoToAsync("AddFlashcardForm");
        }

    }

}
