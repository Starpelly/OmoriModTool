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
        public ImGuiRenderer guiRenderer;
        private EditorLayer editorLayer;

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
            guiRenderer = new ImGuiRenderer(this);
            guiRenderer.RebuildFontAtlas();
            ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;
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
            GraphicsDevice.Clear(Color.Gray);

            guiRenderer.BeforeLayout(gameTime);

            editorLayer.SceneImGui();

            guiRenderer.AfterLayout();

            base.Draw(gameTime);
        }
    }
}
