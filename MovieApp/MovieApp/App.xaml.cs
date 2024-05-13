using MovieApp.Models;

namespace MovieApp;

public partial class App : Application
{
	//public static List<Movie> MovieList;
	public static Repository MovieList;


    public App()
	{
		InitializeComponent();
		//MovieList = new List<Movie>();

		MovieList = new Repository();
		MainPage = new AppShell();
	}
}

