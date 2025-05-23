namespace FlashQuizz
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("FlashcardForm", typeof(FlashcardForm));
            Routing.RegisterRoute("DeckForm", typeof(DeckForm));

        }
    }
}
