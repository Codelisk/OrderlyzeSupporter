using BasePagesBackendModule.Constants;
using BaseServicesModule.Services.Vms;
using Prism.Navigation;
using System.Reactive.Disposables;

namespace BasePagesBackendModule.PageViewModels
{
    public partial class RegionBaseViewModel : BaseLifecycleVm<NavigationContext>, IRegionAware, IRegionMemberLifetime
    {
        private IRegionNavigationService CurrentRegionNavigationService;
        public virtual bool KeepAlive
        {
            get { return false; }
        }

        private bool Initialized = false;
        private readonly VmServices _vmServices;
        public RegionBaseViewModel(VmServices vmServices)
        {
            _vmServices = vmServices;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        protected virtual void SetUpReactiveAndEvents()
        {
        }
        private CompositeDisposable DestroyWithFromPageViewModel;
        public override void FirstSetup(NavigationContext navigationContext) { }
        public override void Initialize(NavigationContext navigationContext)
        {
            this.FirstSetup(navigationContext);
        }
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            if (!KeepAlive)
            {
                this.Initialized = false;
                Destroy();
            }
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (this.Initialized)
            {
                return;
            }

            this.Initialized = true;

            await this.InitializeAsync(navigationContext);
            this.Initialize(navigationContext);
            CurrentRegionNavigationService = navigationContext.NavigationService;

            SetUpReactiveAndEvents();
        }

        protected virtual INavigationParameters AddBaseValuesToParametersForNavigationToRegion(INavigationParameters parameters)
        {
            if (parameters is null)
            {
                parameters = new NavigationParameters();
            }
            parameters.Add(BaseNavigationParameterKeys.DestroyWithFromPageViewModel, this.DestroyWithFromPageViewModel);
            return parameters;
        }
        protected void ChangeCurrentRegion(string view, INavigationParameters parameters = null)
        {
            this.CurrentRegionNavigationService.RequestNavigate(view, this.AddBaseValuesToParametersForNavigationToRegion(parameters));
        }
        protected void GoRegionBack()
        {
            this.CurrentRegionNavigationService.Journal.GoBack();
        }

        public override void SetUpReactiveAndEvents(NavigationContext navContext)
        {

        }

        public override Task InitializeAsync(NavigationContext navContext)
        {
            return Task.CompletedTask;
        }

        public override void Destroy()
        {
            _vmServices.VmContainer.DestroyWith?.Dispose();
        }

    }
}
