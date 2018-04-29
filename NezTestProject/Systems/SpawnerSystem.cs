using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;

namespace NezTestProject
{
    public class SpawnerSystem : Nez.EntityProcessingSystem
    {
        public SpawnerSystem(Nez.Matcher matcher) : base(matcher){ }

        public override void process(Entity entity)
        {

            var spawner = entity.getComponent<EnemySpawnerComponent>();
            if (spawner.numAlive <= 0)
                spawner.enabled = true;

            if (!spawner.enabled)
                return;

            if (spawner.cooldown == -1)
                spawner.cooldown = Nez.Random.range(1, 3);

            spawner.cooldown -= Time.deltaTime;
            if (spawner.cooldown <= 0)
            {
                spawner.cooldown = Nez.Random.range(1, 2);

                var ent = EnemyManager.MakeEnemy(spawner.enemyType, new Vector2(Nez.Random.range(0, 500), Nez.Random.range(0, 500)));
                scene.addEntity(ent);
                
                spawner.numSpawned++;
            }

            if (spawner.numAlive > 0)
                spawner.enabled = false;
        }
    }
}
