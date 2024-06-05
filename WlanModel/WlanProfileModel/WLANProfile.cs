using System.Xml.Serialization;

namespace WlanModel.WlanProfileModel;

[Serializable]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.microsoft.com/networking/WLAN/profile/v1")]
[XmlRoot(Namespace = "http://www.microsoft.com/networking/WLAN/profile/v1", IsNullable = false)]
public class WLANProfile
{

    private string nameField;

    private WLANProfileSSIDConfig sSIDConfigField;

    private string connectionTypeField;

    private string connectionModeField;

    private WLANProfileMSM mSMField;

    private MacRandomization macRandomizationField;

    
    public string name
    {
        get => nameField;
        set => nameField = value;
    }

    
    public WLANProfileSSIDConfig SSIDConfig
    {
        get => sSIDConfigField;
        set => sSIDConfigField = value;
    }

    
    public string connectionType
    {
        get => connectionTypeField;
        set => connectionTypeField = value;
    }

    
    public string connectionMode
    {
        get => connectionModeField;
        set => connectionModeField = value;
    }

    
    public WLANProfileMSM MSM
    {
        get => mSMField;
        set => mSMField = value;
    }

    
    [XmlElement(Namespace = "http://www.microsoft.com/networking/WLAN/profile/v3")]
    public MacRandomization MacRandomization
    {
        get => macRandomizationField;
        set => macRandomizationField = value;
    }
}