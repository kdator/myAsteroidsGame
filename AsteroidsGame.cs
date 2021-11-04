using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using myAsteroidsGame.Source;
using myAsteroidsGame.Source.Objects;
using myAsteroidsGame.Source.Utils;

namespace myAsteroidsGame
{
    public class AsteroidsGame : Game
    {
        private GraphicsDeviceManager graphics_;
        private SpriteBatch spriteBatch_;

        private GameManager gameManager_;
        private int screenWidth_;
        private int screenHeight_;

        public AsteroidsGame()
        {
            graphics_ = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics_.PreferredBackBufferWidth = 800;
            graphics_.PreferredBackBufferHeight = 600;
            graphics_.ApplyChanges();

            screenWidth_ = Window.ClientBounds.Width;
            screenHeight_ = Window.ClientBounds.Height;
            gameManager_ = new GameManager(screenWidth_, screenHeight_);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch_ = new SpriteBatch(GraphicsDevice);

            gameManager_.LoadContent(TextureID.PLAYER_SPACESHIP, Content.Load<Texture2D>("player_spaceship"));
            gameManager_.LoadContent(TextureID.ASTEROID, Content.Load<Texture2D>("asteroid"));
            gameManager_.LoadContent(TextureID.ASTEROID_SHARD, Content.Load<Texture2D>("asteroid_shard"));
            gameManager_.LoadContent(TextureID.BULLET, Content.Load<Texture2D>("bullet"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gameManager_.ProccessKeyboardInput(Keyboard.GetState());
            gameManager_.UpdateObjects();
            gameManager_.UpdatePhysics((float)gameTime.ElapsedGameTime.TotalSeconds);
            gameManager_.UpdateAsteroids();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch_.Begin();
            foreach (GameObject obj in gameManager_.ActiveObjects())
            {
                var newPos = obj.Transform.Position;
                ToScreenPosition(ref newPos);
                obj.Transform.Position = newPos;
                spriteBatch_.Draw(obj.Graphics.Texture, obj.Transform.Position, null, Color.White,
                                  obj.Transform.RotationInRadians, obj.Graphics.Origin,
                                  1f, SpriteEffects.None, 0f);
            }
            spriteBatch_.End();

            base.Draw(gameTime);
        }

        private void ToScreenPosition(ref Vector2 v)
        {
            v.X = (v.X % screenWidth_ + screenWidth_) % screenWidth_;
            v.Y = (v.Y % screenHeight_ + screenHeight_) % screenHeight_;
        }
    }
}