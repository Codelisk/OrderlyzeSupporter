using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasePagesBackendModule.Extensions
{
    public static class RegionManagerExtension
    {
        /// <summary>
        /// Unregister All Currently Registered Regions
        /// </summary>
        /// <param name="regionManager">Region manager instance to remove regions from</param>
        public static void UnregisterRegions(this IRegionManager regionManager)
        {
            if(regionManager is null)
            {
                return;
            }

            if (!regionManager.Regions.Any())
            {
                return;
            }

            var regionNames = regionManager.Regions.Select(r => r.Name)
                .ToList();

            regionNames.ForEach(r => regionManager.Regions.Remove(r));
        }
    }
}
