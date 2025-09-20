
using Microsoft.VisualBasic;
using Serilog;
using System.IO;
namespace ChatAppNats
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // Create the logs Directory If It does not exist
                var logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
                Directory.CreateDirectory(logDir);

                // Configure Serilog
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.File(
                        Path.Combine(logDir, "chatapp_log_.txt"),
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: 7,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}| {Level:u3} | {Message:lj}{NewLine}{Exception}")
                        .CreateLogger();


                Log.Information("Application Starting...");


                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();

                RegisterForm registerForm = new RegisterForm();
                Application.Run(new RegisterForm());

                // prompt for username
                //string enteredName = Interaction.InputBox("Enter Your UserName: ", "Chat Form");
                //string userName = string.IsNullOrWhiteSpace(enteredName) ? Environment.UserName : enteredName;

                //// prompt for targt user
                //string enteredTarget = Interaction.InputBox("Enter target user for direct chat (leave blank for global):", "Chat Form");
                //string? targetuser = string.IsNullOrWhiteSpace(enteredTarget) ? null : enteredTarget;


                //if (targetuser == null)
                //{
                //    Log.Information("Launching global chat for user {user}.", userName);
                //    Application.Run(new ChatForm(userName));
                //}
                //else
                //{
                //    Log.Information("Launching direct chat: {user} -> {target}", userName, targetuser);
                //    Application.Run(new ChatForm(userName, targetuser));
                //}

                Log.Information("Application Exited.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unhandled exception occurred.");
                MessageBox.Show("An unexpected error occurred. Please check logs.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
