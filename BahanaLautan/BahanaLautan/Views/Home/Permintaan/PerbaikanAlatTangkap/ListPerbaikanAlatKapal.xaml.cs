using BahanaLautan.Source.Utils.Data.Permintaan.PerbaikanAlatTangkap.Permintaan;
using BahanaLautan.Source.Utils.Data.Permintaan.PerbaikanAlatTangkap.Proses;
using BahanaLautan.Source.Utils.Data.Permintaan.PerbaikanAlatTangkap.Selesai;

namespace BahanaLautan.Views.Home.Permintaan.PerbaikanAlatTangkap;

public partial class ListPerbaikanAlatKapal : ContentPage
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

    VerticalStackLayout v_permintaan = new VerticalStackLayout();
    VerticalStackLayout v_proses = new VerticalStackLayout();
    VerticalStackLayout v_selesai = new VerticalStackLayout();
     
    double width_form;
    double height_form = 50;

    bool isOpenPermintaan = false;
    bool isOpenProses = false;
    bool isOpenSelesai = false;
    public ListPerbaikanAlatKapal()
	{
		InitializeComponent();
        Shell.SetTabBarIsVisible(this, false);
        AddToolbarItem();
        OnAppearing();
        widths = widths_ / density;
        InitAppbar();
    }

    private void AddToolbarItem()
    {
        var toolbarItem = new ToolbarItem
        {
            Text = "Action",
            IconImageSource = "Resources/Images/add.png", // Optional: Set an icon
            Order = ToolbarItemOrder.Primary,
            Priority = 0
        };
        toolbarItem.Command = new Command(OnActionClicked);
        ToolbarItems.Add(toolbarItem);
    }

    private async void OnActionClicked()
    {
        await Navigation.PushAsync(new FormPermintaanAlatKapal());
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
                        Text = "Form Permintaan Perbaikan",
                        FontFamily = "Strande2",
                        TextColor = Colors.Black,
                        VerticalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontSize = 16,
                        Margin = new Thickness(0, 5, 0, 0),
                        Padding = new Thickness(0)
                    },
                    new Label
                    {
                        Text = "Alat Tangkap",
                        FontFamily = "Strande2",
                        TextColor = Colors.Black,
                        VerticalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontSize = 12, 
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

    public void InitAppbar()
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
            WidthRequest = (widths * 0.7) - 15
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
        initialTabView(div_tab);

        Content = new StackLayout
        {
            Children = { div_search, div_tab, content_page }
        };
    }

    public void initialTabView(HorizontalStackLayout frame)
    {
        var layout = new HorizontalStackLayout
        {
            Padding = 0,
            HorizontalOptions = LayoutOptions.Fill
        };

        var grid = new Grid
        {
            ColumnSpacing = 5, // Horizontal space between columns
            HorizontalOptions = LayoutOptions.Fill // Ensure grid takes available width
        };

        // Define three equal columns
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

        // Create buttons
        btn_permintaan.Text = "Permintaan";
        btn_permintaan.CornerRadius = 0;
        btn_permintaan.BackgroundColor = Colors.MediumBlue;
        btn_permintaan.TextColor = Colors.White;
        btn_permintaan.HorizontalOptions = LayoutOptions.Fill; // Fill the cell
        btn_permintaan.MinimumWidthRequest = (widths - 30) / 3; // Minimum width for btn_permintaan
        btn_permintaan.Clicked += HandlePermintaanButtonClick;

        btn_proses.Text = "Proses";
        btn_proses.CornerRadius = 0;
        btn_proses.BackgroundColor = Colors.Transparent;
        btn_proses.TextColor = Colors.Gray;
        btn_proses.HorizontalOptions = LayoutOptions.Fill; // Fill the cell
        btn_proses.MinimumWidthRequest = (widths - 30) / 3; // Minimum width for btn_proses
        btn_proses.Clicked += OnProses;

        btn_selesai.Text = "Selesai";
        btn_selesai.CornerRadius = 0;
        btn_selesai.BackgroundColor = Colors.Transparent;
        btn_selesai.TextColor = Colors.Gray;
        btn_selesai.HorizontalOptions = LayoutOptions.Fill; // Fill the cell
        btn_selesai.MinimumWidthRequest = (widths - 30) / 3; // Minimum width for btn_selesai
        btn_selesai.Clicked += OnSelesai;

        // Add buttons to the grid
        grid.Children.Add(btn_permintaan);
        grid.Children.Add(btn_proses);
        grid.Children.Add(btn_selesai);

        // Set row and column for each element
        Grid.SetColumn(btn_permintaan, 0);
        Grid.SetColumn(btn_proses, 1);
        Grid.SetColumn(btn_selesai, 2);

        // Add grid to the layout
        layout.Children.Add(grid);

        // Set margins and paddings for the frame
        frame.Margin = new Thickness(10, 0);
        frame.Padding = 0;
        frame.Children.Add(layout);
        frame.HeightRequest = 50; // Set a fixed height for the frame
    }

    public void initContentPage(StackLayout views)
    {
        loadPermintaan();
        loadProses();
        loadSelesai();
        views.Children.Add(v_permintaan);
        views.Children.Add(v_proses);
        views.Children.Add(v_selesai);
    }

    public void loadPermintaan()
    {
        v_permintaan.HeightRequest = height;
        v_permintaan.WidthRequest = widths;
        v_permintaan.Padding = new Thickness(0);
        v_permintaan.IsVisible = isOpenPermintaan;
        VerticalStackLayout n_permintaan = new VerticalStackLayout();
        var pages = new ScrollView
        {
            Content = InitialListPermintaanPerbaikanKapal(this)
        };
        n_permintaan.Children.Add(pages);
        n_permintaan.HeightRequest = height;
        n_permintaan.WidthRequest = widths;
        n_permintaan.Padding = new Thickness(0);
        v_permintaan.Children.Add(n_permintaan);
    }
    public View InitialListPermintaanPerbaikanKapal(ContentPage myContentPage)
    {
        ListPermintaan ListProses = new ListPermintaan(myContentPage, widths);
        return ListProses.LoadListPermintaan(); // Call LoadListPermintaan to get the View
    }

    public void loadProses()
    {
        v_proses.VerticalOptions = LayoutOptions.FillAndExpand;
        v_proses.HorizontalOptions = LayoutOptions.FillAndExpand;
        VerticalStackLayout n_proses = new VerticalStackLayout();
        var pages = new ScrollView
        {
            Content = InitialListProsesPerbaikanKapal(this)
        };
        n_proses.Children.Add(pages);
        n_proses.WidthRequest = height * 0.8;
        v_proses.Children.Add(n_proses);
        v_proses.IsVisible = true;
    }
    public View InitialListProsesPerbaikanKapal(ContentPage myContentPage)
    {
        ListProses ListProses = new ListProses(myContentPage, widths);
        return ListProses.LoadListProses(); // Call LoadListPermintaan to get the View
    }

    public void loadSelesai()
    {
        v_selesai.VerticalOptions = LayoutOptions.FillAndExpand;
        v_selesai.HorizontalOptions = LayoutOptions.FillAndExpand;
        VerticalStackLayout n_selesai = new VerticalStackLayout();
        var pages = new ScrollView
        {
            Content = InitialListSeleksiPerbaikanKapal(this)
        };
        n_selesai.Children.Add(pages);
        n_selesai.WidthRequest = height * 0.8;
        v_selesai.Children.Add(n_selesai);
        v_selesai.IsVisible = isOpenSelesai;
    }
    public View InitialListSeleksiPerbaikanKapal(ContentPage myContentPage)
    {
        ListSelesai ListSelesai = new ListSelesai(myContentPage, widths);
        return ListSelesai.LoadListSelesai(); // Call LoadListPermintaan to get the View
    }

    public void handleResetPermintaan()
    {
        this.isOpenPermintaan = true;
    }

    private void HandlePermintaanButtonClick(object sender, EventArgs e)
    {
        // Change the button's background color
        handleResetPermintaan();
        var button = sender as Button;
        button.BackgroundColor = Colors.MediumBlue;
        button.TextColor = Colors.White;
        this.v_permintaan.IsVisible = isOpenPermintaan;

        btn_proses.BackgroundColor = Colors.Transparent;
        btn_proses.TextColor = Colors.Gray;
        this.v_proses.IsVisible = isOpenProses;

        btn_selesai.BackgroundColor = Colors.Transparent;
        btn_selesai.TextColor = Colors.Gray;
        this.isOpenSelesai = false;
        this.v_selesai.IsVisible = isOpenSelesai;
    }

    private void OnProses(object sender, EventArgs e)
    {
        isOpenProses = true;
        // Change the button's background color
        var button = sender as Button;
        btn_permintaan.BackgroundColor = Colors.Transparent;
        btn_permintaan.TextColor = Colors.Gray;
        this.isOpenPermintaan = false;
        this.v_permintaan.IsVisible = isOpenPermintaan;

        button.BackgroundColor = Colors.MediumBlue;
        button.TextColor = Colors.White;
        this.v_proses.IsVisible = true;

        btn_selesai.BackgroundColor = Colors.Transparent;
        btn_selesai.TextColor = Colors.Gray;
        this.isOpenSelesai = false;
        this.v_selesai.IsVisible = isOpenSelesai;
    }

    private void OnSelesai(object sender, EventArgs e)
    {
        // Change the button's background color
        var button = sender as Button;
        btn_permintaan.BackgroundColor = Colors.Transparent;
        btn_permintaan.TextColor = Colors.Gray;
        this.isOpenPermintaan = false;
        this.v_permintaan.IsVisible = isOpenPermintaan;
        btn_proses.BackgroundColor = Colors.Transparent;
        btn_proses.TextColor = Colors.Gray;
        this.isOpenProses = false;
        this.v_proses.IsVisible = isOpenProses;
        button.BackgroundColor = Colors.MediumBlue;
        button.TextColor = Colors.White;
        this.isOpenProses = true;
        this.v_selesai.IsVisible = isOpenProses;
    }

}