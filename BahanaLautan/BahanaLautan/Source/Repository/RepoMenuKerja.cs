using BahanaLautan.Source.Model.Kerja;
using System.Collections.ObjectModel;

namespace BahanaLautan.Source.Repository;

public class RepoMenuKerja 
{
    public ObservableCollection<ModelMenuKerja> ListKerja { get; set; }
    public RepoMenuKerja()
    {
        ListKerja = new ObservableCollection<ModelMenuKerja>
        {
            new ModelMenuKerja("1", "Estimasi Keberangkatan", "Resources/Images/chevron.png"),
            new ModelMenuKerja("2", "Daftar kebutuhan Kerja", "Resources/Images/chevron.png"),
            new ModelMenuKerja("3", "Permintaan Box Ikan", "Resources/Images/chevron.png"),
            new ModelMenuKerja("4", "Permintaan Segel Ikan", "Resources/Images/chevron.png"),
            new ModelMenuKerja("5", "Permintaan Angkutan Logistik", "Resources/Images/chevron.png"),
            new ModelMenuKerja("6", "Hasil Tangkap", "Resources/Images/chevron.png"),  
        };
    }
}