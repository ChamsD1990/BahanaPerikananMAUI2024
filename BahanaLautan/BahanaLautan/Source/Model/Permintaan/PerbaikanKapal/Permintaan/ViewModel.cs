using BahanaLautan.Source.Object.Permintaan.PerbaikanKapal.Permintaan;
using System.Collections.ObjectModel;

namespace BahanaLautan.Source.Model.Permintaan.PerbaikanKapal.Permintaan;

public class ViewModel : ContentPage
{
    public ObservableCollection<Objects> Items { get; set; }
    public ViewModel()
    {
        Items = new ObservableCollection<Objects>
            {
                new Objects {
                    ID = 1,
                    Name = "Perbaikan Kapal",
                    NamaPengajuan = "Diajukan oleh : 'Nama'",
                    TanggalPengajuan = "Tanggal pengajuan : 01-02-2024 pukul 12:00 WIB",  
                    label1 = "-",
                    label2 = "-" },
            };
    }
}