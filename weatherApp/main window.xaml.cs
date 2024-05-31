using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace weatherApp
{
    /// <summary>
    /// Interaction logic for main_window.xaml
    /// </summary>
    public partial class main_window : UserControl
    {
        public main_window()
        {
            InitializeComponent();
            
        }

        public void updateData()
        {
            var liveWeather = WeatherData.LiveWeather;
            var weeklyForecast = WeatherData.WeeklyForecast;
            var hourlyForecasts = WeatherData.HourlyForecasts;

            temp.Content = liveWeather.temp.ToString();
            tempMinMax.Content = $"{weeklyForecast(0).}}"

        }



        private async void LoadWeatherData()
        {
            string place = inputPlace.Text.Trim().ToLower();

            bool success = await WeatherData.FetchWeatherData("demo", place);

            if (success)
            {
                // Data was successfully fetched
                var forecastForHour9 = WeatherData.GetHourlyForecastByHour(9);

                // Use the forecast data as needed
                if (forecastForHour9 != null)
                {
                    Console.WriteLine($"Temperature at 9:00: {forecastForHour9.temp}°C");
                    Console.WriteLine($"Weather at 9:00: {forecastForHour9.image}");
                }
                else
                {
                    Console.WriteLine("No forecast available for 9:00.");
                }
            }
            else
            {
                // Handle the failure
                Console.WriteLine("Failed to fetch weather data.");
            }
        }

    }
}
