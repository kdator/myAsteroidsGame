using System;

using myAsteroidsGame.Source.GameObjects;
using myAsteroidsGame.Source.GameObjects.Graphics;
using myAsteroidsGame.Source.GameObjects.Physics;

namespace myAsteroidsGame.Source.Objects
{
    class BigAsteroid : Asteroid
    {
        private float maxSpeed_ = 100.0f;
        private float acceleration_ = 200.0f;

        public BigAsteroid(float xPos, float yPos, IPhysicsComponent physic, IGraphicsComponent graphics)
            : base(xPos, yPos, physic, graphics)
        {
            Random r = new Random();
            Transform.RotationDegree = r.Next(0, 361);
            Name = "BigAsteroid";
        }

        public BigAsteroid(float xPos, float yPos) : base(xPos, yPos)
        {
            Random r = new Random();
            Physic = new VanilaPhysicsComponent(Transform, 1.0f, maxSpeed_);
            Graphics = new GraphicsComponent();
            Transform.RotationDegree = r.Next(0, 361);
            Name = "BigAsteroid";
        }

        public override void Update()
        {
            Physic.ApplyForce(acceleration_ * Transform.RotationDirection);
        }
    }
}
