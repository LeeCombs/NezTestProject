using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Nez;
using Nez.Sprites;

namespace NezTestProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Core
    {
        public Game1() : base(width: 640, height: 384, isFullScreen: false, enableEntitySystems: true)
        {
            //
        }

        protected override void Initialize()
        {
            base.Initialize();
            

            Window.AllowUserResizing = true;
            var myScene = Scene.createWithDefaultRenderer(Color.CornflowerBlue);

            var textureBox = myScene.content.Load<Texture2D>("Graphics\\Box");
            var textureBomb = myScene.content.Load<Texture2D>("Graphics\\Bomb");

            var spawnerEntity = myScene.createEntity("spawner");
            spawnerEntity.addComponent(new SpawnerComponent(1));
            
            myScene.addEntityProcessor(new SpawnerSystem(new Matcher().all(typeof(SpawnerComponent))));

            var entityOne = myScene.createEntity("entity-one");
            entityOne.position = new Vector2(250, 250);
            entityOne.addComponent(new Sprite(textureBox));
            entityOne.addComponent(new SimpleMover());

            var entityTwo = myScene.createEntity("entity-two");
            entityTwo.position = new Vector2(300, 300);
            entityTwo.addComponent(new Sprite(textureBomb));
            

            var folCam = myScene.camera.addComponent(new FollowCamera(entityOne));

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
