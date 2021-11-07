namespace myAsteroidsGame.Source.Configs
{
    interface IShipConfig
    {
        float MaxSpeed { get; }

        float Rotation { get; }

        float Acceleration { get; }

        float Friction { get; }

        float DelayPerShoot { get; }

        float BulletLifeTime { get; }

        float BulletMaxSpeed { get; }

    }

    interface IEnemyConfig
    {
        float UFOMaxSpeed { get; }

        float AsteroidMaxSpeed { get; }

        float AsteroidShardMaxSpeed { get; }
    }
}
