using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Microsoft.AppCenter.Analytics;

namespace FinalProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlcoholSearch : ContentPage
	{
		public AlcoholSearch ()
		{
			InitializeComponent ();
		}

       async void DrinksSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            Analytics.TrackEvent("SearchDrink");
            actIndA.IsVisible = true;
            actIndA.IsRunning = true;

            string word = DrinksSearchBar.Text.ToLower();
            string drinkApi = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=" + word;//search by name

            var Uri = new Uri(drinkApi);
            var dclient = new HttpClient();

            dRootObject drinksData = new dRootObject();
          
            HttpResponseMessage dresponse = await dclient.GetAsync(Uri);
            if (dresponse.IsSuccessStatusCode)
            {
                var jsonContent = await dresponse.Content.ReadAsStringAsync();
                if (jsonContent == "{\"drinks\":null}")
                {
                    await DisplayAlert("ERROR", word + " was not found", "OK");
                    actIndA.IsVisible = false;
                    actIndA.IsRunning = false;
                    return;
                }
                drinksData = JsonConvert.DeserializeObject<dRootObject>(jsonContent);
            }
            else
            {
                await DisplayAlert("ERROR", "json request failed", "OK");
            }
            actIndA.IsVisible = false;
            actIndA.IsRunning = false;
            drinksListView.ItemsSource = new ObservableCollection<Drink>(drinksData.drinks);
        }

        async void Handle_GetDrinks(object sender,System.EventArgs e)
        {
            var selectedItem = (MenuItem)sender;
            var selectedDrink = (Drink)selectedItem.CommandParameter;
            //DisplayAlert("the id is",selectedDrink.idDrink,"ok");//error check
            string drinkApi = "https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=" + selectedDrink.idDrink;//search by name

            var uri = new Uri(drinkApi);
            var dclient = new HttpClient();

            //Drink ddata = new Drink();
            dRootObject ddata = new dRootObject();
            HttpResponseMessage dresponse = await dclient.GetAsync(uri);
            if (dresponse.IsSuccessStatusCode)
            {
                var jsonContent = await dresponse.Content.ReadAsStringAsync();
                //ddata = JsonConvert.DeserializeObject<Drink>(jsonContent);
                ddata = JsonConvert.DeserializeObject<dRootObject>(jsonContent);
                //DisplayAlert("the ddata id is", ddata.drinks[0].idDrink, "ok");
            }
            else
            {
                //DisplayAlert("ERROR", "DIDNT WORK", "ok");

            }
            //DisplayAlert("the ddata id is", ddata.idDrink, "ok");

            await Navigation.PushAsync(new drinkMoreInfo(ddata));

        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }

}