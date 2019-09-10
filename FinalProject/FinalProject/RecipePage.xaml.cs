using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace FinalProject
{
    public partial class RecipePage : ContentPage
    {
        public RecipePage()
        {
            InitializeComponent();
        }

        public RecipePage(RecipeGet root)
        {
            InitializeComponent();
            BindingContext = root;
            IngredientList.ItemsSource = new ObservableCollection<string>(root.ingredients);
        }
    }
}
