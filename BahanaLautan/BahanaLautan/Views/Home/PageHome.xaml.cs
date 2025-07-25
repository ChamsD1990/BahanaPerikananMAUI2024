using BahanaLautan.Source.Model;
using BahanaLautan.Views.Home.Kerja;
using BahanaLautan.Views.Home.Permintaan;
namespace BahanaLautan.Views.Home;

public partial class PageHome : ContentPage
{
	public PageHome()
	{
		InitializeComponent();
    }
    private async void getEventMenu(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is ModelMenu tappedItem)
        {
            if ((tappedItem.BoxID) == "1")
            {
                await Shell.Current.GoToAsync(nameof(PagePermintaan));
            }
            else
            if ((tappedItem.BoxID) == "2")
            {
                await Shell.Current.GoToAsync(nameof(PageKerja));
            }
        }
    }

    // Define the AnimationCompleted event handler
    private void SfEffectsView_AnimationCompleted(object sender, EventArgs e)
    {
        // Handle animation completion logic here
        //DisplayAlert("Animation Completed", "The animation has completed.", "OK");
    }
}