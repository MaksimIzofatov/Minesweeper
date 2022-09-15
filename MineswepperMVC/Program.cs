namespace MineswepperMVC
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MinesweeperModel model = new MinesweeperModel();
            MinesweeperController controller = new MinesweeperController { Model = model };

            MinesweeperView view = new MinesweeperView(model, controller);


            Application.Run(view);
        }
    }
}