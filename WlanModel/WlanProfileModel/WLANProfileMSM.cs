using System.Xml.Serialization;

namespace WlanModel.WlanProfileModel;

[Serializable]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.microsoft.com/networking/WLAN/profile/v1")]
public class WLANProfileMSM
{

    private WLANProfileMSMSecurity securityField;

    
    public WLANProfileMSMSecurity security
    {
        get => securityField;
        set => securityField = value;
    }
}