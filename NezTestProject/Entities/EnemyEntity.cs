
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez.Sprites;

namespace NezTestProject {
    public class EnemyEntity : Nez.Entity {
        public EnemyEntity(Vector2 position, Texture2D texture) {
            this.name = "enemy";
            this.position = position;
            addComponent(new Sprite(texture));
            addComponent(new SimpleMover());
            addComponent(new HealthComponent(60));
        }
    }
}
