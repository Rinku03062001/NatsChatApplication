using NLog;
namespace ChatAppNats
{
    internal static class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                logger.Info("Application Starting...");
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();

                string enteredName = InputBox.Show("Enter Your UserName: ", "Chat Form");

                string userName = string.IsNullOrWhiteSpace(enteredName) ? Environment.UserName : enteredName;


                Application.Run(new ChatForm(userName));
                logger.Info("Application Exited.");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Unhandled exception occurred.");
                throw;
            }
            
        }
    }
}