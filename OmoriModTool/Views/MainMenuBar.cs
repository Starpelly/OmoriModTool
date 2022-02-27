using ImGuiNET;

namespace OmoriModTool.Views
{
    public class MainMenuBar
    {
        public static void Imgui()
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem("New"))
                    {

                    }
                    if (ImGui.MenuItem("Open"))
                    {

                    }
                    if (ImGui.MenuItem("Save"))
                    {

                    }
                    if (ImGui.MenuItem("Save As"))
                    {

                    }
                    ImGui.Separator();
                    if (ImGui.MenuItem("Exit", "Alt+F4"))
                    {
                    }
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("Edit"))
                {
                    if (ImGui.MenuItem("Undo", "CTRL+Z"))
                    {
                    }
                    if (ImGui.MenuItem("Redo", "CTRL+Y or CTRL+ALT+Z"))
                    {
                    }
                    ImGui.Separator();
                    if (ImGui.MenuItem("Properties"))
                    {
                    }
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("Help"))
                {
                    ImGui.EndMenu();
                }
                ImGui.EndMainMenuBar();
            }
        }
    }
}
