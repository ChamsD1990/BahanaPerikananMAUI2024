using BahanaLautan.Source.Object.Permintaan.PeralatanTangkap.Selesai;

using System.Collections.ObjectModel;

namespace BahanaLautan.Source.Model.Permintaan.PeralatanTangkap.Selesai;

public class ViewModel
{
    public ObservableCollection<Objects> Items { get; set; }

    public ViewModel()
    {
        Items = new ObservableCollection<Objects>
            {
                new Objects {
                    ID = 1,
                    Name = "Form Permintaan Peralatan Tangkap",
                    NamaPengajuan = "Diajukan oleh : 'Nama'",
                    TanggalPengajuan = "Tanggal pengajuan : 01-02-2024 pukul 12:00 WIB", label2 = "-" }, 
                // Add more items as needed
            };
    }
}