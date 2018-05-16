using Nez;
using Microsoft.Xna.Framework;

namespace NezTestProject {

    class GameScene : BaseScene {

        public GameScene(Vector2 playerPos) : base(playerPos) {
            //
        }

        public override void initialize() {
            _mapPath = "TestMap";
            _songPath = "Cool_Morning";
            
            addEntity(MapTransitionAssemblage.MakeMapTransition(6 * 16, 4 * 16, new Vector2(22 * 16, 7 * 16), "GameScene2", new Vector2(50, 50)));

            base.initialize();
        }

        public override void onStart() {
            base.onStart();
        }

        public override void unload() {
            base.unload();
        }

        public override void update() {
            base.update();
        }
    }
}
