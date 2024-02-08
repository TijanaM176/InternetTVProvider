using InternetTVProviderLibrary.StrategyPattern;
using InternetTVProviderLibrary.SingletonPattern;

namespace InternetTvProviderWinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StrategyContext context = new StrategyContext();

            ScanConfiguration scanConfig = new ScanConfiguration();
            context.setStrategy(scanConfig);
            context.ExecuteStrategy();

            ConnectToDatabase connection = new ConnectToDatabase();
            context.setStrategy(connection);
            context.ExecuteStrategy();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new PocetnaStrana(DatabaseManager.Instance.Connection));
        }
    }
}