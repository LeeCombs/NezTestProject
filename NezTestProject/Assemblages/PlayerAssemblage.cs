using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace NezTestProject {
    public static class PlayerAssemblage {
        enum Animations { };

        public static Entity MakePlayer(Vector2 position) {
            var playerEntity = new Entity("player");
            playerEntity.tag = (int)Tag.Player;
            playerEntity.position = position;

            // Sprite
            var playerTexture = Core.content.Load<Texture2D>("Graphics\\Bomb");
            var playerSprite = playerEntity.addComponent(new Sprite(playerTexture));
            
            // Shadow
            var shadow = playerEntity.addComponent(new SpriteMime(playerSprite));
            shadow.color = new Color(10, 10, 10, 80);
            shadow.material = Material.stencilRead();
            shadow.renderLayer = (int)RenderLayer.AboveDetailShadow;
            
            // Movement and collision
            playerEntity.addComponent(new CircleCollider());
            playerEntity.addComponent(new Mover());
            playerEntity.addComponent(new PlayerMovementComponent());
            playerEntity.addComponent(new Player());
            playerEntity.addComponent(new CombatStats(1000, 100, 10));
            
            return playerEntity;
        }
    }
}
