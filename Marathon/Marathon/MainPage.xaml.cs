using Marathon.Models;
using Newtonsoft.Json;

namespace Marathon;

public partial class MainPage : ContentPage
{
	RaceCollection RaceObject;

    public MainPage()
	{
		InitializeComponent();
		FillPicker();
	}

	private void FillPicker()
	{
		var client = new HttpClient();
		client.BaseAddress = new Uri("https://joewetzel.com/fvtc/marathon/");
		var response = client.GetAsync("races/").Result;
		var wsJson = response.Content.ReadAsStringAsync().Result;

        RaceObject = JsonConvert.DeserializeObject<RaceCollection>(wsJson);

		RacePicker.ItemsSource = RaceObject.races;

    }

    void RacePicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
		var SelectedRace = ((Picker)sender).SelectedIndex;
		var race_id = RaceObject.races[SelectedRace].id;

        var client = new HttpClient();
        client.BaseAddress = new Uri("https://joewetzel.com/fvtc/marathon/");
        var response = client.GetAsync("results/" + race_id).Result;
        var wsJson = response.Content.ReadAsStringAsync().Result;

		var ResultObject = JsonConvert.DeserializeObject<ResultCollection>(wsJson);

		var CellTemplate = new DataTemplate(typeof(TextCell));
		CellTemplate.SetBinding(TextCell.TextProperty, "name");
		CellTemplate.SetBinding(TextCell.DetailProperty, "detail");

		lstResults.ItemTemplate = CellTemplate;
		lstResults.ItemsSource = ResultObject.results;
    }
}


