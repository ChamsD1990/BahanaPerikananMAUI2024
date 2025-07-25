
using BahanaLautan.Source.Object.Kerja.EstimasiKeberangkatan;
using System.Collections.ObjectModel;

namespace BahanaLautan.Source.Model.Kerja.EstimasiKeberangkatan;

public class ViewModel
{
    public ObservableCollection<Objects> Items { get; set; }
    public ViewModel()
    {
        Items = new ObservableCollection<Objects>
            {
                new Objects { ID = 1, NamaKelompok = "Kelompok A", DetailKelompok = "Detail kelompok A", label1 = "-", label2 = "-" }, 
                // Add more items as needed
            };
    }
}