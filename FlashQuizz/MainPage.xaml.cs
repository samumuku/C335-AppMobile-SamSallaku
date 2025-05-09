namespace FlashQuizz
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AddFlashcardForm");
        }

    }

}
