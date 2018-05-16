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
