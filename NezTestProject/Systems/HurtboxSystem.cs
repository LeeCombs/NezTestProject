using Nez;

namespace NezTestProject {
    public class HurtboxSystem : EntityProcessingSystem {

        public HurtboxSystem(Matcher matcher) : base(matcher) { }

        public override void process(Entity entity) {
            foreach (Hurtbox hb in entity.getComponents<Hurtbox>()) {

                #region Hurtbox life and tick management

                // A tick has occured, reset flags and continue on
                if (hb.lifeSpan % hb.tickRate == 0)
                    hb.damagedEntities.Clear();

                // Cleanup the hurtbox if it's life is over
                if (hb.lifeSpan > 0)
                    hb.lifeSpan--;

                if (hb.lifeSpan <= 0) {
                    hb.enabled = false;
                    hb.entity.removeComponent(hb);
                    continue;
                }
                #endregion


                #region Overlapping entities that have CombatStats

                var colliders = Physics.boxcastBroadphase(entity.getComponent<Collider>().bounds);
                foreach (var col in colliders) {
                    if (entity.getComponent<Collider>().collidesWith(col, out CollisionResult colRes)) {

                        // Only operate on entities that have health components
                        if (col.entity.getComponent<CombatStats>() != null) {

                            // Only apply damage to a specific entity once per hb.tick
                            if (hb.damagedEntities.Contains(col.entity))
                                continue;
                            hb.damagedEntities.Add(col.entity);

                            // Damage the colliding entity and create a damage splat entity
                            var cbs = col.entity.getComponent<CombatStats>();
                            int dmgDealt = 0;
                            switch (hb.hurtboxType) {
                                case Hurtbox.HurtboxType.Envrionment:
                                    // Hurt everything
                                    dmgDealt = cbs.DealDamage((int)hb.damage);
                                    break;
                                case Hurtbox.HurtboxType.Enemy:
                                    // Hurt player
                                    if (col.entity.tag == (int)Tag.Player) {
                                        dmgDealt = cbs.DealDamage((int)hb.damage);
                                        Debug.log("Damaged player for {0}", dmgDealt);
                                        scene.addEntity(DamageSplatAssemblage.GetDamageSplat(DamageSplatType.Player, dmgDealt, col.entity.position));
                                    }
                                    // TODO: Sometimes other enemies?
                                    break;
                                case Hurtbox.HurtboxType.Player:
                                    // Damage enemies
                                    if (col.entity.tag == (int)Tag.Enemy) {
                                        dmgDealt = cbs.DealDamage((int)hb.damage);
                                        Debug.log("Damaged enemy for {0}", dmgDealt);
                                        scene.addEntity(DamageSplatAssemblage.GetDamageSplat(DamageSplatType.Enemy, dmgDealt, col.entity.position));
                                    }
                                    break;
                                default:
                                    Debug.warn("Hurtbox hurtType not supported: {0}", hb.hurtboxType);
                                    break;
                            }
                        }
                    }
                }
                #endregion

                //
            }
        }
    }
}
