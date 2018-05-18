using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Nez;
using Nez.Tiled;
using Nez.UI;

namespace NezTestProject {
    class BaseScene : Scene {

        public Entity PlayerEntity;
        protected string _mapPath, _songPath;
        protected Vector2 _playerPos;

        public BaseScene(Vector2 playerPos) {
            _playerPos = playerPos;

            // UI testing
            UIManager.SetupUI(this);
        }

        public override void initialize() {

            // Set up the scene
            setDesignResolution(512, 256, SceneResolutionPolicy.ShowAllPixelPerfect);
            Screen.setSize(512 * 2, 256 * 2);
            clearColor = Color.CornflowerBlue;
            addRenderer(new DefaultRenderer());

            loadMap();
            loadMusic();
            loadEntityProcessors();
        }

        public override void onStart() {
            // Called when scene is set as active scene

            // Testing
            PlayerEntity = PlayerAssemblage.MakePlayer(_playerPos);
            addEntity(PlayerEntity);
            camera.addComponent(new FollowCamera(PlayerEntity, FollowCamera.CameraStyle.CameraWindow));
        }

        public override void unload() {
            // Unload here
        }

        public override void update() {
            base.update();
        }

        #region Helpers

        private void loadMap() {
            // Load the Tiled map, and render it below everything
            var tiledMap = content.Load<TiledMap>("Maps\\" + _mapPath);
            var tiledEntity = createEntity("tiled-map");
            var tiledMapComponent = tiledEntity.addComponent(new TiledMapComponent(tiledMap, "Collision"));
            tiledMapComponent.setLayersToRender(new string[] { "Objects", "Terrain", "Background" });
            tiledMapComponent.renderLayer = (int)RenderLayer.TileMap;

            // Render above-details later above the player
            var tiledDetailsComp = tiledEntity.addComponent(new TiledMapComponent(tiledMap));
            tiledDetailsComp.setLayersToRender("AboveDetail");
            tiledDetailsComp.renderLayer = (int)RenderLayer.AboveDetail;
            tiledDetailsComp.material = Material.stencilWrite();
            tiledDetailsComp.material.effect = content.loadNezEffect<SpriteAlphaTestEffect>();

            // Creat MapTransition Entities based on the MapTransitions object layer
            var mapTraObj = tiledMap.getObjectGroup("MapTransitions");
            foreach (var o in mapTraObj.objects) {
                Vector2 pos = new Vector2(o.x, o.y);
                Vector2 targetPos = new Vector2(int.Parse(o.properties["targetXTile"]) * Globals.TILE_SIZE, int.Parse(o.properties["targetYTile"]) * Globals.TILE_SIZE);
                addEntity(MapTransitionAssemblage.MakeMapTransition(o.width, o.height, pos, o.properties["targetScene"], targetPos));
            }
        }

        private void loadMusic() {
            SoundManager.PlayMusic(_songPath);
        }

        private void loadEntityProcessors() {
            // Order matters
            addEntityProcessor(new CollisionSystem(new Matcher().all(typeof(Collider))));
            addEntityProcessor(new HurtboxSystem(new Matcher().all(typeof(Hurtbox))));
            addEntityProcessor(new SpawnerSystem(new Matcher().all(typeof(EnemySpawnerComponent))));
            addEntityProcessor(new CombatStatSystem(new Matcher().all(typeof(CombatStats))));
            addEntityProcessor(new DamageSplatSystem(new Matcher().all(typeof(DamageSplat))));
            addEntityProcessor(new MapTransitionSystem(new Matcher().all(typeof(MapTransition))));
        }

        #endregion
    }
}
