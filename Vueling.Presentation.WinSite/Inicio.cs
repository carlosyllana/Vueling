using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using Serilog.Events;

namespace Vueling.Presentation.WinSite
{
    static class Inicio
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.File(@"Logs\serilog.txt")
             //.WriteTo.File("debugLog.txt", restrictedToMinimumLevel: LogEventLevel.Debug)
             .WriteTo.Console()
             //.WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
             .CreateLogger();
            Application.Run(new Menu());
            Log.CloseAndFlush();

        }


    }
}
