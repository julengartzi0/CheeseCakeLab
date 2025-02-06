namespace CheescakeOrdezkaritza
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public Command GoHomeCommand => new(async () =>
    await Shell.Current.GoToAsync("//MainPage"));

        public Command GoXmlCommand => new(async () =>
            await Shell.Current.GoToAsync("//xmlKargatu"));

        public Command GoOrdezkariakCommand => new(async () =>
            await Shell.Current.GoToAsync("//ordezkariakIkusi"));

        public Command GoPartnerrakCommand => new(async () =>
            await Shell.Current.GoToAsync("//partnerrakIkusi"));
    }
}
