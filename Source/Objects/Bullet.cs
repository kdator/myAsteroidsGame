using myAsteroidsGame.Source.GameObjects;
using myAsteroidsGame.Source.GameObjects.Graphics;
using myAsteroidsGame.Source.GameObjects.Physics;

using static myAsteroidsGame.Source.Managers.GameManagerInternal;

namespace myAsteroidsGame.Source.Objects
{
    class Bullet : GameObject
    {
        private float maxSpeed_;
        private float timeToLife_;

        public Bullet(float xPos, float yPos, float rotation, float timeToLife, float maxSpeed) :
            base(xPos, yPos)
        {
            maxSpeed_ = maxSpeed;
            timeToLife_ = timeToLife;
            Physic = new VanilaPhysicsComponent(Transform, 1.0f, maxSpeed_);
            Graphics = new GraphicsComponent();
            Transform.RotationDegree = rotation;
            Physic.Velocity = maxSpeed_ * Transform.RotationDirection;
            Name = "Bullet";
        }

        public override void Update()
        {
            if (timeToLife_ <= 0.0f)
                GMI.DestroyObject(this);
            else
                timeToLife_ -= 0.15f;
        }
    }
}
