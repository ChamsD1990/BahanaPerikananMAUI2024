using BahanaLautan.Source.Object.Permintaan.KasbonPribadi.Kasbon;
using System.Collections.ObjectModel;

namespace BahanaLautan.Source.Model.Permintaan.KasbonPribadi.Kasbon;

public class ViewModel
{
    public ObservableCollection<Objects> Items { get; set; }
    public ViewModel()
    {
        Items = new ObservableCollection<Objects>
            {
                new Objects {
                    ID = 1,
                    Name = "Judul Kasbon",
                    NamaPengajuan = "Kasbon untuk pembuatan kartu debit",
                    TanggalPengajuan = "Tanggal Pengajuan : 01-03-2022 pukul 13:00 WIB",
                    label1 = "-", label2 = "-" },
            };
    }
} 