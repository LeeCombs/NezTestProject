using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NezTestProject {
    class EnemyManager {
        public enum Enemies {
            Base, Goomba, Bat
        }

        public EnemyEntity MakeEnemy(Enemies enemy, Vector2 position)
        {
            // grab texture based on supplied enemy
            Texture2D enemyTexture = Nez.Core.content.Load<Texture2D>("Graphics\\Bomb");
            var ent = new EnemyEntity(position, enemyTexture);
            
            switch (enemy) {
                case Enemies.Base:
                    //
                    break;
                case Enemies.Goomba:
                    // load Goomba texture
                    // 
                    break;
                case Enemies.Bat:
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
