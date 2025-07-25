using BahanaLautan.Source.Model;
using System.Collections.ObjectModel;

namespace BahanaLautan.Source.Repository;

public class MenuRepository : ContentPage
{
    public ObservableCollection<ModelMenu> BoxItems { get; set; }

    public MenuRepository()
    {
        BoxItems = new ObservableCollection<ModelMenu>
            {
                new ModelMenu("1", "Permintaan", "Resources/Images/request.png"),
                new ModelMenu("2", "Kerja", "Resources/Images/company.png"),
                new ModelMenu("3", "Otorisasi", "Resources/Images/verification.png"),
                new ModelMenu("4", "Realisasi", "Resources/Images/realization.png"),
                new ModelMenu("5", "Laporan", "Resources/Images/report.png"),
                new ModelMenu("6", "Informasi", "Resources/Images/attention.png"),
                new ModelMenu("7", "Angkutan Logistik", "Resources/Images/cargo.png")
            };
    }
}