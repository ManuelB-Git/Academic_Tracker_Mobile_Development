using Academic_Tracker_Mobile_Development.ViewModels;

namespace Academic_Tracker_Mobile_Development.Views;

public partial class Terms : ContentPage
{
	public Terms()
	{
		InitializeComponent();
        BindingContext = new TermsViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is TermsViewModel viewModel)
        {
            await viewModel.LoadTermsCommand.ExecuteAsync(null);
        }
    }
}