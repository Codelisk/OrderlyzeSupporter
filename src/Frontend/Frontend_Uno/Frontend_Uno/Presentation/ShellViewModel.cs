using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend_Uno.Services;
using Microsoft.UI.Dispatching;

namespace Frontend_Uno.Presentation;
public class ShellViewModel : BindableBase, IActiveAware
{
    private readonly IRegionManager _regionManager;
    private readonly Func<ITokenCache> _tokenCache;
    private readonly Func<IAuthenticationService> _auth;
    private readonly Func<IDispatcher> _dispatcher;
    private readonly Func<IDialogService> _dialogs;
    private bool _isInitialized;

    public DelegateCommand NavigateCommand { get; }
    public ShellViewModel(
        IRegionManager regionManager,
        Func<ITokenCache> tokenCache,
        Func<IAuthenticationService> auth,
        Func<IDispatcher> dispatcher,
        Func<IDialogService> dialogs)
    {
        _regionManager = regionManager;
        //_tokenCache = tokenCache;
        //_auth = auth;
        //_dispatcher = dispatcher;
        //_dialogs = dialogs;
        NavigateCommand = new DelegateCommand(() => ExecuteNavigateCommand());

        Task.Run(async() =>
        {
            await Task.Delay(5000);
            Initialize();
        });
    }
    private bool _isActive;
    public event EventHandler IsActiveChanged;
    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            if (!_isInitialized) Initialize();
        }
    }
    private void Initialize()
    {
        _isInitialized = true;
        try
        {
                //var jnkdf = await _auth().LoginAsync(_dispatcher(), new Dictionary<string, string> { { "email", "d.hufnagl@codelisk.com" },{"password","Test1234!" } });
                //await _auth().RefreshAsync();
                _regionManager.RequestNavigate("HeaderRegion", "MainPage");
                _regionManager.RequestNavigate("ContentRegion", "LoginView");
        }
        catch (Exception ex)
        {

        }
    }
    private async void ExecuteNavigateCommand()
    {
        var sdf = await _tokenCache().HasTokenAsync(CancellationToken.None);
        Debug.WriteLine("TESTXXXXXXXXXXX");
        //var test = _resolveAuthService();
        // _regionManager.RequestNavigate("ContentRegion", viewName);
    }
}
