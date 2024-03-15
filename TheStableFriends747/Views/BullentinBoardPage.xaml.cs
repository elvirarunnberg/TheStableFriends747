namespace TheStableFriends747.Views;

public partial class BullentinBoardPage : ContentPage
{
	public BullentinBoardPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.BullentinViewModel();
    }

    private async void OnListViewNoteSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //G�r s� man kommer till detaljsidan f�r den post man trycker p�
        var bullentinNote = ((ListView)sender).SelectedItem as Models.BullentinBoard;

        ((ListView)sender).SelectedItem = null;

        if (bullentinNote != null)
        {
            var page = new BullentinBoardDetailsPage();
            page.BindingContext = bullentinNote;
            await Navigation.PushAsync(page);
        }
    }

    private async void OnClickedGoMakeNewBullentinNotePage(object sender, EventArgs e)
    {
        //Hoppar vidare till d�r man g�r en ny anteckning
        await Navigation.PushAsync(new Views.CreateNewBullentinPage(null));
    }

  
}