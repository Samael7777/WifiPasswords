using System.Xml.Serialization;

namespace WlanModel.WlanProfileModel;

[Serializable]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.microsoft.com/networking/WLAN/profile/v3")]
[XmlRoot(Namespace = "http://www.microsoft.com/networking/WLAN/profile/v3", IsNullable = false)]
public class MacRandomization
{

    private bool enableRandomizationField;

    private uint randomizationSeedField;

    
    public bool enableRandomization
    {
        get => enableRandomizationField;
        set => enableRandomizationField = value;
    }

    
    public uint randomizationSeed
    {
        get => randomizationSeedField;
        set => randomizationSeedField = value;
    }
}