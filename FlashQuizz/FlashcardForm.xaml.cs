namespace FlashQuizz;
using ViewModels;
using Models;

public partial class FlashcardForm : ContentPage
{
    public FlashcardForm(Deck deck)
    {
        InitializeComponent();
        BindingContext = new FlashcardViewModel(deck);
    }
}