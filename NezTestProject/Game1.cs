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

        public Game1() : base(width: 900, height: 600, isFullScreen: false, enableEntitySystems: true)
        {
            //
        }

        protected override void Initialize()
        {
            base.Initialize();
            debugRenderEnabled = true;

            Window.AllowUserResizing = true;
            var myScene = Scene.createWithDefaultRenderer(Color.CornflowerBlue);

            var textureBox = myScene.content.Load<Texture2D>("Graphics\\Box");
            var textureBomb = myScene.content.Load<Texture2D>("Graphics\\Bomb");

            var spawnerEntity = myScene.createEntity("spawner");
            spawnerEntity.addComponent(new EnemySpawnerComponent(EnemyManager.EnemyType.Goomba));
            
            myScene.addEntityProcessor(new SpawnerSystem(new Matcher().all(typeof(EnemySpawnerComponent))));

            var entityOne = myScene.createEntity("entity-one");
            entityOne.position = new Vector2(250, 250);
            entityOne.addComponent(new Sprite(textureBomb));
            entityOne.addComponent(new SimpleMover());
            entityOne.addComponent(new BoxCollider());

            var e2 = myScene.createEntity("bob");
            e2.position = new Vector2(500, 500);
            e2.addComponent(new Sprite(textureBox));
            e2.addComponent(new BoxCollider());
            
            

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

        float coolDown = 1;
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (scene != null) {

                foreach (var ent in scene.entities.entitiesOfType<EnemyEntity>()) {
                    
                    // ent.getComponent<HealthComponent>().damage(1);
                    CollisionResult res;
                    Vector2 vec = new Vector2();
                    if (ent.getComponent<Collider>().collidesWithAny(ref vec, out res)) {
                        Debug.log("res col ent: {0}", res.collider.entity.name);
                        Debug.log("Col res: {0}", res);
                        Debug.log("--------");
                    }
                };
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
