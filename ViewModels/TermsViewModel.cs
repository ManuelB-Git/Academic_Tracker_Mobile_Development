using CommunityToolkit.Mvvm.ComponentModel;
using Academic_Tracker_Mobile_Development.Models;
using Academic_Tracker_Mobile_Development.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Academic_Tracker_Mobile_Development.Views;

namespace Academic_Tracker_Mobile_Development.ViewModels
{
    public partial class TermsViewModel : ObservableObject
    {
        private readonly TermRepository _db;

        [ObservableProperty]
        public partial ObservableCollection<Term> Terms { get; set; }

        public TermsViewModel()
        {
            Terms = [];
            _db = new TermRepository();
        }


        [RelayCommand]
        private async Task LoadTerms()
        {
               Terms = [.. await _db.GetAllTerms()];
        }


        [RelayCommand]
        public static async Task EditTerm(Term SelectedTerm)
        {
            await Shell.Current.Navigation.PushAsync(new AddEditTermPage(SelectedTerm));
        }

        [RelayCommand]
        public async Task DeleteTerm(Term SelectedTerm)
        {
            if (SelectedTerm == null)
            {
                await Shell.Current.DisplayAlert("Error", "No term selected.", "OK");
                return;
            }
            var result = await Shell.Current.DisplayAlert("Delete Term", $"Are you sure you want to delete {SelectedTerm.Title}?", "Yes", "No");
            if (result)
            {
                try
                {
                    await _db.DeleteTerm(SelectedTerm);
                    Terms.Remove(SelectedTerm);
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", $"Failed to delete term: {ex.Message}", "OK");
                }
            }
        }




        [RelayCommand]
        private static async Task NavigateEditAddTerm()
        {
            Term term = new()
            {
                Title = string.Empty,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(6)
            };

            await Shell.Current.Navigation.PushAsync(new AddEditTermPage(term));
        }


       
    }
}