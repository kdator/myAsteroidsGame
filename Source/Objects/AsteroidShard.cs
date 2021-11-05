using myAsteroidsGame.Source.GameObjects.Graphics;
using myAsteroidsGame.Source.GameObjects.Physics;

using System;

namespace myAsteroidsGame.Source.Objects
{
    class AsteroidShard : Asteroid
    {
        private float maxSpeed_ = 150.0f;
        private float acceleration_ = 200.0f;

        public AsteroidShard(float xPos, float yPos, IPhysicsComponent physic, IGraphicsComponent graphics)
            : base(xPos, yPos, physic, graphics)
        {
            Random r = new Random();
            Transform.RotationDegree = r.Next(0, 361);
            Name = "AsteroidShard";
        }

        public AsteroidShard(float xPos, float yPos) : base(xPos, yPos)
        {
            Random r = new Random();
            Physic = new VanilaPhysicsComponent(Transform, 1.0f, maxSpeed_);
            Graphics = new GraphicsComponent();
            Transform.RotationDegree = r.Next(0, 361);
            Name = "AsteroidShard";
        }

        public override void Update()
        {
            Physic.ApplyForce(acceleration_ * Transform.RotationDirection);
        }
    }
}