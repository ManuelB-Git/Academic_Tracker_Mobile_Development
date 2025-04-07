using Academic_Tracker_Mobile_Development.Services;

namespace Academic_Tracker_Mobile_Development
{
    public partial class App : Application
    {
   
        public App()
        {
            InitializeComponent();

        

        }

        protected override async void OnStart()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyDatabase.db3");
            await LocalDbService.InitAsync(dbPath);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}