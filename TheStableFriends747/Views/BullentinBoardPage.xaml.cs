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
        //Gör så man kommer till detaljsidan för den post man trycker på
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
        //Hoppar vidare till där man gör en ny anteckning
        await Navigation.PushAsync(new Views.CreateNewBullentinPage(null));
    }

  
}