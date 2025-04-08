using Academic_Tracker_Mobile_Development.Models;
using Academic_Tracker_Mobile_Development.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Academic_Tracker_Mobile_Development.ViewModels
{
    public partial class AddEditTermViewModel : ObservableObject
    {
        private readonly TermRepository _db;

        [ObservableProperty]
        public partial string termName { get; set; }
        [ObservableProperty]
        public partial DateTime startDate { get; set; }
        [ObservableProperty]
        public partial DateTime endDate { get; set; }



        public AddEditTermViewModel(Term term)
        {

            _db = new TermRepository();

            if (term.Id == 0)
            {
                termName = string.Empty;
                startDate = DateTime.Now;
                endDate = DateTime.Now.AddMonths(6);
            }
            else
            {
                termName = term.Title;
                startDate = term.StartDate;
                endDate = term.EndDate;

            }
        }


        [RelayCommand]
        private async Task SaveTerm()
        {
            // Validate term name
            if (string.IsNullOrWhiteSpace(termName))
            {
                await Shell.Current.DisplayAlert("Error", "Term name cannot be empty.", "OK");
                return;
            }

            // Validate dates
            if (endDate < startDate)
            {
                await Shell.Current.DisplayAlert("Error", "End date cannot be before start date.", "OK");
                return;
            }

            try
            {
                Term term = new()
                {
                    Title = termName,
                    StartDate = startDate,
                    EndDate = endDate,
                };

                await _db.SaveTerm(term);
                await Shell.Current.DisplayAlert("Success", "Term saved successfully.", "OK");
                await Shell.Current.GoToAsync("///Terms");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to save term: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private static async Task Cancel()
        {
            bool confirm = await Shell.Current.DisplayAlert("Cancel", "Are you sure you want to cancel?", "Yes", "No");
            if (confirm)
            {
                await Shell.Current.GoToAsync("///Terms");
            }
        }
    }
}
