using Microsoft.Xna.Framework;

using myAsteroidsGame.Source.Objects;

namespace myAsteroidsGame.Source.Physics
{
    class VanilaPhysicComponent : IPhysicComponent
    {
        private float mass_;
        private Transform transformAttached_;

        private float maxSpeed_;
        public float MaxSpeed
        {
            get => maxSpeed_;
            set => maxSpeed_ = value;
        }

        private Vector2 acceleration_;
        public Vector2 Acceleration => acceleration_;

        private Vector2 velocity_;
        public Vector2 Velocity => velocity_;

        public VanilaPhysicComponent(Transform transform, float mass, float maxSpeed)
        {
            transformAttached_ = transform;
            acceleration_ = Vector2.Zero;
            velocity_ = Vector2.Zero;
            mass_ = mass;
            maxSpeed_ = maxSpeed;
        }

        public void Update(float deltaTime)
        {
            velocity_ += acceleration_ * deltaTime;
            if (velocity_.Length() >= maxSpeed_)
            {
                Vector2 norm = Vector2.Normalize(velocity_);
                velocity_ = norm * maxSpeed_;
            }
            transformAttached_.Position += velocity_ * deltaTime;
            acceleration_ = Vector2.Zero;
        }

        public void ApplyForce(Vector2 force)
        {
            acceleration_ += force;
        }
    }
}