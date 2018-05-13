﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;

namespace NezTestProject {
    class PlayerEntity : Entity, IUpdatable {
        enum Animations { };
        Sprite _sprite;
        

        public PlayerEntity() {
            name = "player-entity";
            tag = (int)Tag.Player;
        }
        
        public override void onAddedToScene() {

            // Sprite
            var textureBomb = scene.content.Load<Texture2D>("Graphics\\Bomb");
            _sprite = addComponent(new Sprite(textureBomb));

            // Shadow
            var shadow = addComponent(new SpriteMime(_sprite));
            shadow.color = new Color(10, 10, 10, 80);
            shadow.material = Material.stencilRead();
            shadow.renderLayer = (int)RenderLayer.AboveDetailShadow; // Above top-most tile map graphics

            // Movement and collision
            addComponent(new CircleCollider());
            addComponent(new Mover());
            addComponent(new PlayerMovementComponent());
            addComponent(new Player());
        }

        public override void onRemovedFromScene() {
            base.onRemovedFromScene();
        }

        public override void update() {
            base.update();
        }
    }
}
