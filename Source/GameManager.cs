using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using myAsteroidsGame.Source.Objects;
using myAsteroidsGame.Source.Utils;

namespace myAsteroidsGame.Source
{
    class GameManager
    {
        private PlayerSpaceship spaceship_;

        private List<GameObject> go_;

        private Dictionary<TextureID, Texture2D> texture2go_;

        public GameManager(int screenWidth, int screenHeight)
        {
            spaceship_ = new PlayerSpaceship(screenWidth / 2, screenHeight / 2);
            go_ = new List<GameObject>();
            texture2go_ = new Dictionary<TextureID, Texture2D>();

            go_.Add(spaceship_);
        }


        // A lil bit of a hardcode :) 
        public void SetTexture(TextureID textureID, Texture2D texture)
        {
            texture2go_[textureID] = texture;
            if (textureID == TextureID.PLAYER_SPACESHIP)
                spaceship_.Graphics.Texture = texture;
        }

        public void UpdatePhysics(float deltaTime)
        {
            foreach (var obj in go_)
                obj.Physic.Update(deltaTime);
        }

        public void UpdateObjects()
        {
            foreach (var obj in go_)
                obj.Update();
        }

        public void ProccessKeyboardInput(KeyboardState kstate)
        {
            if (kstate.IsKeyDown(Keys.Up))
                spaceship_.FlyForward();
            if (kstate.IsKeyDown(Keys.Left))
                spaceship_.Rotate(-5.0f);
            if (kstate.IsKeyDown(Keys.Right))
                spaceship_.Rotate(5.0f);
        }

        public System.Collections.IEnumerable ActiveObjects()
        {
            foreach (var obj in go_)
                if (obj.IsActive)
                    yield return obj;
        }
    }
}