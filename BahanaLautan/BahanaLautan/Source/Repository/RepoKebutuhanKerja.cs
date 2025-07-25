using BahanaLautan.Source.Model.Kerja;
using System.Collections.ObjectModel;

namespace BahanaLautan.Source.Repository;

public class RepoKebutuhanKerja 
{
    public ObservableCollection<ModelMenuKebutuhanKerja> ListKebutuhanKerja { get; set; }

    public RepoKebutuhanKerja()
    {
        ListKebutuhanKerja = new ObservableCollection<ModelMenuKebutuhanKerja>
        {
            new ModelMenuKebutuhanKerja("1", "Kasbon Operasional", "Resources/Images/chevron.png"),
            new ModelMenuKebutuhanKerja("2", "Permintaan Kebutuhan BBM", "Resources/Images/chevron.png"),
            new ModelMenuKebutuhanKerja("3", "Permintaan Es Batu", "Resources/Images/chevron.png"),
            new ModelMenuKebutuhanKerja("4", "Permintaan Bahan Makanan", "Resources/Images/chevron.png"), 
        };
    }
}