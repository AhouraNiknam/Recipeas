using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System.Net.Http;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter.Analytics;

namespace FinalProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchTab : ContentPage
	{
        /*
        //Database of recipe API used to match the keyword user types in search bar
        List<string> recipe = new List<string>
        {
            //---Some code here---//
        };
        */

		public SearchTab ()
		{
			InitializeComponent();
		}
        public SearchTab(UserModel CurrentUser)
        {
            InitializeComponent();
        }

        //--------------dont forget to copy text changed code onto button pressed when you're done-----------------//
        async void RecipeSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            Analytics.TrackEvent("SearchFood");

            actInd.IsVisible = true;
            actInd.IsRunning = true;
            string lower = RecipeSearchBar.Text.ToLower();

            string recipeApiAddress = "https://www.food2fork.com/api/search?key=e1aeee853d373da42061c4ae28dff344&q=" + lower;
            var Uri = new Uri(recipeApiAddress);

            var client = new HttpClient();
            //var data = new ObservableCollection<Recipe>();
            RecipeList recipeData = new RecipeList();

            HttpResponseMessage response = await client.GetAsync(Uri);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                if (jsonContent == "{\"count\": 0, \"recipes\": []}")
                {
                    await DisplayAlert("ERROR", lower + " was not found", "OK");
                    actInd.IsRunning = false;
                    actInd.IsVisible = false;
                    return;
                }
                recipeData = JsonConvert.DeserializeObject<RecipeList>(jsonContent);
            }
            else
            {
                await DisplayAlert("ERROR", "json request failed", "OK");
            }
            actInd.IsRunning = false;
            actInd.IsVisible = false;
            recipeListView.ItemsSource = new ObservableCollection<Recipe>(recipeData.recipes);

        }
        //This event handler updates the list view every time the text is changed
        void RecipeSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
            //maybe put this up top by your List<string> recipe?
            string lower = RecipeSearchBar.Text.ToLower();
            //-------------find out what our api is--------------------//
            string recipeApiAddress = "https://www.food2fork.com/api/search?key=e1aeee853d373da42061c4ae28dff344&q=" + lower;
            var Uri = new Uri(recipeApiAddress);

            var client = new HttpClient();
            //var data = new ObservableCollection<Recipe>();
            RecipeList recipeData = new RecipeList();

            HttpResponseMessage response = await client.GetAsync(Uri);
            if(response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                recipeData = JsonConvert.DeserializeObject<RecipeList>(jsonContent);
            }
            recipeListView.ItemsSource = new ObservableCollection<Recipe>(recipeData.recipes);

            ----------------------------------------
            var keyword = RecipeSearchBar.Text;
            var suggestions = recipe.Where(c => c.ToLower().Contains(keyword.ToLower()));

            SuggestionsListView.ItemsSource = suggestions;
            */
            
        }

        //This handles selecting a recipe from the search list
        void SuggestionsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var recipe = e.Item as string;

            //---Some code for user selecting the recipe they want---//
            //---By selecting the recipe it will send the to the recipe page---//


        }

        async void Handle_Clicked(object sender, EventArgs e)
        {
            var selectedItem = (MenuItem)sender;
            var selectedRecipe = (Recipe)selectedItem.CommandParameter;

            string recipeApiAddress = "https://www.food2fork.com/api/get?key=e1aeee853d373da42061c4ae28dff344&rId=" + selectedRecipe.recipe_id;
            var Uri = new Uri(recipeApiAddress);

            var client = new HttpClient();
            //var data = new ObservableCollection<Recipe>();
            RootObject recipeData = new RootObject();

            HttpResponseMessage response = await client.GetAsync(Uri);
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                recipeData = JsonConvert.DeserializeObject<RootObject>(jsonContent);
            }
            //recipeListView.ItemsSource = new ObservableCollection<Recipe>(recipeData.recipes);
            await Navigation.PushAsync(new RecipePage(recipeData.recipe));

        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}