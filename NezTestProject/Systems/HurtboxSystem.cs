using Nez;

namespace NezTestProject {
    public class HurtboxSystem : EntityProcessingSystem {

        public HurtboxSystem(Matcher matcher) : base(matcher) { }

        public override void process(Entity entity) {
            var hurtboxes = entity.getComponents<Hurtbox>();

            foreach (Hurtbox hb in hurtboxes) {

                #region Entity overlap
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
                                    // Damage player
                                    if (col.entity.tag == (int)Tag.Player) {
                                        //
                                    }
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

                            // if (col.entity.GetType() == typeof(EnemyEntity))
                            //     Debug.log("I overlap an enemy!");
                            // if (col.entity.GetType() == typeof(PlayerEntity))
                            //    Debug.log("I overlap a player!");
                        }

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
