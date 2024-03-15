
namespace TheStableFriends747.Views;

public partial class HorsePage : ContentPage
{
    public HorsePage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.HorsePageViewModel();
    }

 
  
    private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //Här hamnar man på detaljsidan hos den häst man klickat på
        var horse = ((ListView)sender).SelectedItem as Models.Horse;

        ((ListView)sender).SelectedItem = null;

        if (horse != null)
        {
            var page = new HorseDetailsPage();
            page.BindingContext = horse;
            await Navigation.PushAsync(page);
        }

    }

    private async void OnClickedGoMakeNewHorsePage(object sender, EventArgs e)
    {
        //Skickas till sidan för att göra ny häst
        await Navigation.PushAsync(new Views.CreateNewHorsePage(null));
    }
}