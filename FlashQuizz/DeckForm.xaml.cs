using System.Diagnostics;
using FlashQuizz.Models;
using FlashQuizz.ViewModels;
namespace FlashQuizz
{
    public partial class DeckForm : ContentPage
    {
        public DeckForm()
        {
            InitializeComponent();
            BindingContext = new DeckCRUDViewModel();
        }
    }
}
