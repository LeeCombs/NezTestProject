using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace NezTestProject {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Core {
        

        public Game1() : base(width: 450, height: 300, isFullScreen: false, enableEntitySystems: true) {
            //
        }

        protected override void Initialize() {
            // Basic set up
            base.Initialize();
            debugRenderEnabled = true;
            Window.AllowUserResizing = true;


            // Set up the scene
            var myScene = new GameScene(new Vector2(2 * 16, 5 * 16));
            
            // Spawner test
            // var spawnerEntity = myScene.createEntity("spawner");
            // spawnerEntity.addComponent(new EnemySpawnerComponent(EnemyAssemblage.EnemyType.Goomba));
            
            // Entity testing
            var hbent = myScene.createEntity("hb");
            hbent.position = new Vector2(300, 300);
            hbent.addComponent(new Hurtbox(600, 1, Hurtbox.HurtboxType.Enemy));

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

            if (Input.isKeyPressed(Keys.OemPlus))
                SoundManager.RaiseVolume();
            if (Input.isKeyPressed(Keys.OemMinus))
                SoundManager.LowerVolume();

            if (Input.isKeyPressed(Keys.M))
                SoundManager.PlayMusic(SoundManager.MusicTrack.Cool_Morning);

            if (Input.isKeyPressed(Keys.T))
                startSceneTransition(new WindTransition(() => new GameScene2(new Vector2(2 * 16, 2 * 16))));
            

            if (Input.isKeyPressed(Keys.O)) {
                var transition = new SquaresTransition();
                transition.onScreenObscured = sceneMethod;
                Core.startSceneTransition(transition);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        #region testing
        public void sceneMethod() {
            Debug.log("SCENE TRANSITION METHOD");
            // move Camera to new location
            // reset Entities
            // etc.
        }
        #endregion
    }
}
