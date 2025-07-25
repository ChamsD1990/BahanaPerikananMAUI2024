namespace BahanaLautan.Source.Model;

public class ModelMenu : ContentPage
{
    public string BoxID { get; set; }
    public string BoxName { get; set; }
    public string ImageSource { get; set; }

    public ModelMenu(string boxID, string boxName, string imageSource)
    {
        BoxID = boxID;
        BoxName = boxName;
        ImageSource = imageSource;
    }
}