using ImGuiNET;
using Microsoft.Xna.Framework.Graphics;

namespace OmoriModTool.Views
{
    public class MapEditorView
    {
        static Texture2D mapTexture;

        public static void Imgui()
        {
            if (mapTexture == null)
            {
                mapTexture = Texture2D.FromFile(OmoriModTool.instance.GraphicsDevice, @"C:\Program Files (x86)\Steam\steamapps\common\OMORI\www_decrypt\img\tilesets\BS_FA_Objects.png");
            }

            ImGui.Begin("Map Editor");
            ImGui.Image(OmoriModTool.instance.guiRenderer.BindTexture(OmoriModTool.instance.tileMapRenderTarget), 
                new System.Numerics.Vector2(OmoriModTool.instance.tileMapRenderTarget.Width, OmoriModTool.instance.tileMapRenderTarget.Height));
            ImGui.End();
        }
    }
}
