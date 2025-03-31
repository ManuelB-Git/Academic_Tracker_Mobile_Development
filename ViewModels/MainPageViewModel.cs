using Academic_Tracker_Mobile_Development.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Academic_Tracker_Mobile_Development.ViewModels
{
    public partial class MainPageViewModel: ObservableObject
    {
        [RelayCommand]
        private static async Task NavigateTerms()
        {
            await Shell.Current.GoToAsync("///Terms");
        }

        [RelayCommand]
        private static async Task NavigateReports()
        {
            await Shell.Current.Navigation.PushAsync(new Reports());
        }

    }
}
