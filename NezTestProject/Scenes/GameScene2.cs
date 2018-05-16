
using Microsoft.Xna.Framework;
using Nez;

namespace NezTestProject {

    class GameScene2 : BaseScene {

        public GameScene2(Vector2 playerPos) : base(playerPos) {
            //
        }

        public override void initialize() {
            _mapPath = "map_2";
            _songPath = "Warning";

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
