using WlanModel;

namespace WifiPasswordsGui;

public class AppModel : IDisposable
{
    private readonly Wlan _wlanApi = new();

    public Dictionary<string, HashSet<string>> GetWlanPasswords()
    {
        var wlanPasswords = new Dictionary<string, HashSet<string>>();

        var profileNames = GetWlanProfiles();

        foreach (var adapter in profileNames.Keys)
        {
            var networks = profileNames[adapter];
            foreach (var network in networks)
            {
                var profile = _wlanApi.GetProfile(adapter, network);
                if (profile == null) continue;

                var password = profile.MSM.security.sharedKey.keyMaterial;
                if (!wlanPasswords.ContainsKey(network))
                    wlanPasswords.Add(network, new HashSet<string>());

                wlanPasswords[network].Add(password);
            }
        }

        return wlanPasswords;
    }

    private Dictionary<Guid, List<string>> GetWlanProfiles()
    {
        var adapters = _wlanApi.GetInterfaces();
        var profiles = new Dictionary<Guid, List<string>>();

        foreach (var adapter in adapters)
        {
            var profilesList = _wlanApi.GetProfileNames(adapter);
            profiles.Add(adapter, profilesList);
        }

        return profiles;
    }

    #region Dispose

    private bool _disposed;

    ~AppModel()
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
            _wlanApi.Dispose();
        }
        //free unmanaged resources (unmanaged objects) and override finalizer
        //set large fields to null

        _disposed = true;
    }

    #endregion
}