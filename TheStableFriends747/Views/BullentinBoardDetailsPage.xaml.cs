using MongoDB.Driver;

namespace TheStableFriends747.Views;

public partial class BullentinBoardDetailsPage : ContentPage
{
	public BullentinBoardDetailsPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.BullentinViewModel();
    }

    private async void OnClickedDeleteBullentinNote(object sender, EventArgs e)
    {
        //Raderar vald anteckning
        var bullentinNote = ((Button)sender).BindingContext as Models.BullentinBoard;

        var filter = Builders<Models.BullentinBoard>.Filter.Eq(x => x.Id, bullentinNote.Id);

        await Data.DB.BullentinCollection().DeleteOneAsync(filter);

        await Navigation.PushAsync(new BullentinBoardPage());
    }

    private async void OnClickedUpdateBullentinNote(object sender, EventArgs e)
    {
        //Uppdaterar vald anteckning
        var bullentinNote = ((Button)sender).BindingContext as Models.BullentinBoard;
        await Navigation.PushAsync(new CreateNewBullentinPage(bullentinNote));

    }
}