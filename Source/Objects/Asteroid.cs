using myAsteroidsGame.Source.GameObjects;
using myAsteroidsGame.Source.GameObjects.Graphics;
using myAsteroidsGame.Source.GameObjects.Physics;

namespace myAsteroidsGame.Source.Objects
{
    class Asteroid : GameObject
    {
        public Asteroid(float xPos, float yPos) : base(xPos, yPos)
        {
            Name = "Asteroid";
        }

        public Asteroid(float xPos, float yPos, IPhysicsComponent physic, IGraphicsComponent graphics) :
            base(xPos, yPos, physic, graphics)
        {
            Name = "Asteroid";
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
