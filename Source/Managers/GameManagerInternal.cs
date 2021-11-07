using myAsteroidsGame.Source.Configs;
using myAsteroidsGame.Source.GameObjects;
using myAsteroidsGame.Source.Utils;

namespace myAsteroidsGame.Source.Managers
{
    class GameManagerInternal
    {
        private static GameManagerInternal instance_ = null;
        public static GameManagerInternal GMI {
            get {
                if (instance_ == null)
                    return new GameManagerInternal();
                return instance_;
            }
        }

        private ConfigsHandler configsHandler_;
        public ConfigsHandler Configs => configsHandler_;

        private static GameManager gameManager_;
        public static GameManager GM
        {
            set => gameManager_ = value;
        }

        private GameManagerInternal() {
            configsHandler_ = new ConfigsHandler();
        }

        public void DestroyObject(GameObject gameObject)
        {
            gameManager_.DestroyObject(gameObject);
        }

        public void AddObject(GameObject gameObject)
        {
            gameManager_.AddObject(gameObject);
        }

        public object GetTexture(TextureID textureID)
        {
            return gameManager_.GetTexture(textureID);
        }  
    }
}
