namespace BasePagesBackendModule.Navigation
{
    /// <summary>
    /// Interface for handling the back button navigation, with hardware buttons
    /// </summary>
    public interface IBackNavigationAware
    {
        /// <summary>
        /// Fires when the back button has been pressed
        /// </summary>
        void OnBackButtonPressed();
    }
}
