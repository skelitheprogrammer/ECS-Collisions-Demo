namespace Skillitronic.LeoECSLite.CollisionHandling
{
    [System.Serializable]
    public struct CollisionData
    {
        public int OtherEntity;
        public bool Collided;

        public CollisionData(int otherEntity, bool collided)
        {
            OtherEntity = otherEntity;
            Collided = collided;
        }
    }
}