using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Skillitronic.LeoECSLite.GameObjectResourceManager.Common.Runtime
{
    public static class AddressablesUtility
    {
        public static async Task<string> GetAddressFromAssetReference(this AssetReference reference)
        {
            string key = string.Empty;
            Task<IList<IResourceLocation>> loadResourceLocationsTask = Addressables.LoadResourceLocationsAsync(reference).Task;
        
            IList<IResourceLocation> result = await loadResourceLocationsTask;
      
            if (result.Count > 0)
            {
                key = result[0].PrimaryKey;
            }
            
            return key;
        }
    }
}
