using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Nez;
using Nez.Sprites;
using Nez.Tiled;

namespace NezTestProject {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Core {

        Entity _playerEntity;

        public Game1() : base(width: 450, height: 300, isFullScreen: false, enableEntitySystems: true) {
            //
        }

        protected override void Initialize() {
            // Basic set up
            base.Initialize();
            debugRenderEnabled = true;
            Window.AllowUserResizing = true;


            // Set up the scene
            var myScene = new GameScene();


            // Add the player and camera
            _playerEntity = PlayerAssemblage.MakePlayer(new Vector2(350, 350));
            myScene.addEntity(_playerEntity);
            var folCam = myScene.camera.addComponent(new FollowCamera(_playerEntity, FollowCamera.CameraStyle.CameraWindow));
            

            // Spawner test
            var spawnerEntity = myScene.createEntity("spawner");
            spawnerEntity.addComponent(new EnemySpawnerComponent(EnemyAssemblage.EnemyType.Goomba));
            myScene.addEntityProcessor(new SpawnerSystem(new Matcher().all(typeof(EnemySpawnerComponent))));

            // Other entity processors
            myScene.addEntityProcessor(new CollisionSystem(new Matcher().all(typeof(Collider))));
            myScene.addEntityProcessor(new HurtboxSystem(new Matcher().all(typeof(Hurtbox))));
            myScene.addEntityProcessor(new CombatStatSystem(new Matcher().all(typeof(CombatStats))));
            
            // Entity testing
            var hbent = myScene.createEntity("hb");
            hbent.position = new Vector2(300, 300);
            hbent.addComponent(new Hurtbox(600, 1, Hurtbox.HurtboxType.Envrionment));

            var hbent2 = myScene.createEntity("hb");
            hbent2.position = new Vector2(350, 300);
            hbent2.addComponent(new Hurtbox(6000, 10, Hurtbox.HurtboxType.Player));

            // Set the scene so Nez can take over
            scene = myScene;
        }

        protected override void LoadContent() {
            // TODO: use this.Content to load your game content here
        }
        
        protected override void UnloadContent() {
            // TODO: Unload any non-ContentManager content here
        } 
                
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
