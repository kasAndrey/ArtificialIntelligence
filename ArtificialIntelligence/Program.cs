using GraphicsManagement;

namespace ArtificialIntelligence
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Set color pallete
            Plotter.ColorPallete = [
                Color.LimeGreen,
                Color.LightGreen,
                Color.Yellow,
                Color.Red,
                Color.Pink,
                Color.White,
            ];

            Application.Run(new MainWindow());
        }
    }
}