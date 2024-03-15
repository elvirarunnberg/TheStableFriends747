using MongoDB.Driver;
using System.Text.RegularExpressions;
using TheStableFriends747.Models;

namespace TheStableFriends747.Views;

public partial class CreateNewHorsePage : ContentPage
{
	
	public Horse Horse { get; set; }
	public CreateNewHorsePage(Horse horse)
	{
		InitializeComponent();
		Horse = horse;
		if (horse != null )
		{
            //Redigera befintlig häst
			HorseNameEntry.Text = horse.HorseName;
			OwnerNameEntry.Text = horse.OwnerName;
			PhoneNumberEntry.Text = horse.PhoneNumber;
			DescriptionEntry.Text = horse.Description;
			SaveButton.Text = "Spara!";

		}
	}
   
    
    private async void OnClickedSaveHorse(object sender, EventArgs e)
    {
        //Felhantering vid ifyllning av telefonnummer
        string phoneNumber = PhoneNumberEntry.Text;

        if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
        {
            await DisplayAlert("Fel uppstod", "Var vänligen fyll i ett giltigt telefonnummer med 10 siffror.", "OK");
            return;
        }


        if (Horse == null)
        {
            Horse horse = new Horse()
            {
                //Skapa ny totto
                Id = Guid.NewGuid(),
                HorseName = HorseNameEntry.Text,
                OwnerName = OwnerNameEntry.Text,
                PhoneNumber = phoneNumber,
                ImageSource = "horse.photo.jpg",
                Description = DescriptionEntry.Text,
            };
            await Data.DB.HorseCollection().InsertOneAsync(horse);
        }
        else
        {
            //Uppdatera befintlig häst om horse inte är null
            Horse.HorseName = HorseNameEntry.Text;
            Horse.PhoneNumber = phoneNumber;
            Horse.Description = DescriptionEntry.Text;
            Horse.OwnerName = OwnerNameEntry.Text;

            
            var filter = Builders<Horse>.Filter.Eq(x => x.Id, Horse.Id);
            await Data.DB.HorseCollection().ReplaceOneAsync(filter, Horse);
        }
        //Går tillbaka till HorsePage
        await Navigation.PushAsync(new HorsePage());


       

    }
}