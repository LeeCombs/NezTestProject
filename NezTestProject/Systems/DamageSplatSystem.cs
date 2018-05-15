using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;

namespace NezTestProject {
    class DamageSplatSystem : EntityProcessingSystem {
        public DamageSplatSystem(Matcher matcher) : base(matcher) { }

        public override void process(Entity entity) {
            var ds = entity.getComponent<DamageSplat>();
            
            ds.lifeSpan--;
            if (ds.lifeSpan <= 0)
                ds.entity.destroy();
        }
    }
}
