using BahanaLautan.Source.Object.Permintaan.PermintaanSparepart.Proses;
using System.Collections.ObjectModel;

namespace BahanaLautan.Source.Model.Permintaan.PermintaanSparepart.Proses;

public class ViewModel
{
    public ObservableCollection<Objects> Items { get; set; }

    public ViewModel()
    {
        Items = new ObservableCollection<Objects>
            {
                new Objects { ID = 1, Name = "Form Permintaan Sparepart", Pengajuan = "Diajukan oleh : 'Nama'", Tgl_pengajuan = "Tanggal pengajuan : 01-02-2024 pukul 12:00 WIB", label2 = "-" }, 
                // Add more items as needed
            };
    }
}
 