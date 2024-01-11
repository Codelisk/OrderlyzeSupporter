using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Backend.Api;
using BaseServicesModule.Services.Vms;
using Frontend_Uno.Services;

namespace Frontend_Uno.Presentation;
public partial class MainPageViewModel : RegionBaseViewModel
{
    private readonly IRegionManager regionManager;
    private readonly IOrderlyzeChatService orderlyzeChatService;

    public MainPageViewModel(IRegionManager regionManager, IOrderlyzeChatService orderlyzeChatService, VmServices vmServices) : base(vmServices)
    {
        this.regionManager = regionManager;
        this.orderlyzeChatService = orderlyzeChatService;
    }
    public ICommand TrainCommand => this.LoadingCommand(async () => await OnTrainAsync());
    public ICommand AskCommand => this.LoadingCommand(async () => await OnAskAsync());

    private async Task OnTrainAsync()
    {
        regionManager.RequestNavigate("ContentRegion", "LearnModeView");
    }
    private async Task OnAskAsync()
    {
        regionManager.RequestNavigate("ContentRegion", "AskingModeView");
    }

}
