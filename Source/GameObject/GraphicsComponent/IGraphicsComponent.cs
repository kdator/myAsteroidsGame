using Microsoft.Xna.Framework.Graphics;

using myAsteroidsGame.Source.Utils;

namespace myAsteroidsGame.Source.GameObjects.Graphics
{
    interface IGraphicsComponent
    {
        Texture2D Texture { get; set; }

        Vector2 Origin { get; }
    }
}
