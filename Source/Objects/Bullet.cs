using System.Collections.Generic;

using myAsteroidsGame.Source.Graphics;
using myAsteroidsGame.Source.Physics;

namespace myAsteroidsGame.Source.Objects
{
    class Bullet : GameObject
    {
        private float maxSpeed_ = 400.0f;
        private float timeToLife_ = 10.0f;

        public Bullet(float xPos, float yPos, float rotation) :
            base(xPos, yPos)
        {
            Physic = new VanilaPhysicsComponent(Transform, 1.0f, maxSpeed_);
            Graphics = new GraphicsComponent();
            Transform.RotationDegree = rotation;
            Physic.Velocity = maxSpeed_ * Transform.RotationDirection;
        }

        public override void Update()
        {
        }
    }
}
