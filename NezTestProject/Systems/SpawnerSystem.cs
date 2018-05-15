using Nez;
using Microsoft.Xna.Framework;

namespace NezTestProject {
    public class SpawnerSystem : EntityProcessingSystem {
        public SpawnerSystem(Matcher matcher) : base(matcher) { }

        public override void process(Entity entity) {

            var spawner = entity.getComponent<EnemySpawnerComponent>();
            if (spawner.numAlive <= 0)
                spawner.enabled = true;

            if (!spawner.enabled)
                return;

            if (spawner.cooldown == -1)
                spawner.cooldown = Random.range(1, 3);

            spawner.cooldown -= Time.deltaTime;
            if (spawner.cooldown <= 0)
            {
                spawner.cooldown = Random.range(1, 2);

                var ent = EnemyAssemblage.MakeEnemy(spawner.enemyType, new Vector2(Random.range(350, 550), Random.range(150, 350)));
                scene.addEntity(ent);
                
                spawner.numSpawned++;
            }

            if (spawner.numAlive > 0)
                spawner.enabled = false;
        }
    }
}
