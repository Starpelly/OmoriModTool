using ImGuiNET;
using Microsoft.Xna.Framework.Media;

namespace OmoriModTool.Views
{
    public class VideoPlayerView
    {

        public static void Show(ref bool open)
        {
            ImGui.Begin("Video Player", ref open);

            ImGui.End();
        }
    }
}
