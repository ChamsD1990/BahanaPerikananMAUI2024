using BahanaLautan.Source.Model.Kerja;
using System.Diagnostics;

namespace BahanaLautan.Views.Home.Kerja.DaftarKebutuhanKerja;

public partial class ListDaftarKebutuhanKerja : ContentPage
{
	public ListDaftarKebutuhanKerja()
	{
		InitializeComponent();
        InitTitle();
    }
    private void SfEffectsView_AnimationCompleted(object sender, EventArgs e)
    {
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
                    Text = "Daftar Kebutuhan Kerja",
                    FontFamily = "Strande2",
                    TextColor = Colors.Black,
                    VerticalTextAlignment = TextAlignment.Center,
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
                if (pages[i] is PageKerja)
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
        if (sender is Frame frame && frame.BindingContext is ModelMenuKebutuhanKerja tappedItem)
        {
            if ((tappedItem.BoxID) == "1")
            {
                await Shell.Current.GoToAsync(nameof(FormKasbonOperational));
            }
            else if ((tappedItem.BoxID) == "2")
            {
                Debug.WriteLine(tappedItem.BoxID);
                await Shell.Current.GoToAsync(nameof(FormPermintaanKebutuhanBBM));
            }
            else if ((tappedItem.BoxID) == "3")
            {
                await Shell.Current.GoToAsync(nameof(FormPermintaanEsbatu));
            }
            else if ((tappedItem.BoxID) == "4")
            {
                await Shell.Current.GoToAsync(nameof(FormPermintaanBahanMakanan));
            }
        }
    }
}