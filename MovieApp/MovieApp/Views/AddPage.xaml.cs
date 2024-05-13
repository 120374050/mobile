using MovieApp.Models;

namespace MovieApp.Views;

public partial class AddPage : ContentPage
{
	public AddPage()
	{
		InitializeComponent();
		Title = "Add New Movie";
	}

    void Add_Clicked(System.Object sender, System.EventArgs e)
    {
		var nm = new Movie();
		nm.Title = txtTitle.Text;
		nm.Rating = txtRating.Text;

		App.MovieList.SaveMovie(nm);

		txtTitle.Text = "";
		txtRating.Text = "";
    }
}
