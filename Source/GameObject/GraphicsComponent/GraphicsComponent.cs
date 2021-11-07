using myAsteroidsGame.Source.Utils;

namespace myAsteroidsGame.Source.GameObjects.Graphics
{
    class GraphicsComponent : IGraphicsComponent
    {
        private object texture_;
        public object Texture
        {
            get => texture_;
            set => texture_ = value;
        }

        private int width_;
        public int Width => width_;

        private int height_;
        public int Height => height_;

        public Vector2 Origin {
            get => new Vector2(Width / 2, Height / 2);
        }

        public void LoadContent(object texture, int width, int height)
        {
            width_ = width;
            height_ = height;
            texture_ = texture;
        }
    }
}
