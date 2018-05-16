using System;
using Nez;
using Microsoft.Xna.Framework;

namespace NezTestProject {
    class MapTransitionSystem : EntityProcessingSystem {
        public MapTransitionSystem(Matcher matcher) : base(matcher) { }

        public override void process(Entity entity) {
            // Check for overlapping entities. If it's tagged as a player, and the transition is
            // enabled, transition into the target scene.
            var mtc = entity.getComponent<MapTransition>();
            var colliders = Physics.boxcastBroadphase(entity.getComponent<Collider>().bounds);
            foreach (var col in colliders) {
                if (entity.getComponent<Collider>().collidesWith(col, out CollisionResult colRes)) {
                    if (col.entity.tag == (int)Tag.Player)
                        if (mtc.Enabled) {
                            mtc.Enabled = false;
                            Type type = Type.GetType("NezTestProject." + mtc.TargetSceneName, true);
                            Core.startSceneTransition(new WindTransition(() => (Scene)Activator.CreateInstance(type, new Vector2(50, 50))));
                        }
                }
            }
        }
    }
}
