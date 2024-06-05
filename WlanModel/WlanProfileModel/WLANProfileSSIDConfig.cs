using System.Xml.Serialization;

namespace WlanModel.WlanProfileModel;

[Serializable]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.microsoft.com/networking/WLAN/profile/v1")]
public class WLANProfileSSIDConfig
{

    private WLANProfileSSIDConfigSSID sSIDField;

    
    public WLANProfileSSIDConfigSSID SSID
    {
        get => sSIDField;
        set => sSIDField = value;
    }
}