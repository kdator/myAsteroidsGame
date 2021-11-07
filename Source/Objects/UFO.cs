using myAsteroidsGame.Source.GameObjects;
using myAsteroidsGame.Source.GameObjects.Physics;
using myAsteroidsGame.Source.GameObjects.Graphics;
using myAsteroidsGame.Source.Utils;

using static myAsteroidsGame.Source.Managers.GameManagerInternal;

namespace myAsteroidsGame.Source.Objects
{
    class UFO : GameObject
    {
        private GameObject followingSpaceship_;
        private float maxSpeed_;

        public UFO(float xPos, float yPos, GameObject spaceship) : base(xPos, yPos)
        {
            maxSpeed_ = GMI.Configs.Enemy.UFOMaxSpeed;
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
            Transform.Position = Vector2.Lerp(Transform.Position, followingSpaceship_.Transform.Position, 0.01f);
        }
    }
}
