namespace OmoriModTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using(OmoriModTool game = new OmoriModTool())
            {
                game.Run();
            }
        }
    }
}