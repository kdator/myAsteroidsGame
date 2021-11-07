using myAsteroidsGame.Source.Utils;

namespace myAsteroidsGame.Source.GameObjects.Graphics
{
    interface IGraphicsComponent
    {
        object Texture { get; set; }

        int Width { get; }

        int Height { get; }

        Vector2 Origin { get; }

        void LoadContent(object texture, int width, int height);
    }
}
