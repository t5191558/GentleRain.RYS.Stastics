using Microsoft.EntityFrameworkCore;
using MonthRevenue.Repository;
using Serilog;
using Serilog.Sinks.File;
using System.Configuration;
using System.Windows.Forms;

namespace MounthRevenue
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File(ConfigurationManager.AppSettings["logfile"]?.ToString() ?? "log/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
            Log.Information("程序启动");

            try
            {
                EnsureDatabase();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "数据库初始化失败");
                MessageBox.Show(ex.Message, "数据库初始化失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 添加全局异常处理
            Application.ThreadException += new ThreadExceptionEventHandler(GlobalThreadExceptionHandler);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalUnhandledExceptionHandler);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static void EnsureDatabase()
        {
            using MonthContext context = new MonthContext();
            context.Database.Migrate();
        }

        private static void GlobalThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            Log.Error(e.Exception, e.Exception.Message);
            MessageBox.Show(e.Exception.Message, "程序发生错误,请联系开发者处理", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Log.Error(ex, ex.Message);
            MessageBox.Show(ex.Message, "程序发生错误了,请联系开发者处理", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}