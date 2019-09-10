using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppContentPage : TabbedPage
    {
        public AppContentPage ()
        {
            InitializeComponent();

            Children.Add(new SearchTab());
            Children.Add(new AlcoholSearch());
        }
        private async void Logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}