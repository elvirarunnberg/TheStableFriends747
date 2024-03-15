namespace TheStableFriends747.Views;

public partial class WeatherPage : ContentPage
{
	public WeatherPage()
	{
		InitializeComponent();
		OnClickedGetWeather(null, null);
	}

    private async void OnClickedGetWeather(object sender, EventArgs e)
    {
		//Hämtar vädret 
		Models.Weather weather = await ViewModels.WeatherPageViewModel.GetWeatherAsync();
		if (weather != null) 
		{
			
			Maxtemp.Text = weather.max_temp.ToString();
			Mintemp.Text = weather.min_temp.ToString();
			Feelslike.Text = weather.feels_like.ToString();
		}
    }
}