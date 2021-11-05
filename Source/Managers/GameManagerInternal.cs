﻿using Microsoft.Xna.Framework.Graphics;

using myAsteroidsGame.Source.Objects;
using myAsteroidsGame.Source.Utils;

namespace myAsteroidsGame.Source.Managers
{
    class GameManagerInternal
    {
        private static GameManagerInternal instance_ = null;

        private static GameManager gameManager_;
        public static GameManager GM
        {
            set => gameManager_ = value;
        }

        private GameManagerInternal() { }

        public static GameManagerInternal GetInstance()
        {
            if (instance_ == null)
                return new GameManagerInternal();
            return instance_;
        }

        public static void DestroyObject(GameObject gameObject)
        {
            gameManager_.DestroyObject(gameObject);
        }

        public static void AddObject(GameObject gameObject)
        {
            gameManager_.AddObject(gameObject);
        }

        public static Texture2D GetTexture(TextureID textureID)
        {
            return gameManager_.GetTexture(textureID);
        }  
    }
}
