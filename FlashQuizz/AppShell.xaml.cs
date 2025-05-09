namespace FlashQuizz
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("AddFlashcardForm", typeof(AddFlashcardForm));
        }
    }
}
