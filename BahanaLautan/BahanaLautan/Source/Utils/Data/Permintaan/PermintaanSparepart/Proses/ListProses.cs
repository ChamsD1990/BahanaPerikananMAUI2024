using BahanaLautan.Source.Model.Permintaan.PermintaanSparepart.Proses;

namespace BahanaLautan.Source.Utils.Data.Permintaan.PermintaanSparepart.Proses;

public class ListProses
{
    private ContentPage page;
    double widths;

    public ListProses(ContentPage page, double widths)
    {
        this.page = page;
        this.widths = widths;
    }

    public View LoadListProses()
    {
        var viewModel = new ViewModel();

        page.BindingContext = viewModel;

        var listView = new ListView
        { 
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
                        Text = "Proses",
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
                    FontSize = 16, 
                    FontAttributes = FontAttributes.Bold
                };
                nameLabel.SetBinding(Label.TextProperty, "Name");

                var Pengajuan = new Label
                {
                    FontSize = 12,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                };
                Pengajuan.SetBinding(Label.TextProperty, "Pengajuan");

                var Tgl_pengajuan = new Label
                {
                    FontSize = 12
                };
                Tgl_pengajuan.SetBinding(Label.TextProperty, "Tgl_pengajuan");

                var other_label1 = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
                other_label1.SetBinding(Label.TextProperty, "label2");

                var other_label2 = new Label
                {
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                };
                other_label2.SetBinding(Label.TextProperty, "label2");

                itemLayout.Children.Add(label_box);
                itemLayout.Children.Add(nameLabel);
                itemLayout.Children.Add(other_label1);
                itemLayout.Children.Add(Pengajuan);
                itemLayout.Children.Add(Tgl_pengajuan);
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