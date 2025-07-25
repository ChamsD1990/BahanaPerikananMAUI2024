namespace BahanaLautan.Views.Home.Permintaan.AturKelompokKerja;

public partial class FormKelompokKerja : ContentPage
{
    double density = DeviceDisplay.Current.MainDisplayInfo.Density;
    double widths_ = DeviceDisplay.Current.MainDisplayInfo.Width;
    double height = DeviceDisplay.Current.MainDisplayInfo.Height;
    double widths;

    public FormKelompokKerja()
	{
		InitializeComponent();
        InitTitle(); 
    }
     
    public void InitTitle()
    {
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });

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
                        Text = "Form Atur Kelompok Kerja",
                        FontFamily = "Strande2",
                        TextColor = Colors.Black,
                        VerticalTextAlignment = TextAlignment.Start,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontSize = 20,
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
                    backButton,
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
                if (pages[i] is PagePermintaan)
                {
                    while (Navigation.NavigationStack.Last() != pages[i])
                    {
                        await Navigation.PopAsync();
                    }
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error navigating back: {ex.Message}");
        }
    }



}