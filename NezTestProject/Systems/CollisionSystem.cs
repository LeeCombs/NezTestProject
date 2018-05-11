using Nez;
using System;
using Microsoft.Xna.Framework;

namespace NezTestProject {
    public class CollisionSystem : EntityProcessingSystem {
        public CollisionSystem(Matcher matcher) : base(matcher) { }

        public override void process(Entity entity) {
            Debug.log("col Entity {0}", entity.GetType());
        }
    }
}
