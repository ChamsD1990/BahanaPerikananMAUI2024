using BahanaLautan.Source.Model.Permintaan.KasbonPribadi.Kasbon;
namespace BahanaLautan.Source.Utils.Data.Permintaan.KasbonPribadi.Kasbon;

public class ListKasbon
{
    private ContentPage page;
    double widths;
    public ListKasbon(ContentPage page, double widths)
    {
        this.page = page;
        this.widths = widths;
    }

    public View LoadListkasbonPribadi()
    {

        // Create the ViewModel
        var viewModel = new ViewModel();

        // Set the BindingContext of the page
        page.BindingContext = viewModel;

        // Create and return a ListView
        var listView = new ListView
        {
            //itemsize
            RowHeight = 200,
            ItemsSource = viewModel.Items,
            ItemTemplate = new DataTemplate(() =>
            {
                // Define the template for the ListView item
                var itemLayout = new StackLayout
                {
                    Padding = 0
                };
                var label_permintaan = new Frame
                {
                    Content = new Label
                    {
                        Text = "Permintaan",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        BackgroundColor = Colors.Transparent
                    },
                    BorderColor = Colors.Gray,
                    CornerRadius = 2,
                    Padding = new Thickness(0),
                    HasShadow = true,
                    WidthRequest = widths * 0.4,
                    BackgroundColor = Colors.Transparent
                };
                var label_box = new HorizontalStackLayout();
                label_box.Children.Add(label_permintaan);
                label_box.HorizontalOptions = LayoutOptions.EndAndExpand;
                label_box.HeightRequest = 25;

                var Name = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
                Name.SetBinding(Label.TextProperty, "Name");

                var other_label1 = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
                other_label1.SetBinding(Label.TextProperty, "label1");

                var NamaPengajuan = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
                NamaPengajuan.SetBinding(Label.TextProperty, "NamaPengajuan");

                var TanggalPengajuan = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
                TanggalPengajuan.SetBinding(Label.TextProperty, "TanggalPengajuan");

                var other_label2 = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
                other_label1.SetBinding(Label.TextProperty, "label2");


                itemLayout.Children.Add(label_box);
                itemLayout.Children.Add(Name);
                itemLayout.Children.Add(other_label1);
                itemLayout.Children.Add(NamaPengajuan);
                itemLayout.Children.Add(TanggalPengajuan);
                itemLayout.Children.Add(other_label2);

                var frame = new Frame
                {
                    Content = itemLayout,
                    BorderColor = Colors.Black,
                    CornerRadius = 5,
                    WidthRequest = widths * 0.9,
                    HeightRequest = 180
                };

                return new ViewCell { View = frame }; // Return the frame wrapped in a ViewCell
            })
        };

        return listView;
    }

}

