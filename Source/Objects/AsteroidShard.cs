using System;

using myAsteroidsGame.Source.GameObjects.Graphics;
using myAsteroidsGame.Source.GameObjects.Physics;

using static myAsteroidsGame.Source.Managers.GameManagerInternal;

namespace myAsteroidsGame.Source.Objects
{
    class AsteroidShard : Asteroid
    {
        private float maxSpeed_;

        public AsteroidShard(float xPos, float yPos) : base(xPos, yPos)
        {
            maxSpeed_ = GMI.Configs.Enemy.AsteroidShardMaxSpeed;
            Random r = new Random();
            Physic = new VanilaPhysicsComponent(Transform, 1.0f, maxSpeed_);
            Graphics = new GraphicsComponent();
            Transform.RotationDegree = r.Next(0, 361);
            Physic.Velocity = maxSpeed_ * Transform.RotationDirection;
            Name = "AsteroidShard";
        }

        public override void Update()
        {
            base.Update();
        }
    }
}