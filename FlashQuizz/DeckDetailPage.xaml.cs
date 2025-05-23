namespace FlashQuizz.Views;
using ViewModels;
using Models;
public partial class DeckDetailPage : ContentPage
{
    private Deck _deck;
    public DeckDetailPage(Deck deck)
	{
		InitializeComponent();
        _deck = deck;
        BindingContext = new DeckPageViewModel(deck);

    }
    public async void OnAddFlashcardClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FlashcardForm(_deck));
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is DeckPageViewModel vm)
        {
            await vm.ReloadFlashcardsAsync();
        }
    }

}