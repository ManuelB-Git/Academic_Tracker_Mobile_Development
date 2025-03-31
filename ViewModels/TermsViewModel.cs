using CommunityToolkit.Mvvm.ComponentModel;
using Academic_Tracker_Mobile_Development.Models;
using Academic_Tracker_Mobile_Development.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Academic_Tracker_Mobile_Development.Views;

namespace Academic_Tracker_Mobile_Development.ViewModels
{
    public partial class TermsViewModel: ObservableObject
    {
        private readonly TermRepository _db;

        public ObservableCollection<Term> Terms { get; set; } = [];

        public TermsViewModel()
        {
            _db = new TermRepository();
            LoadTermsCommand.Execute(null);
        }

        [RelayCommand]
        async Task LoadTerms()
        {
            var termsFromDB = await _db.GetAllTerms();
            Terms.Clear();
            foreach (Term term in termsFromDB)
            {
                Terms.Add(term);
            }

        }

        [RelayCommand]
        private static async Task NavigateEditAddTerm()
        {
            await Shell.Current.Navigation.PushAsync(new AddEditTermPage());
        }

    }
}
