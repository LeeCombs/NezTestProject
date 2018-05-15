using Nez;

namespace NezTestProject {
    class CombatStatSystem : EntityProcessingSystem {

        public CombatStatSystem(Matcher matcher) : base(matcher) { }

        public override void process(Entity entity) {
            var cbs = entity.getComponent<CombatStats>();

            // If the entity doesn't have any health, it's gotta die
            // TODO: Determine how and where to handle death animations and cleanup
            if (cbs.Health <= 0) {
                Debug.log("Killing enemy {0}", entity.name);
                entity.destroy();
            }
        }
    }
}
