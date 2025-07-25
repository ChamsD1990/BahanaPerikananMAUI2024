using BahanaLautan.Source.Utils.Data.Permintaan.AturKelompokKerja;
using BahanaLautan.Views.Home.Permintaan;

namespace BahanaLautan.Views.Home.AturKelompokKerja;

public partial class PageKelompokKerja : ContentPage
{
    double density = DeviceDisplay.Current.MainDisplayInfo.Density;
    double widths_ = DeviceDisplay.Current.MainDisplayInfo.Width;
    double height = DeviceDisplay.Current.MainDisplayInfo.Height;
    double widths;
    double height_form = 50;
    double width_form;
    VerticalStackLayout v_kelompokkerja = new VerticalStackLayout();

    public PageKelompokKerja()
    {
        InitializeComponent();
        widths = widths_ / density;
        OnAppearing();
        AddToolbarItem();
        InitAppbar();
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
        //await Navigation.PushAsync(new FormKelompokKerja());
    }

    // 
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
                        Text = "List Kelompok Kerja",
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


    public void InitAppbar()
    {
        width_form = (widths - (widths * 0.7));
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
            WidthRequest = (widths * 0.7)
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


        Content = new StackLayout
        {
            Children = { div_search, content_page }
        };
    }

    public void initContentPage(StackLayout views)
    {
        LoadKelompokKerja();
        views.Children.Add(v_kelompokkerja);

    }
    // load content tabs
    public void LoadKelompokKerja()
    {
        v_kelompokkerja.HeightRequest = height;
        v_kelompokkerja.WidthRequest = widths;
        v_kelompokkerja.Padding = new Thickness(0);
        VerticalStackLayout n_kelompokkerja = new VerticalStackLayout();
        var pages = new ScrollView
        {
            Content = InitialListPermintaanPerbaikanKapal(this)
        };
        n_kelompokkerja.Children.Add(pages);
        n_kelompokkerja.HeightRequest = height;
        n_kelompokkerja.WidthRequest = widths;
        n_kelompokkerja.Padding = new Thickness(0);
        v_kelompokkerja.Children.Add(n_kelompokkerja);
    }
    public View InitialListPermintaanPerbaikanKapal(ContentPage myContentPage)
    {
        ListKelompokKerja listKelompokKerja = new ListKelompokKerja(myContentPage, widths);
        return listKelompokKerja.LoadListKelompokKerja(); // Call LoadListPermintaan to get the View
    }
}