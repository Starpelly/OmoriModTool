using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using OmoriModTool.Core.Model;
using Newtonsoft.Json;

namespace OmoriModTool
{
    public class TileMapView
    {
        public Core.TileMap TileMap;

        List<Tileset> tilesets = new List<Tileset>();

        Texture2D tex = Rectangle(Color.Wheat, 32, 32);

        public TileMapView(Core.TileMap tileMap)
        {
            this.TileMap = tileMap;
            for (int i = 0; i < tileMap.tilesets.Count; i++)
            {
                string tilesetFile = (Path.GetDirectoryName(tileMap.source) + "/" + tileMap.tilesets[i].source).Replace("\\", "/");
                Tileset tileset = JsonConvert.DeserializeObject<Tileset>(File.ReadAllText(tilesetFile));

                string textureSrc = $"{Path.GetDirectoryName(tilesetFile) + "/" + tileset.image}";
                Console.WriteLine(textureSrc);
                tileset.texture = Texture2D.FromFile(OmoriModTool.instance.GraphicsDevice, textureSrc);
                tilesets.Add(tileset);

                if (i == 0)
                tex = tileset.texture;
            }
        }

        public void Draw(SpriteBatch sb, GraphicsDevice graphicsDevice)
        {
            for (int i = 0; i < TileMap.layers.Count; i++)
            {
                // for every (width of tilemap)
                // go to next line of tiles and draw them. its x to y
                for (int y = 0; y < TileMap.layers[i].height; y++)
                {
                    for (int x = 0; x < TileMap.layers[i].width; x++)
                    {
                        if (i == 0)
                        {
                            // Random random = new Random();
                            // sb.Draw(tex, new Rectangle(x * 32, y * 32, 32, 32), new Color(random.Next(10), random.Next(10), 0, random.NextSingle()));
                            // sb.Draw(tex, new Rectangle(x * 32, y * 32, 32, 32), new Microsoft.Xna.Framework.Rectangle(32, 0, 32, 32), Color.White);
                        }
                    }
                }
            }

            sb.Draw(tex, new Rectangle(0, 0, tex.Width, tex.Height), Color.White);
        }

        private static Texture2D Rectangle(Color color, int width, int height)
        {
            Texture2D tex = new Texture2D(OmoriModTool.instance.GraphicsDevice, width, height);
            Color[] cols = new Color[width * height];
            for (int i = 0; i < cols.Length; i++)
            {
                cols[i] = color;
            }

            tex.SetData(cols);
            return tex;
        }

        Color[] GetImageData(Color[] colorData, int width, Rectangle rectangle)
        {
            Color[] color = new Color[rectangle.Width * rectangle.Height];
            for (int x = 0; x < rectangle.Width; x++)
                for (int y = 0; y < rectangle.Height; y++)
                    color[x + y * rectangle.Width] = colorData[x + rectangle.X + (y + rectangle.Y) * width];
            return color;
        }
    }
}
