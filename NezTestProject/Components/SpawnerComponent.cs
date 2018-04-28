using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NezTestProject
{
    public class SpawnerComponent : Nez.Component
    {
        public float cooldown = -1;
        public int minInterval = 2;
        public int maxInterval = 60;
        public int minCount = 1;
        public int maxCount = 1;
        // enemyType
        public int numSpawned = 0;
        public int numAlive = 0;

        public SpawnerComponent(int type)
        {
            // this.type = type
        }
    }
}
