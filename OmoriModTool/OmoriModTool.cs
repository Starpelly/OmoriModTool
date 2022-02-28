using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ImGuiNET;

#pragma warning disable CS8618
namespace OmoriModTool
{
    public class OmoriModTool : Game
    {
        public static OmoriModTool instance;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public ImGuiRenderer guiRenderer;
        private EditorLayer editorLayer;
        private TileMapView tileMapView;
        public RenderTarget2D tileMapRenderTarget;

        public OmoriModTool() :base()
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;

            editorLayer = new EditorLayer();

            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 835;
            graphics.PreferredBackBufferWidth = 1544;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            guiRenderer = new ImGuiRenderer(this);
            guiRenderer.RebuildFontAtlas();
            ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;

            Core.TileMap tileMap = Newtonsoft.Json.JsonConvert.DeserializeObject<Core.TileMap>(File.ReadAllText(@"C:\Program Files (x86)\Steam\steamapps\common\OMORI\www_decrypt\maps\map6.json"));
            tileMap.source = @"C:\Program Files (x86)\Steam\steamapps\common\OMORI\www_decrypt\maps\map6.json";

            for (int i = 0; i < tileMap.tilesets.Count; i++)
            {
                Console.WriteLine(tileMap.layers[i].y);
            }

            tileMapView = new TileMapView(tileMap);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            UpdateTileMapRenderTarget(tileMapView.TileMap.width * tileMapView.TileMap.tilewidth, tileMapView.TileMap.height * tileMapView.TileMap.tileheight);
            GraphicsDevice.SetRenderTarget(tileMapRenderTarget);
            GraphicsDevice.Clear(Color.Gray);

            spriteBatch.Begin();

            tileMapView.Draw(spriteBatch, GraphicsDevice);

            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);


            guiRenderer.BeforeLayout(gameTime);

            editorLayer.SceneImGui();

            guiRenderer.AfterLayout();

            base.Draw(gameTime);
        }

        public void UpdateTileMapRenderTarget(int width, int height)
        {
            if (tileMapRenderTarget != null)
                tileMapRenderTarget.Dispose();

            tileMapRenderTarget = new RenderTarget2D(
                GraphicsDevice,
                width,
                height,
                false,
                GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);
        }
    }
}
