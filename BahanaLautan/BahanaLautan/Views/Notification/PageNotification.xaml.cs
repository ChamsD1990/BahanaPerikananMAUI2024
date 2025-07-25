using BahanaLautan.Source.Model.Notifications;
using BahanaLautan.Source.Object.Notifications;
using System.Windows.Input;

namespace BahanaLautan.Views.Notification;

public partial class PageNotification : ContentPage
{
    double density = DeviceDisplay.Current.MainDisplayInfo.Density;
    double widths_ = DeviceDisplay.Current.MainDisplayInfo.Width;
    double height = DeviceDisplay.Current.MainDisplayInfo.Height;
    double widths;
    public ICommand DeleteCommand { get; set; }
    public PageNotification()
    {
        InitializeComponent();
        widths = widths_ / density;
        OnAppearing(); 
        BindingContext = new NotificationViewModel();
        DeleteCommand = new Command<ItemNotifications>(OnDelete);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var TitleText = new VerticalStackLayout
        {
            Children =
            {
                new Label
                {
                    Text = "Notifications",
                    FontFamily = "Strande2",
                    TextColor = Colors.Black,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = 20,
                    Margin = 0,
                    Padding = new Thickness(0, 10, 0, 0)
                }
            },
            HorizontalOptions = LayoutOptions.CenterAndExpand,
        };
        var titleView = new HorizontalStackLayout
        {
            HeightRequest = 50,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Colors.White,
            Children = { TitleText }
        };
        Shell.SetTitleView(this, titleView);
    }

    private void OnItemTapped(object sender, ItemTappedEventArgs e)
    { 
        overlay.IsVisible = true; 
    }

    private void OnDelete(ItemNotifications item)
    { 
    }

}