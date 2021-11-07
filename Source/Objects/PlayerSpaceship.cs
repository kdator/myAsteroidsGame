using System;

using myAsteroidsGame.Source.GameObjects;
using myAsteroidsGame.Source.GameObjects.Graphics;
using myAsteroidsGame.Source.GameObjects.Physics;
using myAsteroidsGame.Source.Managers;
using myAsteroidsGame.Source.Utils;

using static myAsteroidsGame.Source.Managers.GameManagerInternal;

namespace myAsteroidsGame.Source.Objects
{
    class PlayerSpaceship : GameObject
    {
        private float maxSpeed_;
        private float acceleration_;
        private float friction_;
        private float delayPerShoot_;

        public PlayerSpaceship(float xPos, float yPos) : base(xPos, yPos)
        {
            maxSpeed_ = GMI.Configs.Ship.MaxSpeed;
            acceleration_ = GMI.Configs.Ship.Acceleration;
            friction_ = GMI.Configs.Ship.Friction;
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
                                                    Transform.RotationDegree,
                                                    GMI.Configs.Ship.BulletLifeTime,
                                                    GMI.Configs.Ship.BulletMaxSpeed);
                // call GameManager internal to add bullet in list of game objects.
                bullet.Graphics.Texture = GMI.GetTexture(TextureID.BULLET);
                GMI.AddObject(bullet);
                delayPerShoot_ = GMI.Configs.Ship.DelayPerShoot;
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
                delayPerShoot_ = GMI.Configs.Ship.DelayPerShoot;
        }
    }
}