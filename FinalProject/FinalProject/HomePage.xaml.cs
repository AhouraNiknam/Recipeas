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
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
            InitializeComponent ();
		}
        UserModel CurrentUser;
        public HomePage (UserModel currentUser)
        {
            InitializeComponent();
            Username.Text = currentUser.Name + "!";
            CurrentUser = currentUser;
        }
        
        async void Enter_App(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppContentPage());
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}