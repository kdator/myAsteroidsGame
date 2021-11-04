using myAsteroidsGame.Source.Graphics;
using myAsteroidsGame.Source.Physics;

namespace myAsteroidsGame.Source.Objects
{
    class Asteroid : GameObject
    {
        public Asteroid(float xPos, float yPos) : base(xPos, yPos)
        { }

        public Asteroid(float xPos, float yPos, IPhysicsComponent physic, IGraphicsComponent graphics) :
            base(xPos, yPos, physic, graphics)
        { }

        public override void Update()
        {
            base.Update();
        }
    }
}
