using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NezTestProject
{
    public class EnemySpawnerComponent : Nez.Component
    {
        public float cooldown = -1;
        public int minInterval = 1;
        public int maxInterval = 60;
        public int minCount = 1;
        public int maxCount = 10;
        public EnemyManager.EnemyType enemyType;
        public int numSpawned = 0;
        public int numAlive = 0;

        public EnemySpawnerComponent(EnemyManager.EnemyType enemyType)
        {
            this.enemyType = enemyType;
        }
    }
}
