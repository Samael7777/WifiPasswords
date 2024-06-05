using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WifiPasswordsGui;

public partial class MainViewModel : ObservableObject
{
    private readonly AppModel _appModel;
    private Dictionary<string, HashSet<string>> _networksData;

    [ObservableProperty] private List<string> _networks;
    [ObservableProperty] private List<string> _passwords;
    
    public MainViewModel(AppModel model)
    {
        _appModel = model;
        Passwords = new List<string>();
        Update();
    }

    [RelayCommand]
    private void NetworkSelected(object? networkObj)
    {
        if (networkObj is not string network 
            || string.IsNullOrWhiteSpace(network)) 
            return;

        Passwords = _networksData[network].ToList();
    }

    [RelayCommand]
    [MemberNotNull(nameof(_networksData), nameof(_networks))]
    private void Update()
    {
        _networksData = _appModel.GetWlanPasswords();
        Networks = _networksData.Keys.ToList();
    }
}