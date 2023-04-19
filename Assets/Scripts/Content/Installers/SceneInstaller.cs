using Common;
using Reflex.Attributes;
using Reflex.Core;
using Reflex.Extensions;
using UnityEngine;

namespace Content.Installers
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private SystemRunner _systemRunner;
    
        public void InstallBindings(ContainerDescriptor descriptor)
        {
        }

        [Inject]
        private void Inject(Container container)
        {
            container.Instantiate(_systemRunner);
        }
    
    
    }
}
