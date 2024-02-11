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

            ApplicationConfiguration.Initialize();
            Application.Run(new HomePage(DatabaseManager.Instance.Connection));
        }
    }
}