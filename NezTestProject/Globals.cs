//---------------------------
// A whatever class to hold global
// definitions for the game
//---------------------------

namespace NezTestProject {

    public enum RenderLayer {
        AboveDetailShadow = -2,
        AboveDetail = -1,
        Player = 1,
        TileMap = 10
    }

    public enum Tag {
        Enemy,
        Player,
        Environment
    }

    public class Globals {
        public const int TILE_SIZE = 16;
    }
}

