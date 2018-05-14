using Nez;

namespace NezTestProject {
    public class HurtboxSystem : EntityProcessingSystem {

        public HurtboxSystem(Matcher matcher) : base(matcher) { }

        public override void process(Entity entity) {
            foreach (Hurtbox hb in entity.getComponents<Hurtbox>()) {

                // A tick has occured, reset flags and continue on
                if (hb.lifeSpan % hb.tickRate == 0)
                    hb.damagedEntities.Clear();

                // Cleanup the hurtbox if it's life is over
                if (hb.lifeSpan > 0)
                    hb.lifeSpan--;

                if (hb.lifeSpan <= 0) {
                    hb.enabled = false;
                    hb.entity.removeComponent(hb);
                }
            }
        }
    }
}
