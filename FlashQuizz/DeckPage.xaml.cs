namespace FlashQuizz;
using ViewModels;
using Models;

public partial class DeckPage : ContentPage
{
    public DeckPage(Deck deck)
    {
        InitializeComponent();
        BindingContext = new DeckPageViewModel(deck);
    }
}