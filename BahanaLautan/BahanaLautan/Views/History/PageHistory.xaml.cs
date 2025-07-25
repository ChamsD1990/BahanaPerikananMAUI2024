 
namespace BahanaLautan.Views.History;

public partial class PageHistory : ContentPage
{
    public PageHistory()
    {
        InitializeComponent();
        OnAppearing();
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
                    Text = "History",
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



}
