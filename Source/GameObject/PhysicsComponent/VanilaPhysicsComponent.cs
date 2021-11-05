﻿using myAsteroidsGame.Source.Utils;

namespace myAsteroidsGame.Source.GameObjects.Physics
{
    class VanilaPhysicsComponent : IPhysicsComponent
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
        public Vector2 Velocity { 
            get => velocity_;
            set => velocity_ = value;
        } 

        public VanilaPhysicsComponent(Transform transform, float mass, float maxSpeed)
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
            CorrectVelocity(velocity_);
            transformAttached_.Position += velocity_ * deltaTime;
            acceleration_ = Vector2.Zero;
        }

        public void ApplyForce(Vector2 force)
        {
            acceleration_ += force;
        }

        private void CorrectVelocity(Vector2 v)
        {
            if (v.Length() >= maxSpeed_)
            {
                Vector2 norm = Vector2.Normalize(v);
                velocity_ = norm * maxSpeed_;
            }
        }
    }
}