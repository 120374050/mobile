namespace DateNight.Views;

public partial class CoffeePage : ContentPage
{
	public CoffeePage()
	{
		InitializeComponent();
		Title = "Going For Coffee";
	}

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
		App.dateCalc.CoffeeCost = txtCoffee.Text;
    }
}
