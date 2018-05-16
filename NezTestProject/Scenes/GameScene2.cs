
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
            
            addEntity(MapTransitionAssemblage.MakeMapTransition(4 * 16, 4 * 16, new Vector2(16 * 16, 15 * 16), "GameScene", new Vector2(50, 50)));

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
