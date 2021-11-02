using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace myAsteroidsGame.Source.Graphics
{
    interface IGraphicsComponent
    {
        Texture2D Texture { get; set; }

        Vector2 Origin { get; }
    }
}
