using System;

namespace myAsteroidsGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new AsteroidsGame())
                game.Run();
        }
    }
}
