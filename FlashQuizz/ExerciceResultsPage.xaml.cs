using Microsoft.Maui.Controls;
using FlashQuizz.Views;

namespace FlashQuizz.Views
{
    public partial class ExerciseResultsPage : ContentPage
    {
        public ExerciseResultsPage(ExerciseResults results)
        {
            InitializeComponent();
            BindingContext = new ExerciseResultsViewModel(results);
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }

    public class ExerciseResultsViewModel
    {
        public string TimeTakenString { get; }
        public string HardestCard { get; }
        public string CorrectCards { get; }
        public string SuccessRate { get; }

        public ExerciseResultsViewModel(ExerciseResults results)
        {
            TimeTakenString = $"Time taken: {results.TimeTaken:mm\\:ss}";
            HardestCard = $"Hardest card: \"{results.HardestCardQuestion}\" with {results.HardestCardErrors} errors";
            CorrectCards = $"Cards 100% correct: {results.CorrectCardsCount} / {results.TotalCards}";
            SuccessRate = $"Success rate: {results.SuccessRate:F1}%";
        }
    }
}
