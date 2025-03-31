using Academic_Tracker_Mobile_Development.Services;

namespace Academic_Tracker_Mobile_Development
{
    public partial class App : Application
    {
        private static LocalDbService? _localDbService;

        public static LocalDbService LocalDbService
        {
            get
            {
                _localDbService ??= new LocalDbService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "academic_tracker_localDB.db3"));
                return _localDbService;
            }
        }
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}