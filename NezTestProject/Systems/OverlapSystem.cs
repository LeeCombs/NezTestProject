using Nez;

namespace NezTestProject {
    class OverlapSystem : EntityProcessingSystem {

        public OverlapSystem(Matcher matcher) : base(matcher) { }

        public override void process(Entity entity) {
            // Detect overlaps and do stuff with it

            #region Hurtboxes
            var hurtboxes = entity.getComponents<Hurtbox>();

            foreach (Hurtbox hb in hurtboxes) {
                
                var colliders = Physics.boxcastBroadphase(entity.getComponent<Collider>().bounds);

                CollisionResult colRes;
                foreach (var col in colliders) {
                    if (entity.getComponent<Collider>().collidesWith(col, out colRes)) {
                        Debug.log("hbcolres: {0}", col.entity.GetType());

                        // Only operate on entities that have health components
                        if (col.entity.getComponent<HealthComponent>() != null) {

                            switch (hb.hurtboxType) {
                                case Hurtbox.HurtboxType.Envrionment:
                                    // Hurt everything
                                    break;
                                case Hurtbox.HurtboxType.Enemy:
                                    // Hurt player
                                    if (col.entity.tag == (int)Tag.Player) {
                                        //
                                    }
                                    // Sometimes other enemies?
                                    break;
                                case Hurtbox.HurtboxType.Player:
                                    // Damage enemies
                                    if (col.entity.tag == (int)Tag.Enemy) {
                                        //
                                    }
                                    break;
                                default:
                                    //
                                    break;
                            }
                        }
                    }
                }
            }
            #endregion

            //
        }
    }
}
