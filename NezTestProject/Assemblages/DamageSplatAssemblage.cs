using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NezTestProject {
    public enum DamageSplatType {
        Player, Enemy
    }

    public static class DamageSplatAssemblage {

        public static Entity GetDamageSplat(DamageSplatType splatType, int damageValue, Vector2 position) {
            var splatEntity = new Entity("damage_splat");
            splatEntity.position = position;
            splatEntity.addComponent(new DamageSplat(60));

            var text = splatEntity.addComponent(new Text(Graphics.instance.bitmapFont, damageValue.ToString(), new Vector2(-5, -5), Color.White));
            text.renderLayer = -15;
            
            var texture = Core.content.Load<Texture2D>("Graphics\\" + splatType.ToString() + "Splat");
            var spr = splatEntity.addComponent(new Sprite(texture));
            spr.renderLayer = -14;
            
            return splatEntity;
        }
    }
}
