using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmoriModTool.Core
{
    public class TileMap
    {
        public string source { get; set; }
        public int height { get; set; }
        public List<Layer> layers { get; set; }
        public int nextobjectid { get; set; }
        public string orientation { get; set; }
        public string renderorder { get; set; }
        public string tiledversion { get; set; }
        public int tileheight { get; set; }
        public List<Tileset> tilesets { get; set; }
        public int tilewidth { get; set; }
        public string type { get; set; }
        public int version { get; set; }
        public int width { get; set; }

        public class Properties
        {
            public string priority { get; set; }
            public string zIndex { get; set; }
            public string collision { get; set; }
            public string regionId { get; set; }
        }

        public class Propertytypes
        {
            public string priority { get; set; }
            public string zIndex { get; set; }
            public string collision { get; set; }
            public string regionId { get; set; }
        }

        public class Layer
        {
            public List<int> data { get; set; }
            public int height { get; set; }
            public string name { get; set; }
            public double opacity { get; set; }
            public Properties properties { get; set; }
            public Propertytypes propertytypes { get; set; }
            public string type { get; set; }
            public bool visible { get; set; }
            public int width { get; set; }
            public int x { get; set; }
            public int y { get; set; }
        }

        public class Tileset
        {
            public int firstgid { get; set; }
            public string source { get; set; }
        }
    }
}
