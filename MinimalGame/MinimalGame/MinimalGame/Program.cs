using System;

namespace MinimalGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (XNAGameController game = new XNAGameController())
            {
                game.Run();
            }
        }
    }
#endif
}

