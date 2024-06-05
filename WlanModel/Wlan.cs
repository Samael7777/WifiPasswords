using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using Windows.Win32;
using Windows.Win32.Foundation;
using WlanApi.PInvoke;
using WlanModel.WlanProfileModel;

namespace WlanModel;

public class Wlan : IDisposable
{
    private const uint WlanProfileGetPlaintextKey = 0x04;

    private readonly SafeWlanHandle _wlanHandle;

    public Wlan()
    {
        unsafe
        {
            HANDLE unsafeHandle;
            var error = WinApi.WlanOpenHandle(2, out _, &unsafeHandle);
            CheckErrorThrowException(error);

            _wlanHandle = new SafeWlanHandle(unsafeHandle);
        }
    }

    public unsafe List<Guid> GetInterfaces()
    {
        var error = WinApi.WlanEnumInterfaces(_wlanHandle, out var interfaceInfoList);
        CheckErrorThrowException(error);
        
        var interfacesCount = (int)interfaceInfoList->dwNumberOfItems;
        var interfaces = GetArrayFromNative(ref interfaceInfoList->InterfaceInfo, interfacesCount)
            .Select(iface=>iface.InterfaceGuid)
            .ToList();

        return interfaces;
    }

    public unsafe List<string> GetProfileNames(Guid wlanInterface)
    {
        var error = WinApi.WlanGetProfileList(_wlanHandle, wlanInterface, out var profileInfoList);
        CheckErrorThrowException(error);

        var profilesCount = (int)profileInfoList->dwNumberOfItems;
        var profileNames = GetArrayFromNative(ref profileInfoList->ProfileInfo, profilesCount)
            .Select(profile => profile.strProfileName.ToString())
            .ToList();

        return profileNames;
    }

    public unsafe WLANProfile? GetProfile(Guid wlanInterface, string profileName)
    {
        var flag = WlanProfileGetPlaintextKey;
        var error = WinApi.WlanGetProfile(_wlanHandle, wlanInterface, profileName, out var xmlPtr,
            &flag, null);
        if (error != 0) return null;
        
        var profileXmlString = xmlPtr.ToString();
        var serializer = new XmlSerializer(typeof(WLANProfile));
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(profileXmlString));
        var profile = serializer.Deserialize(stream) as WLANProfile;

        return profile;
    }

    private static T[] GetArrayFromNative<T>(ref VariableLengthInlineArray<T> nativeArray, int elements)
        where T:unmanaged
    {
        var result = nativeArray.AsSpan(elements).ToArray();
        return result;
    }

    private static void CheckErrorThrowException(uint errorCode)
    {
        if (errorCode != 0)
            throw new Win32Exception((int)errorCode);
    }

    #region Dispose

    private bool _disposed;

    ~Wlan()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            //dispose managed state (managed objects)
            
        }
        //free unmanaged resources (unmanaged objects) and override finalizer
        //set large fields to null
        _wlanHandle.Close();
        _disposed = true;
    }

    #endregion
}