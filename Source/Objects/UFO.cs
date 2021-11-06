using myAsteroidsGame.Source.GameObjects;
using myAsteroidsGame.Source.GameObjects.Physics;
using myAsteroidsGame.Source.GameObjects.Graphics;
using myAsteroidsGame.Source.Utils;

namespace myAsteroidsGame.Source.Objects
{
    class UFO : GameObject
    {
        private GameObject followingSpaceship_;
        private float maxSpeed_;
        private float friction_;


        public UFO(float xPos, float yPos, GameObject spaceship) : base(xPos, yPos)
        {
            maxSpeed_ = 200.0f;
            friction_ = 250.0f;
            followingSpaceship_ = spaceship;
            Physic = new VanilaPhysicsComponent(Transform, 1.0f, maxSpeed_);
            Graphics = new GraphicsComponent();
            Name = "UFO";
        }

        public override void Rotate(float degree)
        {
            base.Rotate(degree);
        }

        public override void Update()
        {
            Vector2 v = Physic.Velocity;
            if (v != Vector2.Zero)
            {
                Vector2 norm;
                Vector2.Normalize(ref v, out norm);
                Vector2 opposite = Vector2.Negate(norm);
                Physic.ApplyForce(opposite * friction_);
            }
            Transform.Position = Vector2.Lerp(Transform.Position, followingSpaceship_.Transform.Position, 0.01f);
        }
    }
}
