using System;
using System.Collections.Generic;
using System.Text;

namespace myAsteroidsGame.Source.Configs
{
    class ShipConfigs : IShipConfig
    {
        public float MaxSpeed => 1000.0f;

        public float Rotation => 5.0f;

        public float Acceleration => 500.0f;

        public float Friction => 250.0f;

        public float DelayPerShoot => 3.0f;

        public float BulletLifeTime => 10.0f;

        public float BulletMaxSpeed => 500.0f;
    }

    class EnemyConfigs : IEnemyConfig
    {
        public float UFOMaxSpeed => 200.0f;

        public float AsteroidMaxSpeed => 100.0f;

        public float AsteroidShardMaxSpeed => 150.0f;
    }
}
