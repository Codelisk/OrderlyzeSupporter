using Prism.Navigation;

namespace BasePagesBackendModule.Navigation
{
    public class PathAndParameters
    {
        public string? PageName { get; set; }
        public string? ErrorMessage { get; set; }
        public INavigationParameters Parameters { get; set; } = new NavigationParameters();

        public bool IsSet()
        {
            return !string.IsNullOrEmpty(PageName);
        }
        public bool HasErrorMessage()
        {
            return !string.IsNullOrEmpty(ErrorMessage);
        }
    }
}
