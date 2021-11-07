using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using myAsteroidsGame.Source.Managers;
using myAsteroidsGame.Source.Objects;
using myAsteroidsGame.Source.GameObjects;
using myAsteroidsGame.Source.Utils;
using myAsteroidsGame.Source.Configs;

// TODO: Сделать так, чтобы объекты по коллизии или истечению времени не сразу удалялись, а лишь 
// становились не видимыми. Завезти счётчик времени, который по определённому интервалу будет очищать коллекции.
// ТАК ЖЕ СЯДЬ И СДЕЛАЙ КОЛЛИЗИИ ХОТЯ БЫ ПО РАДИУСУ!!!!
// Сделать класс (возможно запихать внутрь GameManagerInternal), в котором будут храниться тайминги спавна 
// астероидов, тайминги очистки коллекций (для каждой коллекции свой таймер!), также такую штуку завезти для пули
// и класса астероидов.

namespace myAsteroidsGame.Source
{
    class GameManager
    {
        private PlayerSpaceship spaceship_;
        private UFO followingUfo_;
        private List<GameObject> go_;
        private List<GameObject> goToDestroy_;
        private List<Asteroid> asteroids_;
        private Dictionary<TextureID, Texture2D> texture2go_;
        private List<Tuple<int, int>> asteroidsSpawnBounds_;

        private float respawnTime_;
        private float cleaningTimeDestoy_;

        public GameManager(int screenWidth, int screenHeight)
        {
            spaceship_ = new PlayerSpaceship(screenWidth / 2, screenHeight / 2);
            followingUfo_ = new UFO(screenWidth - 40, screenHeight - 40, spaceship_);
            go_ = new List<GameObject>();
            goToDestroy_ = new List<GameObject>();
            asteroids_ = new List<Asteroid>();
            texture2go_ = new Dictionary<TextureID, Texture2D>();
            asteroidsSpawnBounds_ = new List<Tuple<int, int>>();
            GameManagerInternal.GM = this;

            respawnTime_ = GameManagerConfig.RespawnTime;
            cleaningTimeDestoy_ = GameManagerConfig.CleaningTime;

            go_.Add(spaceship_);
            go_.Add(followingUfo_);
            asteroidsSpawnBounds_.Add(new Tuple<int, int>(10, screenHeight - 200));
            asteroidsSpawnBounds_.Add(new Tuple<int, int>(screenWidth - 10, screenHeight - 200));
        }

        public void LoadContent(TextureID textureID, Texture2D texture)
        {
            texture2go_[textureID] = texture;
            if (textureID == TextureID.PLAYER_SPACESHIP)
                spaceship_.Graphics.Texture = texture;
            if (textureID == TextureID.UFO)
                followingUfo_.Graphics.Texture = texture;
        }

        public void Update(float deltaTime)
        {
            UpdateObjects();
            UpdatePhysics(deltaTime);
            SpawnAsteroids();
            CleanDestroyObjectCollection();
            //Console.WriteLine($"go Count = {go_.Count}");
        }

        public void DestroyObject(GameObject gameObject)
        {
            goToDestroy_.Add(gameObject);
        }

        public void AddObject(GameObject gameObject)
        {
            go_.Add(gameObject);
        }

        public Texture2D GetTexture(TextureID textureID)
        {
            return texture2go_[textureID];
        }

        public void ProccessKeyboardInput(KeyboardState kstate)
        {
            if (kstate.IsKeyDown(Keys.Up))
                spaceship_.FlyForward();
            if (kstate.IsKeyDown(Keys.Left))
                spaceship_.Rotate(-5.0f);
            if (kstate.IsKeyDown(Keys.Right))
                spaceship_.Rotate(5.0f);
            if (kstate.IsKeyDown(Keys.Space))
                 spaceship_.Shoot();
        }

        public System.Collections.IEnumerable ActiveObjects()
        {
            foreach (var obj in go_)
                if (obj.IsActive)
                    yield return obj;
        }

        private void SpawnAsteroids()
        {
            if (asteroids_.Count == 0)
            {
                if (respawnTime_ <= 0.0f)
                {
                    Random r = new Random();
                    for (int i = 0; i < 4; i++)
                    {
                        asteroids_.Add(new BigAsteroid(asteroidsSpawnBounds_[0].Item1, r.Next(20, asteroidsSpawnBounds_[0].Item2)));
                        asteroids_.Add(new BigAsteroid(asteroidsSpawnBounds_[1].Item1, r.Next(20, asteroidsSpawnBounds_[1].Item2)));
                    }
                    go_.AddRange(asteroids_);
                    for (int i = 2; i < go_.Count; i++)
                        go_[i].Graphics.Texture = texture2go_[TextureID.ASTEROID];
                    respawnTime_ = GameManagerConfig.RespawnTime;
                }
                respawnTime_ -= 0.2f;
            }
        }

        private void UpdatePhysics(float deltaTime)
        {
            foreach (var obj in go_)
                obj.Physic.Update(deltaTime);
        }

        private void UpdateObjects()
        {
            foreach (var obj in go_)
                obj.Update();
            foreach (GameObject obj in goToDestroy_)
                go_.Find(x => x == obj).IsActive = false;
        }

        private void CleanDestroyObjectCollection()
        {
            if (cleaningTimeDestoy_ <= 0.0f)
            {
                foreach (var obj in goToDestroy_)
                    go_.Remove(obj);
                goToDestroy_.Clear();
                cleaningTimeDestoy_ = GameManagerConfig.RespawnTime;
            }
            else
                cleaningTimeDestoy_ -= 0.5f;
        }
    }
}