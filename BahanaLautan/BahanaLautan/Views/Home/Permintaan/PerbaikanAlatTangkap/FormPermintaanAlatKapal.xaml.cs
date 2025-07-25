namespace BahanaLautan.Views.Home.Permintaan.PerbaikanAlatTangkap;

public partial class FormPermintaanAlatKapal : ContentPage
{
    public FormPermintaanAlatKapal()
    {
        InitializeComponent(); OnAppearing();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
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
                        Text = "Form Permintaan Perbaikan",
                        FontFamily = "Strande2",
                        TextColor = Colors.Black,
                        VerticalTextAlignment = TextAlignment.Start,
                        HeightRequest = 20,
                        FontSize = 15,
                        Margin = 0,
                        Padding = new Thickness(0)
                    },
                    new Label
                    {
                        Text = "Alat Kapal",
                        FontFamily = "Strande2",
                        TextColor = Colors.Black,
                        VerticalTextAlignment = TextAlignment.Start,
                        HeightRequest = 20,
                        FontSize = 15,
                        Margin = 0,
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
                if (pages[i] is ListPerbaikanAlatKapal)
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


    public void OnTambahCicked(object sender, EventArgs e)
    {

    }
    public void OnListPerbaikan(object sender, EventArgs e)
    {

    }

    public void LoadPerbaikan()
    {

    }

    public void SavePermintaan()
    {

    }

}