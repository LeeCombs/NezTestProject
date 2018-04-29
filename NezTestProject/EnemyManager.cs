using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NezTestProject {
    public static class EnemyManager {
        public enum EnemyType {
            Base, Goomba, Bat
        }

        public static EnemyEntity MakeEnemy(EnemyType enemy, Vector2 position)
        {
            // grab texture based on supplied enemy
            Texture2D enemyTexture = Nez.Core.content.Load<Texture2D>("Graphics\\Bomb");
            var ent = new EnemyEntity(position, enemyTexture);
            
            switch (enemy) {
                case EnemyType.Base:
                    //
                    break;
                case EnemyType.Goomba:
                    // load Goomba texture
                    // 
                    break;
                case EnemyType.Bat:
                    // load Bat texture
                    // ent.addComponent(new FlyingComponent());
                    break;
                default:
                    // Error
                    break;
            }
            
            return ent;
        }
        
    }
}
