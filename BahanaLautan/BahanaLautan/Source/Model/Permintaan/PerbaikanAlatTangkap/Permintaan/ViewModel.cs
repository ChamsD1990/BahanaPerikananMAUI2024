using BahanaLautan.Source.Object.Permintaan.PerbaikanAlatTangkap.Permintaan;

using System.Collections.ObjectModel;

namespace BahanaLautan.Source.Model.Permintaan.PerbaikanAlatTangkap.Permintaan;

public class ViewModel
{
    public ObservableCollection<Objects> Items { get; set; }

    public ViewModel()
    {
        Items = new ObservableCollection<Objects>
            {
                new Objects { 
                    ID = 1, Name = "Form Permintaan Perbaikan Alat Tangkap", 
                    Pengajuan = "Diajukan oleh : 'Nama'", Tgl_pengajuan = "Tanggal pengajuan : 01-02-2024 pukul 12:00 WIB", label2 = "-" }, 
                // Add more items as needed
            };
    }
}