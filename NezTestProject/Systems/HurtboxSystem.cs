using Nez;

namespace NezTestProject {
    public class HurtboxSystem : EntityProcessingSystem {

        public HurtboxSystem(Matcher matcher) : base(matcher) { }

        public override void process(Entity entity) {
            var hurtboxes = entity.getComponents<Hurtbox>();

            foreach (Hurtbox hb in hurtboxes) {

                #region Other entities overlapping
                var colliders = Physics.boxcastBroadphase(entity.getComponent<Collider>().bounds);

                CollisionResult colRes;
                foreach (var col in colliders) {
                    if (entity.getComponent<Collider>().collidesWith(col, out colRes)) {
                        Debug.log("hbcolres: {0}", col.entity.GetType());
                        // If enviro, damage everything...
                        // If enemy, damage player
                        // If player, damage enemy
                        // Enemy vs enemy? Ensure it doesn't effect the sourceEntity?
                    }
                }

                #endregion


                #region Hurtbox lifespan and tick rate

                if (hb.lifeSpan % hb.tickRate == 0) {
                    // A tick has occured, reset flags and continue on
                    hb.damagedEntities.Clear();
                }

                // Cleanup the hurtbox if it's life is over
                if (hb.lifeSpan > 0)
                    hb.lifeSpan--;

                if (hb.lifeSpan <= 0) {
                    hb.enabled = false;
                    hb.entity.removeComponent(hb);
                }

                #endregion
            }
        }
    }
}
