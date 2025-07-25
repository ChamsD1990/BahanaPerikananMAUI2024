using BahanaLautan.Source.Object.Kerja;
using System.Collections.ObjectModel;

namespace BahanaLautan.Source.Model.Kerja.KebutuhanKerja;

public class ViewModel
{
    public ObservableCollection<Objects> Items { get; set; }
    public ViewModel()
    {
        Items = new ObservableCollection<Objects>
            {
            new Objects { Name = "Kasbon Operasional", ImageSource = "chevron.png" },
            new Objects { Name = "Permintaan Kebutuhan BBM", ImageSource = "chevron.png" },
            new Objects { Name = "Permintaan Es Batu", ImageSource = "chevron.png" },
            new Objects { Name = "Permintaan Bahan Makanan", ImageSource = "chevron.png" },
            };
    }
}