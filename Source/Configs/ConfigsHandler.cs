using System;
using System.Collections.Generic;
using System.Text;

namespace myAsteroidsGame.Source.Configs
{
    class ConfigsHandler
    {
        private IShipConfig shipConfigs_;
        public IShipConfig Ship => shipConfigs_;

        private IEnemyConfig enemyConfigs_;
        public IEnemyConfig Enemy => enemyConfigs_;

        public ConfigsHandler()
        {
            shipConfigs_ = new ShipConfigs();
            enemyConfigs_ = new EnemyConfigs();
        }
    }
}
