using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        async void Login_Clicked(object sender, System.EventArgs e)
        {

            if(Username_Entry.Text != null || Password_Entry.Text != null)
            {
                UserModel currentUser = await App.Database.CheckValid(Username_Entry.Text, Password_Entry.Text);
                if(currentUser == null)
                {
                    await DisplayAlert("Error", "Invalid Username or Password", "OK");
                    return;
                }
                else
                    await Navigation.PushAsync(new HomePage(currentUser));
            }
            else
                await DisplayAlert("Error", "Please fill out both fields", "OK");
        }

        async void NewAccount_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewAccountPage()); //go to the new account creation page
        }

        async void ForgotPassword_Clicked(object sender, System.EventArgs e)
        {
            Analytics.TrackEvent("ForgotPassword");
            var answer = await DisplayAlert("Just so you know", "clicking yes will display your password on the screen", "Yes", "No");
            
            if(answer)
            {
                if (Username_Entry.Text == null)
                {
                    await DisplayAlert("Error", "Enter Username into Field", "Ok");
                    return;
                }
                else
                {
                    UserModel currentUser = await App.Database.RetrievePassword(Username_Entry.Text);
                    if (currentUser == null)
                    {
                        await DisplayAlert("Error", "Username not found", "Ok");
                        return;
                    }
                    else
                        await DisplayAlert("Your Password", currentUser.Password, "Ok");
                }
            }
            else
                return;
        }
    }
}
