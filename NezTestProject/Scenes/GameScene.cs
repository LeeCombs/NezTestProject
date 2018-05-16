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

            var mtEnt = createEntity("map_transition");
            mtEnt.addComponent(new BoxCollider(6 * 16, 4 * 16));
            mtEnt.addComponent(new MapTransition("GameScene2", new Vector2(50 ,50)));
            mtEnt.position = new Vector2(22 * 16, 7 * 16);
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
