using Nez;
using Microsoft.Xna.Framework;

namespace NezTestProject {
    public static class MapTransitionAssemblage {
        public static Entity MakeMapTransition(int width, int height, Vector2 position, string targetScene, Vector2 targetPosition) {
            Entity mapEnt = new Entity("map_transition");
            var col = new BoxCollider(width, height);
            col.physicsLayer = 0;
            mapEnt.addComponent(col);
            mapEnt.position = new Vector2(position.X + width / 2, position.Y + height / 2);
            mapEnt.addComponent(new MapTransition(targetScene, targetPosition));
            return mapEnt;
        }
    }
}
