using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Net.Http;


namespace FinalProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class drinkMoreInfo : ContentPage
	{
        public drinkMoreInfo()
        {
            InitializeComponent();
        }
        public drinkMoreInfo(dRootObject drank)
        {
            InitializeComponent();
            drinkNameLabel.Text = drank.drinks[0].strDrink;
            drinkimg.Source = drank.drinks[0].strDrinkThumb;
            drinkLabel.Text = "Instructions: " + drank.drinks[0].strInstructions;

            var ingredList = new ObservableCollection<drinkIngredient>();
            var ingredient1 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient1,
                Amount = drank.drinks[0].strMeasure1,
            };
            var ingredient2 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient2,
                Amount = drank.drinks[0].strMeasure2,
            };
            var ingredient3 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient3,
                Amount = drank.drinks[0].strMeasure3,
            };
            var ingredient4 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient4,
                Amount = drank.drinks[0].strMeasure4,
            };
            var ingredient5 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient5,
                Amount = drank.drinks[0].strMeasure5,
            };
            var ingredient6 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient6,
                Amount = drank.drinks[0].strMeasure6,
            };
            var ingredient7 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient7,
                Amount = drank.drinks[0].strMeasure7,
            };
            var ingredient8 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient8,
                Amount = drank.drinks[0].strMeasure8,
            };
            var ingredient9 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient9,
                Amount = drank.drinks[0].strMeasure9,
            };
            var ingredient10 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient10,
                Amount = drank.drinks[0].strMeasure10,
            };
            var ingredient11 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient11,
                Amount = drank.drinks[0].strMeasure11,
            };
            var ingredient12 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient12,
                Amount = drank.drinks[0].strMeasure12,
            };
            var ingredient13 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient13,
                Amount = drank.drinks[0].strMeasure13,
            };
            var ingredient14 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient14,
                Amount = drank.drinks[0].strMeasure14,
            };
            var ingredient15 = new drinkIngredient
            {
                Name = drank.drinks[0].strIngredient15,
                Amount = drank.drinks[0].strMeasure15,
            };
            //adds all the ingredients into the list
            ingredList.Add(ingredient1);
            ingredList.Add(ingredient2);
            ingredList.Add(ingredient3);
            ingredList.Add(ingredient4);
            ingredList.Add(ingredient5);
            ingredList.Add(ingredient6);
            ingredList.Add(ingredient7);
            ingredList.Add(ingredient8);
            ingredList.Add(ingredient9);
            ingredList.Add(ingredient10);
            ingredList.Add(ingredient11);
            ingredList.Add(ingredient12);
            ingredList.Add(ingredient13);
            ingredList.Add(ingredient14);
            ingredList.Add(ingredient15);
            
        
            ingredientLabel.Text = "Ingredients";
            //drinkList.ItemsSource = new ObservableCollection<string>(ingredList);
            drinkList.ItemsSource = ingredList;
            dateModLabel.Text = "Date Modified: " + drank.drinks[0].dateModified;
        }
        
	}
}