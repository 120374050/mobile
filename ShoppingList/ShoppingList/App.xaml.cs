using ShoppingList.Views;

namespace ShoppingList;

public partial class App : Application
{
	public static string SessionKey = "";

	public App()
	{
		//user:fisher
		//pass: test

		InitializeComponent();

		MainPage = new NavigationPage(new MainPage());
	}
}

