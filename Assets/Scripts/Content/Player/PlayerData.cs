using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Content.Player
{
    [CreateAssetMenu(menuName = "Create PlayerData", fileName = "PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [field: SerializeField] public AssetReference PlayerPrefab { get; private set; }
    }
}