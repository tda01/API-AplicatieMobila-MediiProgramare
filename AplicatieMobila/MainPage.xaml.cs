
using Microsoft.Maui.Hosting;
using System.Net.NetworkInformation;
using Microsoft.Maui.Controls;


namespace AplicatieMobila
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

   
        }

        async void OnShowMapButtonClicked(object sender, EventArgs e)
        {

            // Merge pe Android, pe Windows Machine nu

            try
            {
                var address = "Calea Dorobanților 16, Cluj-Napoca";
                var locations = await Geocoding.GetLocationsAsync(address);

                var options = new MapLaunchOptions
                {
                    Name = "Mica Ciuperca" };

                var location = locations?.FirstOrDefault();
                // var myLocation = await Geolocation.GetLocationAsync();
                var myLocation = new Location(46.7731796289, 23.6213886738);

      
                await Map.OpenAsync(location, options);


            }

            catch (Exception ex)
            {

                Console.WriteLine($"Eroare: {ex.Message}");
            }




        }







    }

        

    
}