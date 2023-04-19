using Skillitronic.LeoECSLite.Common;
using UnityEngine;

namespace Skillitronic.LeoECSLite.CollisionHandling.Behaviour
{
    public sealed class ObjectTriggerBehaviour : CollisionBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.attachedRigidbody)
            {
                return;
            }

            if (other.TryGetComponent(out EntityReferenceHolder entityReferenceHolder))
            {
                OnCollision(Entity, new CollisionData(entityReferenceHolder.Entity, true));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.attachedRigidbody)
            {
                return;
            }

            if (other.TryGetComponent(out EntityReferenceHolder entityReferenceHolder))
            {
                OnCollision(Entity, new CollisionData(entityReferenceHolder.Entity, false));
            }
        }
    
    }
}