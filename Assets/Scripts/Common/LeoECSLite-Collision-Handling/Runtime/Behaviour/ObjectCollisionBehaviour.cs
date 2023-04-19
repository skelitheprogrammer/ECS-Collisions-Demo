using Skillitronic.LeoECSLite.Common;

namespace Skillitronic.LeoECSLite.CollisionHandling.Behaviour
{
    public sealed class ObjectCollisionBehaviour : CollisionBehaviour
    {
        private void OnCollisionEnter(UnityEngine.Collision other)
        {
            if (!other.collider.attachedRigidbody)
            {
                return;
            }

            if (other.gameObject.TryGetComponent(out EntityReferenceHolder entityReferenceHolder))
            {
                OnCollision(Entity, new CollisionData(entityReferenceHolder.Entity, true));
            }
        }

        private void OnCollisionExit(UnityEngine.Collision other)
        {
            if (!other.collider.attachedRigidbody)
            {
                return;
            }

            if (other.gameObject.TryGetComponent(out EntityReferenceHolder entityReferenceHolder))
            {
                OnCollision(Entity, new CollisionData(entityReferenceHolder.Entity, false));
            }
        }
    }
}