using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TheStableFriends747.ViewModels
{
    internal class WeatherPageViewModel
    {
        //Hämtar väder från Api-ninja
        public static async Task<Models.Weather> GetWeatherAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "mJ4/jcwZ5/1eq/Rdltu3fg==0rmNWlRSkMBOqqeY");
            Models.Weather weather = null;

            HttpResponseMessage response = await client.GetAsync("v1/weather?city=Nyköping");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                weather=JsonSerializer.Deserialize<Models.Weather>(responseString);

            }
            return weather;

        }

    }
}
