﻿using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;

namespace NezTestProject {

    class GameScene : Scene {

        public GameScene() {
            //
        }

        public override void initialize() {
            base.initialize();

            // Set up the scene
            setDesignResolution(512, 256, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
            Screen.setSize(512 * 2, 256 * 2);
            clearColor = Color.CornflowerBlue;
            addRenderer(new DefaultRenderer());

            // Load the Tiled map
            var tiledMap = content.Load<TiledMap>("Maps\\TestMap");
            var tiledEntity = createEntity("tiled-map");
            var tiledMapComponent = tiledEntity.addComponent(new TiledMapComponent(tiledMap, "Collision"));
            tiledMapComponent.setLayersToRender(new string[] { "Objects", "Terrain" });
            // Render below everything
            tiledMapComponent.renderLayer = (int)Enums.RenderLayer.TileMap;

            // Render above-details later above the player
            var tiledDetailsComp = tiledEntity.addComponent(new TiledMapComponent(tiledMap));
            tiledDetailsComp.setLayersToRender("AboveDetail");
            tiledDetailsComp.renderLayer = (int)Enums.RenderLayer.AboveDetail;
            tiledDetailsComp.material = Material.stencilWrite();
            tiledDetailsComp.material.effect = content.loadNezEffect<SpriteAlphaTestEffect>();
        }
    }
}