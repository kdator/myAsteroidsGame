﻿using myAsteroidsGame.Source.GameObjects;
using myAsteroidsGame.Source.GameObjects.Graphics;
using myAsteroidsGame.Source.GameObjects.Physics;
using myAsteroidsGame.Source.Managers;

namespace myAsteroidsGame.Source.Objects
{
    class Bullet : GameObject
    {
        private float maxSpeed_ = 500.0f;
        private float timeToLife_ = 10.0f;

        public Bullet(float xPos, float yPos, float rotation) :
            base(xPos, yPos)
        {
            Physic = new VanilaPhysicsComponent(Transform, 1.0f, maxSpeed_);
            Graphics = new GraphicsComponent();
            Transform.RotationDegree = rotation;
            Physic.Velocity = maxSpeed_ * Transform.RotationDirection;
            Name = "Bullet";
        }

        public override void Update()
        {
            if (timeToLife_ <= 0.0f)
                GameManagerInternal.GetInstance().DestroyObject(this);
            else
                timeToLife_ -= 0.15f;
        }
    }
}
