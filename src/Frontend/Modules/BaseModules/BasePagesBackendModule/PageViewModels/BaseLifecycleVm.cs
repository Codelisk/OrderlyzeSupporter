using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasePagesBackendModule.PageViewModels
{
    public abstract class BaseLifecycleVm<NavContext> : BaseBaseVm
    {
        public abstract void SetUpReactiveAndEvents(NavContext navContext);
        public abstract void FirstSetup(NavContext navContext);
        public abstract void Initialize(NavContext navContext);
        public abstract Task InitializeAsync(NavContext navContext);
        public abstract void Destroy();
        public abstract void OnNavigatedTo(NavContext navigationContext);
        public abstract void OnNavigatedFrom(NavContext navigationContext);
    }
}
