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
	public partial class NewAccountPage : ContentPage
	{
		public NewAccountPage ()
		{
			InitializeComponent ();
		}

        public async void CreateAccount(object sender, EventArgs e)
        {
            if (Name_Entry.Text == null || Name_Entry.Text == "")
            { //if entry box was not touched (null) or is touched but empty ("")
                await DisplayAlert("Error: Name", "Please enter a name", "OK");
                return;
            }
            else if(Username_Entry.Text == null || Username_Entry.Text == "")
            { //if entry box was not touched (null) or is touched but empty ("")
                await DisplayAlert("Error: Username", "Please enter a Username", "OK");
                return;
            }
            else if (Email_Entry.Text == null || Email_Entry.Text == "")
            { //if entry box was not touched (null) or is touched but empty ("")
                await DisplayAlert("Error: Email", "Please enter an email", "OK");
                return;
            }
            else if (Password_Entry.Text == null || Password_Entry.Text == "" || Password_Entry.Text != ReEnterPassword_Entry.Text)
            { //if the entry box was not touched (null), is touched but empty (""), or both password entries do not match
                await DisplayAlert("Error: Password", "Please make sure both password fields match and are not empty", "OK");
                return;
            }
            else
            {
                var user = new UserModel
                {
                    Name = Name_Entry.Text,
                    UserName = Username_Entry.Text,
                    Password = Password_Entry.Text,
                };
                UserModel exists = await App.Database.CheckUsername(user.UserName);
                if (exists == null)
                {
                    await App.Database.SaveItemAsync(user);
                    await DisplayAlert("Success", "Account successfully created", "OK");
                    await Navigation.PopAsync();
                }
                else
                    await DisplayAlert("Error: Username already in use", "please pick new username", "OK");
            }
        }
    }
}