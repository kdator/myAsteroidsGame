using System;

using myAsteroidsGame.Source.GameObjects;
using myAsteroidsGame.Source.GameObjects.Graphics;
using myAsteroidsGame.Source.GameObjects.Physics;

using static myAsteroidsGame.Source.Managers.GameManagerInternal;

namespace myAsteroidsGame.Source.Objects
{
    class BigAsteroid : Asteroid
    {
        private float maxSpeed_;

        public BigAsteroid(float xPos, float yPos) : base(xPos, yPos)
        {
            maxSpeed_ = GMI.Configs.Enemy.AsteroidMaxSpeed;
            Random r = new Random();
            Physic = new VanilaPhysicsComponent(Transform, 1.0f, maxSpeed_);
            Graphics = new GraphicsComponent();
            Transform.RotationDegree = r.Next(0, 361);
            Physic.Velocity = maxSpeed_ * Transform.RotationDirection;
            Name = "BigAsteroid";
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
