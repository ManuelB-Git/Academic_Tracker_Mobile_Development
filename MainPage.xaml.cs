using Academic_Tracker_Mobile_Development.Views;

namespace Academic_Tracker_Mobile_Development
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CourseView());
        }
    }

}
