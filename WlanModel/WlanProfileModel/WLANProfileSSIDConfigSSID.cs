using System.Xml.Serialization;

namespace WlanModel.WlanProfileModel;

[Serializable]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.microsoft.com/networking/WLAN/profile/v1")]
public class WLANProfileSSIDConfigSSID
{

    private string hexField;

    private string nameField;

    
    public string hex
    {
        get => hexField;
        set => hexField = value;
    }

    
    public string name
    {
        get => nameField;
        set => nameField = value;
    }
}