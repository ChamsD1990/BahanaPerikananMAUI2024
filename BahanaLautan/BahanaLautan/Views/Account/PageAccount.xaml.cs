using Material.Components.Maui.Platform;
namespace BahanaLautan.Views.Account;

public partial class PageAccount : ContentPage
{
    double density = DeviceDisplay.Current.MainDisplayInfo.Density;
    double widths_ = DeviceDisplay.Current.MainDisplayInfo.Width;
    double height = DeviceDisplay.Current.MainDisplayInfo.Height;
    double widths;
    double heights;
    public PageAccount()
    {
        InitializeComponent();
        widths = widths_ / density;
        heights = height / density;
        OnAppearing();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Hide the action bar
        Shell.SetNavBarIsVisible(this, false);

        // Profiling height of page
        headAccount.HeightRequest = heights * 0.3;
        detailAccount.HeightRequest = heights * 0.6;

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });

        var TitleText = new VerticalStackLayout
        {
            Children =
        {
            new Label
            {
                Text = "",
                FontFamily = "Strande2",
                TextColor = Colors.Black,
                VerticalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.FillAndExpand,
                FontSize = 20,
                Margin = 0,
                Padding = new Thickness(0)
            }
        }
        };

        var titleView = new HorizontalStackLayout
        {
            HeightRequest = 50,
            BackgroundColor = Colors.MediumBlue,
            Children = { TitleText }
        };

        Shell.SetTitleView(this, titleView);
    }

    private void OnFlexLayoutLoaded(object sender, EventArgs e)
    { 
    }
    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue == null)
        {
            // Handle null case
        }
        else
        {
            // Proceed with your logic
        }
    }
    private void TextField_TextChanged(object sender, TextChangedEventArgs e)
    { 
    }
    private void TextField_TrailingIconClicked(object sender, EventArgs e)
    { 
    }
}