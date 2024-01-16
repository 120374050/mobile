namespace HelloWorld;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		if (lblDisplay.Text == "Hello World")
		{
			lblDisplay.Text = "Good Day";
		}
		else
		{
			lblDisplay.Text = "Hello World";
        }
	}
}


