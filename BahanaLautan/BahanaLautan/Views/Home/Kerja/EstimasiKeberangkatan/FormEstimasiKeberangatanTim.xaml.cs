using BahanaLautan.Source.Object.Kerja.EstimasiKeberangkatan;
using System.Collections.ObjectModel;

namespace BahanaLautan.Views.Home.Kerja.EstimasiKeberangkatan;

public partial class FormEstimasiKeberangatanTim : ContentPage
{
    double density = DeviceDisplay.Current.MainDisplayInfo.Density;
    double widths_ = DeviceDisplay.Current.MainDisplayInfo.Width;
    double height = DeviceDisplay.Current.MainDisplayInfo.Height;
    double widths;
    public ObservableCollection<Anggota> AnggotaList { get; set; }
    public FormEstimasiKeberangatanTim()
	{
		InitializeComponent();
        widths = widths_ / density;
        InitTitle();
        //CreateLayout();
        AnggotaList = new ObservableCollection<Anggota>
        {
            new Anggota { Name = "Ketua", Role = "Ratna, Dani" },
            new Anggota { Name = "ABK", Role = "Sakmad, Agus, Arif" },
            // Add more members as needed
        };
        ListAnggota.ItemsSource = AnggotaList;
        ListAnggota.ItemTapped += ListAnggota_ItemTapped;
    }


    private void ListAnggota_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item != null)
        {
            var selectedAnggota = (Anggota)e.Item;
            // Handle the selection (e.g., navigate to a detail page)
        }
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
                    Text = "Form Keberangkatan Team",
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

    public async void OnInfoListAnggota(object sender, EventArgs e)
    {
        DisplayAlert("Informasi", "Data List Anggota Dapat Dari Form Atur Kelompok", "OK");
    }



}