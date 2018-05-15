using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace NezTestProject {
    public static class EnemyAssemblage {
        public enum EnemyType {
            Base, Goomba, Bat
        }

        public static Entity MakeEnemy(EnemyType enemyType, Vector2 position)
        {
            // Setup the base enemy entity
            var enemyEntity = new Entity("enemy"); // TODO: ("enemy-" + enemy.ToString()); ?
            enemyEntity.tag = (int)Tag.Enemy;
            enemyEntity.position = position;
            enemyEntity.addComponent(new Mover());

            // Update these values to plug into default components
            int hpValue = 0, strValue = 0, defValue = 0;
            string texturePath = "Graphics\\";
            
            // Enemy-unique setup
            switch (enemyType) {
                case EnemyType.Base:
                    // TODO: Figure out what to do with this
                    break;
                case EnemyType.Goomba:
                    hpValue = 60;
                    texturePath += "Bomb";
                    break;
                case EnemyType.Bat:
                    hpValue = 30;
                    texturePath += "Bat";
                    // ent.addComponent(new FlyingComponent());
                    break;
                default:
                    Debug.error("EnemyType not yet set up: {0}", enemyType.ToString());
                    return null;
            }

            // Health Component
            if (hpValue <= 0 || strValue <= 0 || defValue <= 0)
                Debug.warn("Not all enemy stat values not set for type {0}", enemyType.ToString());
            enemyEntity.addComponent(new CombatStats(hpValue, strValue, defValue));

            // Sprite Component
            if (String.Equals(texturePath, "Graphics\\")) {
                Debug.warn("Enemy texture path not set for type {0]", enemyType.ToString());
                texturePath += "DefaultEnemyGraphic";
            }
            Texture2D enemyTexture = Core.content.Load<Texture2D>(texturePath);
            enemyEntity.addComponent(new Sprite(enemyTexture));
            
            // Temporary addition(s)
            enemyEntity.addComponent(new PlayerMovementComponent());
            enemyEntity.addComponent(new CircleCollider());
            
            return enemyEntity;
        }
        
    }
}
