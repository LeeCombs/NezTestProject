using Nez;
using Microsoft.Xna.Framework;

namespace NezTestProject {
    class MapTransition : Component {
        public string TargetMapName { get; private set; }
        public string TargetSceneName { get; private set; }
        public Vector2 TargetPosition { get; private set; }
        public bool Enabled;

        public MapTransition(string targetSceneName, Vector2 targetPosition) {
            TargetSceneName = targetSceneName;
            TargetPosition = targetPosition;
            Enabled = true;
        }
    }
}
