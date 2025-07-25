namespace BahanaLautan.Source.Model.Kerja;

public class ModelMenuKebutuhanKerja
{
    public string BoxID { get; set; }
    public string BoxName { get; set; }
    public string ImageSource { get; set; }

    public ModelMenuKebutuhanKerja(string boxID, string boxName, string imageSource)
    {
        BoxID = boxID;
        BoxName = boxName;
        ImageSource = imageSource;
    }

}