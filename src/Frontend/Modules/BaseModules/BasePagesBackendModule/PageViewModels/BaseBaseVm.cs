using AsyncAwaitBestPractices;
using BasePagesBackendModule.Constants;
using BasePagesBackendModule.Navigation;
using Prism.Common;
using Prism.Navigation;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasePagesBackendModule.PageViewModels
{
    public abstract class BaseBaseVm : ReactiveObject
    {

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => this.RaiseAndSetIfChanged(ref isBusy, value);
        }

        public BaseBaseVm()
        {
        }

        #region LoadingCommand without parameters
        protected virtual ICommand LoadingCommand(Func<Task> taskFunc) => new DelegateCommand(() =>
            this.LoadingAsync(taskFunc).SafeFireAndForget()
        );
        protected virtual ICommand BlockCommand(Func<Task> taskFunc) => new DelegateCommand(() =>
            this.LoadingAsync(taskFunc, true).SafeFireAndForget()
        );
        protected virtual async Task LoadingAsync(Func<Task> taskFunc, bool blockOnly = false)
        {
            if (this.IsBusyOrLocked())
            {
                return;
            }

            this.SetBlockingAndBusy(true, blockOnly);

            try
            {
                await taskFunc.Invoke();
            }
            finally
            {
                this.SetBlockingAndBusy(false, blockOnly);
            }
        }
        #endregion
        #region LoadingCommand with parameters

        protected virtual ICommand LoadingCommand<T>(Func<T, Task> taskFunc) => new DelegateCommand<T>((o) =>
            this.LoadingAsync(taskFunc, o).SafeFireAndForget()
        );
        protected virtual ICommand BlockCommand<T>(Func<T, Task> taskFunc) => new DelegateCommand<T>((o) =>
            this.LoadingAsync(taskFunc, o, true).SafeFireAndForget()
        );
        protected virtual async Task LoadingAsync<T>(Func<T, Task> taskFunc, T o, bool blockOnly = false)
        {
            if (this.IsBusyOrLocked())
            {
                return;
            }

            this.SetBlockingAndBusy(true, blockOnly);

            try
            {
                await taskFunc.Invoke(o);
            }
            finally
            {
                this.SetBlockingAndBusy(false, blockOnly);
            }
        }
        #endregion
        #region Loading and Blocking Helper
        private bool IsBlocked;
        private void SetBlockingAndBusy(bool val, bool blockOnly = false)
        {
            this.IsBlocked = val;

            if (!blockOnly)
            {
                this.IsBusy = val;
            }
        }
        private bool IsBusyOrLocked()
        {
            return this.IsBlocked || this.IsBusy;
        }
        #endregion

    }
}
