using System.Xml.Serialization;

namespace WlanModel.WlanProfileModel;

[Serializable]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.microsoft.com/networking/WLAN/profile/v1")]
public class WLANProfileMSMSecurityAuthEncryption
{

    private string authenticationField;

    private string encryptionField;

    private bool useOneXField;

    
    public string authentication
    {
        get => authenticationField;
        set => authenticationField = value;
    }

    
    public string encryption
    {
        get => encryptionField;
        set => encryptionField = value;
    }

    
    public bool useOneX
    {
        get => useOneXField;
        set => useOneXField = value;
    }
}