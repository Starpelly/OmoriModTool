using ImGuiNET;
using Microsoft.Xna.Framework.Graphics;
using OmoriModTool.Views;

namespace OmoriModTool
{
    public class EditorLayer
    {
        private DirectoryTreeView treeView;
        private static bool videoPlayerOpen;
        private static bool imageEditorOpen; private static string imageEditorPath;

        public static void ShowVideoPlayer() { videoPlayerOpen = true; }
        public static void ShowImageEditor(string path) { imageEditorOpen = true; imageEditorPath = path; ImageEditorView.currentTexture = Texture2D.FromFile(OmoriModTool.instance.GraphicsDevice, path); }

        public EditorLayer()
        {
            treeView = new DirectoryTreeView(@"C:\Program Files (x86)\Steam\steamapps\common\OMORI\www_decrypt");
        }

        public void SceneImGui()
        {
            Dockspace.Imgui();
            MainMenuBar.Imgui();

            ImGui.ShowDemoWindow();

            treeView.Imgui();
            MapEditorView.Imgui();

            if (videoPlayerOpen) VideoPlayerView.Show(ref videoPlayerOpen);
            if (imageEditorOpen) ImageEditorView.Show(ref imageEditorOpen, imageEditorPath);
        }
    }
}
