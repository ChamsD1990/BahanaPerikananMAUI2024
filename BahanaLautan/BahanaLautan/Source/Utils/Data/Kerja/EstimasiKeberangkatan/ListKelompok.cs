using BahanaLautan.Source.Model.Kerja.EstimasiKeberangkatan;

namespace BahanaLautan.Source.Utils.Data.Kerja.EstimasiKeberangkatan;

public class ListKelompok
{
    private ContentPage page;
    double widths;

    public ListKelompok(ContentPage page, double widths)
    {
        this.page = page;
        this.widths = widths;
    }

    public View LoadListKelompok()
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
                var itemLayout = new StackLayout
                {
                    Padding = 0
                };
                var label_permintaan = new Frame
                {
                    Content = new Label
                    {
                        Text = "Kasbon",
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


                var nameLabel = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                };
                nameLabel.SetBinding(Label.TextProperty, "NamaKelompok");

                var other_label = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                };
                other_label.SetBinding(Label.TextProperty, "label1");

                var descriptionLabel = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
                descriptionLabel.SetBinding(Label.TextProperty, "DetailKelompok");

                var other_label1 = new Label
                {
                    FontSize = 12,
                };
                other_label1.SetBinding(Label.TextProperty, "label2");

                itemLayout.Children.Add(label_box);
                itemLayout.Children.Add(nameLabel);
                itemLayout.Children.Add(other_label);
                itemLayout.Children.Add(descriptionLabel);
                itemLayout.Children.Add(other_label1);
                var frame = new Frame
                {
                    Content = itemLayout,
                    BorderColor = Colors.Black,
                    CornerRadius = 5,
                    WidthRequest = widths * 0.8,
                    HeightRequest = 180,
                    Padding = new Thickness(5)
                };

                return new ViewCell { View = frame }; // Return the frame wrapped in a ViewCell
            })
        };

        return listView;
    }

}
