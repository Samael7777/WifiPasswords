using System.Xml.Serialization;

namespace WlanModel.WlanProfileModel;

[Serializable]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.microsoft.com/networking/WLAN/profile/v1")]
public class WLANProfileMSMSecurity
{

    private WLANProfileMSMSecurityAuthEncryption authEncryptionField;

    private WLANProfileMSMSecuritySharedKey sharedKeyField;

    
    public WLANProfileMSMSecurityAuthEncryption authEncryption
    {
        get => authEncryptionField;
        set => authEncryptionField = value;
    }

    
    public WLANProfileMSMSecuritySharedKey sharedKey
    {
        get => sharedKeyField;
        set => sharedKeyField = value;
    }
}