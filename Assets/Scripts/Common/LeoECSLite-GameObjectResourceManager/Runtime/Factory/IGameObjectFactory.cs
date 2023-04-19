using System.Threading.Tasks;
using UnityEngine;

namespace Skillitronic.LeoECSLite.GameObjectResourceManager.Common.Runtime.Factory
{
    public interface IGameObjectFactory
    { 
        Task<GameObject> Create(string reference);
    }
}