namespace TheStableFriends747
{
    public partial class MainPage : ContentPage
    {
    
        //Jag har funderat över mönsterdesign och singleton men kommit fram till att det inte
        //fyller någon funktion i min app. Eftersom att jag vill att appen ska vara kollektiv 
        //och öppen för alla i stallet att använda så vill jag köra utan inloggning!
        
        public MainPage()
        {
            InitializeComponent();
        }

   

        private async void OnClickedGoWeatherPage(object sender, EventArgs e)
        {
            //Går till vädersidan
            await Navigation.PushAsync(new Views.WeatherPage());
        }

        private async void OnClickedGoBullentinPage(object sender, EventArgs e)
        {
            //Går till anslagstavlan
            await Navigation.PushAsync(new Views.BullentinBoardPage());
        }

        private async void OnClickedGoHorsePage(object sender, EventArgs e)
        {
            //Går till hästsidan
            await Navigation.PushAsync(new Views.HorsePage());
        }

    }

}
