using MongoDB.Driver;
using TheStableFriends747.Models;

namespace TheStableFriends747.Views;

public partial class CreateNewBullentinPage : ContentPage
{
	public BullentinBoard BullentinBoard { get; set; }
	public CreateNewBullentinPage(BullentinBoard bullentinBoard)
	{
		InitializeComponent();
		BullentinBoard = bullentinBoard;

		if (bullentinBoard != null)
		{
			//Fyller i befintlig data
            MessageEntry.Text = bullentinBoard.Message;
            SaveButton.Text = "Spara ändringar";
        }
        else
        {
            //Sparar ny data
            BullentinBoard = new BullentinBoard();
            SaveButton.Text = "Spara";
        }
    }

    private async void OnClickedSaveBullentinNote(object sender, EventArgs e)
    {
        // Uppdatera anslagstavlan med info från användare
        BullentinBoard.Message = MessageEntry.Text;
        BullentinBoard.ImageSource = "flower.photo.jpg";

        try
        {
            if (BullentinBoard.Id == Guid.Empty)
            {
                // Göra ny anteckning
                BullentinBoard.Id = Guid.NewGuid();
                await Data.DB.BullentinCollection().InsertOneAsync(BullentinBoard);
            }
            else
            {
                // Uppdatera befintlig anteckning
                var filter = Builders<BullentinBoard>.Filter.Eq(x => x.Id, BullentinBoard.Id);
                var update = Builders<BullentinBoard>.Update
                    .Set(x => x.Message, BullentinBoard.Message);
                    //.Set(x => x.ImageSource, BullentinBoard.ImageSource);

                await Data.DB.BullentinCollection().UpdateOneAsync(filter, update);
            }

            await DisplayAlert("Tjoho!", "Din anteckning har sparats!", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hoppsan!", $"Ett fel uppstod: {ex.Message}", "OK");
        }

        await Navigation.PopAsync();
    }
}


