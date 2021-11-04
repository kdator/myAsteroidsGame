﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace myAsteroidsGame.Source.Graphics
{
    class GraphicsComponent : IGraphicsComponent
    {
        private Texture2D texture_;
        public Texture2D Texture
        {
            get => texture_;
            set => texture_ = value;
        }

        public Vector2 Origin {
            get => new Vector2(texture_.Width / 2, texture_.Height / 2);
        }
    }
}
