using BahanaLautan.Source.Object.Permintaan.AturKelompokKerja.Kelompok;
using System.Collections.ObjectModel;

namespace BahanaLautan.Source.Model.Permintaan.AturKelompokKerja;

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
