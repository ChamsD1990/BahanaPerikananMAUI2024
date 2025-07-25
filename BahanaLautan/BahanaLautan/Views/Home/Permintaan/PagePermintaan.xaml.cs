using BahanaLautan.Source.Model;
using BahanaLautan.Views.Home.Permintaan.AturKelompokKerja;
using BahanaLautan.Views.Home.Permintaan.KasbonPribadi;
using BahanaLautan.Views.Home.Permintaan.PeralatanTangkap;
using BahanaLautan.Views.Home.Permintaan.PerbaikanAlatTangkap;  
using BahanaLautan.Views.Home.Permintaan.PerbaikanKapal;
using BahanaLautan.Views.Home.Permintaan.PermintaanSparepart;

namespace BahanaLautan.Views.Home.Permintaan;

public partial class PagePermintaan : ContentPage
{
    double density = DeviceDisplay.Current.MainDisplayInfo.Density;
    double widths_ = DeviceDisplay.Current.MainDisplayInfo.Width;
    double height = DeviceDisplay.Current.MainDisplayInfo.Height;
    double widths;
    public PagePermintaan()
	{
        widths = widths_ / density;
        InitTitle();
        InitializeComponent();
    }

    public void InitTitle()
    {
        //Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });

        var backButton = new ImageButton();
        backButton.Source = "Resources/Images/arrow_left.png";
        backButton.WidthRequest = 20;
        backButton.HeightRequest = 20;
        backButton.BackgroundColor = Colors.Transparent;
        backButton.Margin = new Thickness(0, 10, 10, 10);
        backButton.Clicked += BackButtons;
        var TitleText = new VerticalStackLayout
        {
            Children =
            {
                new Label
                {
                    Text = "Dashboard Permintaan",
                    FontFamily = "Strande2",
                    TextColor = Colors.Black,
                    VerticalTextAlignment = TextAlignment.Center,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    FontSize = 22,
                    Margin = new Thickness(0, 5),
                    Padding = new Thickness(0)
                }
            }
        };
        var titleView = new HorizontalStackLayout
        {
            HeightRequest = 50,
            Children =
            {
                //backButton,
                TitleText
            }
        };
        Shell.SetTitleView(this, titleView);
    }

    public async void BackButtons(object sender, EventArgs e)
    {
        try
        {
            var pages = Navigation.NavigationStack;

            for (int i = pages.Count - 1; i >= 0; i--)
            {
                if (pages[i] is PageHome)
                {
                    while (Navigation.NavigationStack.Last() != pages[i])
                    {
                        await Navigation.PopAsync();
                    }
                    break; // Exit the loop once we found the page
                }
            }
        }
        catch (Exception ex)
        {
            // Log the exception or display an error message
            Console.WriteLine($"Error navigating back: {ex.Message}");
        }
    }

    private async void getEventMenu(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is ModelMenuPermintaan tappedItem)
        {
            if ((tappedItem.BoxID) == "1")
            {
                await Shell.Current.GoToAsync(nameof(FormKelompokKerja));
            }
            else if ((tappedItem.BoxID) == "2")
            {
                await Shell.Current.GoToAsync(nameof(ListPerbaikanKapal));
            }
            else if ((tappedItem.BoxID) == "3")
            {
                await Shell.Current.GoToAsync(nameof(ListPerbaikanAlatKapal));
            }
            else if ((tappedItem.BoxID) == "4")
            {
                await Shell.Current.GoToAsync(nameof(ListPeralatanTangkap));
            }
            else if ((tappedItem.BoxID) == "5")
            {
                await Shell.Current.GoToAsync(nameof(ListPermintaanSparepart));
            }
            else if ((tappedItem.BoxID) == "6")
            {
                await Shell.Current.GoToAsync(nameof(ListKasbonPribadi));
            }
        } 
    }
    private void SfEffectsView_AnimationCompleted(object sender, EventArgs e)
    { 
    }
}