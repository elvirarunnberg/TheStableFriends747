using MongoDB.Driver;

namespace TheStableFriends747.Views;

public partial class HorseDetailsPage : ContentPage
{
	public HorseDetailsPage()
	{
		InitializeComponent();
	}

    private async void OnClickedDeleteHorse(object sender, EventArgs e)
    {
        //Raderar vald häst
        var horse = ((Button)sender).BindingContext as Models.Horse;

        var filter = Builders<Models.Horse>.Filter.Eq(x => x.Id, horse.Id);

        await Data.DB.HorseCollection().DeleteOneAsync(filter);

        await Navigation.PushAsync(new HorsePage());


    }

    private async void OnClickedUpdateHorse(object sender, EventArgs e)
    {
        //Uppdaterar info om vald häst
        var horse = ((Button)sender).BindingContext as Models.Horse;
        await Navigation.PushAsync(new CreateNewHorsePage(horse));

    }
}