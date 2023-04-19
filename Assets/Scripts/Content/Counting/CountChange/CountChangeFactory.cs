using Content.Components;
using Content.Counting.CountChange.Behaviours;
using Content.Counting.CountChange.Components;
using Content.Counting.CountChange.UI;
using Content.Counting.CountChange.UI.Components;
using Content.Counting.CountChange.UI.View;
using Leopotam.EcsLite;
using Skillitronic.LeoECSLite.CollisionHandling;
using Skillitronic.LeoECSLite.CollisionHandling.Behaviour;
using Skillitronic.LeoECSLite.Common;
using Skillitronic.LeoECSLite.EntityDescriptors;
using Skillitronic.LeoECSLite.EntityDescriptors.Factory;
using UnityEngine;

namespace Content.Counting.CountChange
{
    public class CountChangeFactory
    {
        private readonly IDescriptorEntityFactory _entityFactory;

        public CountChangeFactory(IDescriptorEntityFactory entityFactory)
        {
            _entityFactory = entityFactory;
        }

        public void Build(EcsWorld world, CountChangeBehaviour[] behaviours)
        {
            for (var i = 0; i < behaviours.Length; i++)
            {
                CountChangeView view = behaviours[i].GetComponent<CountChangeView>();
                CreateCountChange(world, behaviours[i]);
                CreateCountChangeUI(world, view,behaviours[i]);
            }
        }

        private void CreateCountChangeUI(EcsWorld world, CountChangeView countChangeView, CountChangeBehaviour countChangeBehaviour)
        {
            EntityInitializer changeUIInit = _entityFactory.Create<CountChangeUIEntityDescriptor>(world);
            countChangeView.SetText(countChangeBehaviour.Amount.ToString());
            
            changeUIInit.InitComponent(new CountChangeUIComponent
            {
                View = countChangeView,
            });
        }

        private void CreateCountChange(EcsWorld world, CountChangeBehaviour countChangeBehaviour)
        {
            EntityInitializer changeInit = _entityFactory.Create<CountChangeEntityDescriptor>(world);
            countChangeBehaviour.GetComponent<EntityReferenceHolder>().Entity = changeInit.Entity;
            
            changeInit.InitComponent(new CountChangeData
            {
                Amount = countChangeBehaviour.Amount,
            });

            changeInit.InitComponent(new GameObjectReferenceComponent
            {
                GameObject = countChangeBehaviour.gameObject,
            });
        }
    }
}