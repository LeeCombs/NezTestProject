using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;

namespace NezTestProject
{
    public class SpawnerSystem : Nez.EntityProcessingSystem
    {
        public SpawnerSystem(Nez.Matcher matcher) : base(matcher){ }

        public override void process(Entity entity)
        {

            var spawner = entity.getComponent<SpawnerComponent>();
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
                var enemyEntity = entity.scene.createEntity("enemy");
                enemyEntity.position = new Microsoft.Xna.Framework.Vector2(Nez.Random.range(0, 500), Nez.Random.range(0, 500));
                enemyEntity.addComponent(new Sprite(entity.scene.content.Load<Texture2D>("Graphics\\Bomb")));
                enemyEntity.addComponent(new SimpleMover());
                // EntityFactory.createEnemy(entity.position.X, entity.position.Y, spawner.enemyType, entity);
                spawner.numSpawned++;
            }

            if (spawner.numAlive > 0)
                spawner.enabled = false;
        }
    }
}
