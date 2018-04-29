
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez.Sprites;

namespace NezTestProject {
    class EnemyEntity : Nez.Entity {
        public EnemyEntity(Vector2 position, Texture2D texture) {
            addComponent(new Sprite(texture));
            addComponent(new SimpleMover());
        }
    }
}
