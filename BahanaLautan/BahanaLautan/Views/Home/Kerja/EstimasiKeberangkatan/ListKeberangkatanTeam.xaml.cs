using BahanaLautan.Source.Utils.Data.Kerja.EstimasiKeberangkatan;

namespace BahanaLautan.Views.Home.Kerja.EstimasiKeberangkatan;

public partial class ListKeberangkatanTeam : ContentPage
{
    double density = DeviceDisplay.Current.MainDisplayInfo.Density;
    double widths_ = DeviceDisplay.Current.MainDisplayInfo.Width;
    double height = DeviceDisplay.Current.MainDisplayInfo.Height;
    double widths;

    Frame f_permintaan = new Frame();
    Frame f_proses = new Frame();
    Frame f_selesai = new Frame();

    Button btn_permintaan = new Button();
    Button btn_proses = new Button();
    Button btn_selesai = new Button();

    VerticalStackLayout v_kelompok = new VerticalStackLayout();

    // Determine the width for the search form
    double width_form;
    double height_form = 50;

    bool isOpenPermintaan = false;
    bool isOpenProses = false;
    bool isOpenSelesai = false;
    public ListKeberangkatanTeam()
	{
		InitializeComponent();
        widths = widths_ / density;
        AddToolbarItem();
        OnAppearing();
        BodyPage();
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
                        Text = "List Keberangkatan Team",
                        FontFamily = "Strande2",
                        TextColor = Colors.Black,
                        VerticalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontSize = 24,
                        Margin = 0,
                        Padding = new Thickness(0, 10, 0, 0)
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
     
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });
        InitTitle();
    }

    private void AddToolbarItem()
    {
        // Create a new ToolbarItem
        var toolbarItem = new ToolbarItem
        {
            Text = "Action",
            IconImageSource = "Resources/Images/add.png", // Optional: Set an icon
            Order = ToolbarItemOrder.Primary,
            Priority = 0
        };

        // Set the command for the ToolbarItem
        toolbarItem.Command = new Command(OnActionClicked);

        // Add the ToolbarItem to the page's ToolbarItems collection
        ToolbarItems.Add(toolbarItem);
    }

    private async void OnActionClicked()
    {
        //await Navigation.PushAsync(new FormEstimasiKeberangatanTim());
    }

    public void BodyPage()
    {
        this.isOpenPermintaan = true;
        this.isOpenProses = false;
        this.isOpenSelesai = false;
        width_form = (widths - (widths * 0.7) - 15);
        var image = new Image
        {
            Source = "Resources/Images/find.png",
            HeightRequest = 20,
            WidthRequest = 20,
        };
        var entry = new Entry
        {
            Placeholder = "Enter your text",
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            WidthRequest = (widths * 0.7) - 15
        };
        var form_search = new HorizontalStackLayout
        {
            Children = { image, entry },
            Spacing = 10,
            HeightRequest = 50,
            WidthRequest = (widths * 0.75)
        };

        var frame = new Frame
        {
            Content = form_search,
            BorderColor = Colors.Black,
            BackgroundColor = Colors.Beige,
            CornerRadius = 10,
            Padding = new Thickness(5),
            //WidthRequest = width_form,
            HeightRequest = height_form // Set a height for the Frame
        };

        var imgButton = new ImageButton
        {
            Source = "Resources/Images/find.png",
            HeightRequest = 50,
            WidthRequest = 50,
            Padding = 10,
            BackgroundColor = Colors.Transparent,
        };
        imgButton.Clicked += (sender, args) =>
        {
            // Action for image button click
        };

        var borderedFrame = new Frame
        {
            Content = imgButton,
            BorderColor = Colors.Gray,
            CornerRadius = 5,
            Padding = 0,
            Margin = 5,
            HasShadow = true,
        };

        var btn_search = new HorizontalStackLayout
        {
            Children = { borderedFrame },
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };

        var div_search = new HorizontalStackLayout
        {
            Children = { frame, btn_search },
            Padding = new Thickness(10),
            HorizontalOptions = LayoutOptions.FillAndExpand,
            HeightRequest = 70
        };

        var content_page = new StackLayout();
        content_page.HeightRequest = height * 0.8;
        content_page.WidthRequest = widths * 0.8;
        initContentPage(content_page);

        var div_tab = new HorizontalStackLayout();
        //initialTabView(div_tab);

        Content = new StackLayout
        {
            Children = { div_search, div_tab, content_page }
        };
    }

    public void initContentPage(StackLayout views)
    {
        loadKelompok();
        views.Add(v_kelompok);
    }

    public void loadKelompok()
    {
        v_kelompok.VerticalOptions = LayoutOptions.FillAndExpand;
        v_kelompok.HorizontalOptions = LayoutOptions.FillAndExpand;
        VerticalStackLayout n_proses = new VerticalStackLayout();
        var pages = new ScrollView
        {
            Content = InitialListProsesPerbaikanKapal(this)
        };
        n_proses.Children.Add(pages);
        n_proses.WidthRequest = height * 0.8;
        v_kelompok.Children.Add(n_proses);
        v_kelompok.IsVisible = true;
    }

    public View InitialListProsesPerbaikanKapal(ContentPage myContentPage)
    {
        ListKelompok ListProses = new ListKelompok(myContentPage, widths);
        return ListProses.LoadListKelompok(); // Call LoadListPermintaan to get the View
    }


}