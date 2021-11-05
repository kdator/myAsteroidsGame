using System;

using myAsteroidsGame.Source.GameObjects;
using myAsteroidsGame.Source.GameObjects.Graphics;
using myAsteroidsGame.Source.GameObjects.Physics;
using myAsteroidsGame.Source.Managers;
using myAsteroidsGame.Source.Utils;

namespace myAsteroidsGame.Source.Objects
{
    class PlayerSpaceship : GameObject
    {
        private float maxSpeed_;
        private float acceleration_;
        private float friction_;
        private float delayPerShoot_;

        public PlayerSpaceship(float xPos, float yPos, IPhysicsComponent physic, IGraphicsComponent graphics)
            : base(xPos, yPos, physic, graphics)
        {
            maxSpeed_ = 600.0f;
            acceleration_ = 500.0f;
            friction_ = 250.0f;
            delayPerShoot_ = 3.0f;
            Physic.MaxSpeed = maxSpeed_;
            Name = "PlayerSpaceship";
        }

        public PlayerSpaceship(float xPos, float yPos) : base(xPos, yPos)
        {
            maxSpeed_ = 1000.0f;
            acceleration_ = 500.0f;
            friction_ = 250.0f;
            Physic = new VanilaPhysicsComponent(Transform, 1.0f, maxSpeed_);
            Graphics = new GraphicsComponent();
            Name = "PlayerSpaceship";
        }

        public override void Rotate(float degree)
        {
            Transform.RotationDegree = ((Transform.RotationDegree + degree) % 360 + 360) % 360;
        }

        public void FlyForward()
        {
            Physic.ApplyForce(acceleration_ * Transform.RotationDirection);
        }

        public void Shoot()
        {
            // delay per shoot value decreases in Update() func.
            if (delayPerShoot_ <= 0.0f)
            {
                var bullet = new Bullet(Transform.Position.X + (float)Math.Sin(Transform.RotationInRadians) * Graphics.Texture.Height / 2,
                                                    Transform.Position.Y - (float)Math.Cos(Transform.RotationInRadians) * Graphics.Texture.Height / 2,
                                                    Transform.RotationDegree);
                // call GameManager internal to add bullet in list of game objects.
                bullet.Graphics.Texture = GameManagerInternal.GetInstance().GetTexture(TextureID.BULLET);
                GameManagerInternal.GetInstance().AddObject(bullet);
                delayPerShoot_ = 3.0f;
            }
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
            delayPerShoot_ -= 0.25f;
            if (delayPerShoot_ > 3.0f && delayPerShoot_ < float.MaxValue)
                delayPerShoot_ = 3.0f;
        }
    }
}