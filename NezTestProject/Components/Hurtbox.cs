using Nez;
using System.Collections.Generic;

namespace NezTestProject {
    public class Hurtbox : BoxCollider {
        public enum HurtboxType {
            Player, Enemy, Envrionment
        }

        /// <summary>
        /// How many frames the hurtbox should exist for
        /// </summary>
        public uint lifeSpan;

        /// <summary>
        /// The damage to dealt per tick
        /// </summary>
        public uint damage { get; private set; }

        /// <summary>
        /// How many frames should elapse per tick
        /// </summary>
        public uint tickRate { get; private set; }

        /// <summary>
        /// Which entity created the hurtbox
        /// </summary>
        public Entity sourceEntity { get; private set; }

        /// <summary>
        /// Which entities have been damaged this tick
        /// </summary>
        public List<Entity> damagedEntities;

        /// <summary>
        /// The type of hurtbox this is. Determines what type of entities it affects
        /// </summary>
        public HurtboxType hurtboxType;

        // TODO: damageType, collisionFlags

        public Hurtbox(uint lifeSpan, uint damage, HurtboxType hurtboxType, uint tickRate = 60, Entity sourceEntity = null) : base(100, 100) {
            physicsLayer = 0;

            if (lifeSpan <= 0) {
                Debug.warn("Lifespan must be more than 0");
                return;
            }

            if (tickRate <= 0) {
                // Default the tickrate to 60 or lifespan, whichever is less
                Debug.warn("tickRate must be more than 0; Setting default");
                tickRate = lifeSpan > 60 ? 60 : lifeSpan;
            }

            this.lifeSpan = lifeSpan;
            this.damage = damage;
            this.tickRate = tickRate;
            this.hurtboxType = hurtboxType;

            if (sourceEntity != null)
                this.sourceEntity = sourceEntity;

            damagedEntities = new List<Entity>();
        }

        /// <summary>
        /// Cleanup
        /// </summary>
        public override void onRemovedFromEntity() {
            damagedEntities.Clear();
            sourceEntity = null;
        }
    }
}
