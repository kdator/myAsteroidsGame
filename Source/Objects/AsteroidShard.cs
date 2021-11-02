using myAsteroidsGame.Source.Graphics;
using myAsteroidsGame.Source.Physics;

using System;

namespace myAsteroidsGame.Source.Objects
{
    class AsteroidShard : GameObject
    {
        private float maxSpeed_ = 200.0f;

        public AsteroidShard(float xPos, float yPos, IPhysicComponent physic, IGraphicsComponent graphics)
            : base(xPos, yPos, physic, graphics)
        {
            Random r = new Random();
            Transform.RotationDegree = r.Next(0, 361);
        }

        public AsteroidShard(float xPos, float yPos) : base(xPos, yPos)
        {
            Random r = new Random();
            Physic = new VanilaPhysicComponent(Transform, 1.0f, maxSpeed_);
            Graphics = new GraphicsComponent();
            Transform.RotationDegree = r.Next(0, 361);
        }

        public override void Update()
        {

        }
    }
}