using myAsteroidsGame.Source.GameObjects;

namespace myAsteroidsGame.Source.Objects
{
    class Asteroid : GameObject
    {
        public Asteroid(float xPos, float yPos) : base(xPos, yPos)
        {
            Name = "Asteroid";
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
