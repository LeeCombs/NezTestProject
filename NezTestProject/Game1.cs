using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Nez;
using Nez.Sprites;
using Nez.Tiled;

namespace NezTestProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Core
    {

        PlayerEntity _playerEntity;

        public Game1() : base(width: 450, height: 300, isFullScreen: false, enableEntitySystems: true)
        {
            
        }

        protected override void Initialize()
        {
            base.Initialize();
            Screen.setSize(450 * 2, 300 * 2);
            debugRenderEnabled = false;

            Window.AllowUserResizing = true;
            var myScene = Scene.createWithDefaultRenderer(Color.CornflowerBlue);
            myScene.setDesignResolution(450, 300, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);

            var textureBox = myScene.content.Load<Texture2D>("Graphics\\Box");
            var textureBomb = myScene.content.Load<Texture2D>("Graphics\\Bomb");

            // Spawner test
            var spawnerEntity = myScene.createEntity("spawner");
            spawnerEntity.addComponent(new EnemySpawnerComponent(EnemyManager.EnemyType.Goomba));
            myScene.addEntityProcessor(new SpawnerSystem(new Matcher().all(typeof(EnemySpawnerComponent))));
            
            // Tiled map loading
            var tiledMap = myScene.content.Load<TiledMap>("Maps\\TestMap");
            var tiledEntity = myScene.createEntity("tiled-map");
            var tiledMapComponent = tiledEntity.addComponent(new TiledMapComponent(tiledMap, "Collision"));
            tiledMapComponent.setLayersToRender(new string[] { "Objects", "Terrain" });
            // Render below everything
            tiledMapComponent.renderLayer = 10;

            // Render above-details later above the player
            var tiledDetailsComp = tiledEntity.addComponent(new TiledMapComponent(tiledMap));
            tiledDetailsComp.setLayersToRender("AboveDetail");
            tiledDetailsComp.renderLayer = -1;
            tiledDetailsComp.material = Material.stencilWrite();
            tiledDetailsComp.material.effect = myScene.content.loadNezEffect<SpriteAlphaTestEffect>();

            // Adding the player
            _playerEntity = new PlayerEntity();
            _playerEntity.position = new Vector2(350, 350);
            myScene.addEntity(_playerEntity);

            var folCam = myScene.camera.addComponent(new FollowCamera(_playerEntity));

            
            // Set the scene so Nez can take over
            scene = myScene;
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            // spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
                
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here

            if (scene != null) {
                /*
                CollisionResult colRes;
                Vector2 deltaMovement = new Vector2();
                if (_playerEntity.getComponent<Collider>().collidesWithAny(out colRes)) {
                    Debug.log("colRes: {0}", colRes);
                }
                _playerEntity.position += deltaMovement;
                */
            }
            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
