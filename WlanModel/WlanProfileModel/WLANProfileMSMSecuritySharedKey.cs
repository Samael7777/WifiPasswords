using System.Xml.Serialization;

namespace WlanModel.WlanProfileModel;

[Serializable]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.microsoft.com/networking/WLAN/profile/v1")]
public class WLANProfileMSMSecuritySharedKey
{

    private string keyTypeField;

    private bool protectedField;

    private string keyMaterialField;

    
    public string keyType
    {
        get => keyTypeField;
        set => keyTypeField = value;
    }

    
    public bool @protected
    {
        get => protectedField;
        set => protectedField = value;
    }

    
    public string keyMaterial
    {
        get => keyMaterialField;
        set => keyMaterialField = value;
    }
}