using TimerPro.Custom;

namespace TimerPro;

public partial class MainPage : ContentPage
{
    TimerLogic oTimerLogic = new TimerLogic();
    bool isRunning;

	public MainPage()
	{
		InitializeComponent();
		Title = "Timer Pro";
	}

    void btnStart_Clicked(System.Object sender, System.EventArgs e)
    {
        btnStart.IsEnabled = false;
        btnStop.IsEnabled = true;
        isRunning = true;

        Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () => {
            if (isRunning)
            {
                oTimerLogic.SetTickCount();
                lblDisplay.Text = oTimerLogic.GetFormattedString();
            }
          
            return isRunning;
        });

    }

    void btnStop_Clicked(System.Object sender, System.EventArgs e)
    {
        btnStop.IsEnabled = false;
        btnStart.IsEnabled = true;
        isRunning = false;
    }

    void btnReset_Clicked(System.Object sender, System.EventArgs e)
    {
        oTimerLogic.Reset();
        lblDisplay.Text = oTimerLogic.GetFormattedString();
    }
}


