
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

            var mtEnt = createEntity("map_transition");
            mtEnt.addComponent(new BoxCollider(4 * 16, 4 * 16));
            mtEnt.addComponent(new MapTransition("GameScene", new Vector2(50, 50)));
            mtEnt.position = new Vector2(16 * 16, 15 * 16);
            mtEnt.getComponent<BoxCollider>().physicsLayer = 0;

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
