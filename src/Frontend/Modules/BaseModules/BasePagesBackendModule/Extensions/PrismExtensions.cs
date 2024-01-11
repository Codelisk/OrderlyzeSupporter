using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasePagesBackendModule.Extensions
{

    /// <summary>
    /// Extensions for Prism
    /// </summary>
    public static class PrismExtensions
    {
        /// <summary>
        /// Check if current NavigationMode of INavigationParameters is of Enum 'Back', nested into try catch because it can fail under some circumstances
        /// </summary>
        /// <param name="navigationParameters"></param>
        /// <returns></returns>
        public static bool IsNavigationModeBack(this INavigationParameters navigationParameters)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if navigationParameters contains a boolean entry with the given key and returns it
        /// </summary>
        /// <param name="navigationParameters"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool HasBooleanWhichIsTrue(this INavigationParameters navigationParameters, string key)
        {
            return navigationParameters.TryGetValue(key, out bool b) && b;
        }
    }
}

