using System.Collections.ObjectModel;

namespace BahanaLautan.Source.Model.Permintaan;

public class ModelActionBar
{
    public ObservableCollection<string> Items { get; set; }

    public ModelActionBar()
    {
        Items = new ObservableCollection<string>
        {
            "Item 1",
            "Item 2"
            // Add more items as needed
        };
    }
}