using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend_Uno.Services;
using Backend.Api;
using BasePagesBackendModule.PageViewModels;
using BaseServicesModule.Services.Vms;
using ReactiveUI;
using Microsoft.Extensions.Configuration;

namespace Frontend_Uno.Presentation.Login;
public class LoginViewModel : RegionBaseViewModel
{
    private readonly IRegionManager regionManager;
    private readonly IConfiguration configuration;
    private readonly Func<Backend.Api.Services.Auth.IAuthenticationService> authenticationService;

    public LoginViewModel(
        VmServices vmServices,
        IRegionManager regionManager,
        IConfiguration configuration,
        Func<Backend.Api.Services.Auth.IAuthenticationService> authenticationService) : base(vmServices)
    {
        this.regionManager = regionManager;
        this.configuration = configuration;
        this.authenticationService = authenticationService;
    }
    public ICommand LoginCommand => this.LoadingCommand(async () => await OnLoginAsync());

    private string email="a.daka@orderlyze.com";
    public string Email
    {
        get { return email; }
        set { this.RaiseAndSetIfChanged(ref email, value); }
    }

    private string password;
    public string Password
    {
        get { return password; }
        set { this.RaiseAndSetIfChanged(ref password, value); }
    }

    private async Task OnLoginAsync()
    {
        await authenticationService().AuthenticateAndCacheTokenAsync(new Backend.Api.Models.Auth.AuthPayload
        {
            email = Email,
            password = Password
        });

        regionManager.RequestNavigate("ContentRegion", "LearnModeView");
    }
    private string restUrl = Constants.RestUrl;
    public string RestUrl
    {
        get { return restUrl; }
        set
        {
            Constants.RestUrl = value;
            this.RaiseAndSetIfChanged(ref restUrl, value);
        }
    }
}
