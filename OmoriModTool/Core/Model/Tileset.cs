using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

namespace OmoriModTool.Core.Model
{
    public class Tileset
    {
        public int columns { get; set; }
        public string image { get; set; }
        public int imageheight { get; set; }
        public int imagewidth { get; set; }
        public int margin { get; set; }
        public string name { get; set; }
        public int spacing { get; set; }
        public int tilecount { get; set; }
        public int tileheight { get; set; }
        // public Tileproperties tileproperties { get; set; }
        // public Tilepropertytypes tilepropertytypes { get; set; }
        public int tilewidth { get; set; }
        public string type { get; set; }

        [JsonIgnore]
        public Texture2D texture;
    }
}
