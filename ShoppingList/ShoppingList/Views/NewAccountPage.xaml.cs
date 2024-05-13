using ShoppingList.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ShoppingList.Views;

public partial class NewAccountPage : ContentPage
{
	public NewAccountPage()
	{
		InitializeComponent();
	}

    async void CreateAccount_Clicked(System.Object sender, System.EventArgs e)
    {
		//Do Passwords Match
		if (txtPassword.Text != txtPass2.Text)
		{
			await DisplayAlert("Error", "Your Passwords do not match!!", "OK");
			return;
		}

        //Valid Email
        var pattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
        Regex rg = new Regex(pattern);

        if (!rg.IsMatch(txtEmail.Text))
        {
            DisplayAlert("Bad", "Bad", "OK");
        }

        //Create Account on API
        var data = JsonConvert.SerializeObject(new UserAccount(txtUser.Text, txtEmail.Text, txtPassword.Text));


        //complete
        //user exists
        //email exists

        HttpClient client = new HttpClient();
		var Responce = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/createuser"),new StringContent(data,System.Text.Encoding.UTF8,"application/json"));
		var AccountStatus = Responce.Content.ReadAsStringAsync().Result;

		//Create Account Error?
		if (AccountStatus== "user exists")
		{
            await DisplayAlert("Error", "Sorry this username has been taken!", "OK");
            return;
        }

        if (AccountStatus == "email exists")
        {
            await DisplayAlert("Error", "Sorry this email address has been used!", "OK");
            return;
        }

        if (AccountStatus == "complete")
        {
            Responce = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/login"), new StringContent(data, System.Text.Encoding.UTF8, "application/json"));
            var Skey = Responce.Content.ReadAsStringAsync().Result;

            if (string.IsNullOrEmpty(Skey) || Skey.Length > 50)
            {
                await DisplayAlert("Error", "Sorry an error happened logging in", "OK");
                return;
            }
            else
            {
                //Login to app
                App.SessionKey = Skey;
                Navigation.PopModalAsync();
            }
        }
        else
        {
            await DisplayAlert("Error", "Sorry an unknown error happened", "OK");
            return;
        }
    }
}
