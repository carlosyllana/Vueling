using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;

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

            log4net.Config.XmlConfigurator.Configure();

            Log.Logger = new LoggerConfiguration()
             .WriteTo.File(@"Logs\serilog.txt")
             .WriteTo.Email(new EmailConnectionInfo
             {
                 FromEmail = "cygmindundi@gmail.com",
                 ToEmail = "carlos.yllana@atmira.com",
                 MailServer = "smtp.gmail.com",
                 NetworkCredentials = new NetworkCredential
                 {
                     UserName = "cygmindundi@gmail.com",
                     Password = "Mindundi2017"
                 },
                 EnableSsl = true,
                 Port = 587,
                 EmailSubject ="Error Serilog"
             },
    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}",
    batchPostingLimit: 10
    , restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Fatal
)
             /*.WriteTo.Email(fromEmail: "cygmindundi@gmail.com",
            toEmail: "carlos.yllana@atmira.com",
            mailServer: "smtp.gmail.com")**/
             //.WriteTo.File("debugLog.txt", restrictedToMinimumLevel: LogEventLevel.Debug)
             .WriteTo.Console()
             //.WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
             .CreateLogger();
            Application.Run(new Menu());
            Log.CloseAndFlush();

        }


    }
}
