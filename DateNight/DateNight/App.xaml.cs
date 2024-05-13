using DateNight.Models;

namespace DateNight;


public partial class App : Application
{
	public static DateCalculator dateCalc;

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		dateCalc = new DateCalculator();

    }
}

