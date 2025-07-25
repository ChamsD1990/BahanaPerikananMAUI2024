using BahanaLautan.Source.Model;
using System.Collections.ObjectModel;

namespace BahanaLautan.Source.Repository;

public class RepoMenuPermintaan
{
    public ObservableCollection<ModelMenuPermintaan> ListPermintaan { get; set; }

    public RepoMenuPermintaan()
    {
        ListPermintaan = new ObservableCollection<ModelMenuPermintaan>
            {
                new ModelMenuPermintaan("1", "Atur Kelompok Kerja", "Resources/Images/chevron.png"),
                new ModelMenuPermintaan("2", "Perbaikan Kapal", "Resources/Images/chevron.png"),
                new ModelMenuPermintaan("3", "Perbaikan Alat Tangkap", "Resources/Images/chevron.png"),
                new ModelMenuPermintaan("4", "Peralatan Tangkap", "Resources/Images/chevron.png"),
                new ModelMenuPermintaan("5", "Permintaan Sparepart", "Resources/Images/chevron.png"),
                new ModelMenuPermintaan("6", "Kasbon Pribadi", "Resources/Images/chevron.png"), 
            };
    }
} 