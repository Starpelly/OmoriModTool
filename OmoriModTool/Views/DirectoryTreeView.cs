using ImGuiNET;

namespace OmoriModTool.Views
{
    public class DirectoryTreeView
    {
        private string currentDirectory;
        private string assetsPath;

        public DirectoryTreeView(string path)
        {
            assetsPath = path;
            currentDirectory = path;
        }

        public void Imgui()
        {
            ImGui.Begin("Project Browser");

            // crashes if the directory is deleted while looking in it
            string[] files = Directory.GetFileSystemEntries(currentDirectory, "*.*");

            if (currentDirectory != assetsPath)
            {
                if (ImGui.Button("<-"))
                {
                    currentDirectory = Directory.GetParent(currentDirectory).FullName;
                }
            }

            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                var relative = GetRelativePath(currentDirectory, file).Replace("\\", "/");
                if (Directory.Exists(file))
                {
                    if (ImGui.Button(relative))
                    {
                        currentDirectory = file;
                    }
                }
                else
                {
                    if (ImGui.Button(relative))
                    {
                        string extension = Path.GetExtension(file);
                        switch (extension)
                        {
                            case ".webm":
                                EditorLayer.ShowVideoPlayer();
                                break;
                            case ".png":
                                EditorLayer.ShowImageEditor(file);
                                break;
                        }
                    }
                }
            }

            ImGui.End();
        }

        private string GetRelativePath(string relativeTo, string path)
        {
            if (!relativeTo.EndsWith(Path.DirectorySeparatorChar.ToString()))
                relativeTo += Path.DirectorySeparatorChar;
            return path.Replace(relativeTo, "");
        }

        static IEnumerable<string> GetFiles(string path)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(path);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }
        }
    }
}
