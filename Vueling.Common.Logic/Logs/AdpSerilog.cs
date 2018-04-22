using System;
using System.Net;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.Email;

namespace Vueling.Common.Logic.Log
{
    public class AdpSerilog : IVuelingLogger
    {

        public AdpSerilog()
        {

            Serilog.Log.Logger = new LoggerConfiguration()
             .WriteTo.File(@"Logs\serilog.txt")
             //.WriteTo.Email(new EmailConnectionInfo
             //{
             //    FromEmail = "cygmindundi@gmail.com",
             //    ToEmail = "carlos.yllana@atmira.com",
             //    MailServer = "smtp.gmail.com",
             //    NetworkCredentials = new NetworkCredential
             //    {
             //        UserName = "cygmindundi@gmail.com",
             //        Password = "Mindundi2017"
             //    },
             //    EnableSsl = true,
             //    Port = 587,
             //    EmailSubject = "Error Serilog"
             //},
             //   outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}",
             //   batchPostingLimit: 10
             //   , restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug
             //   )
             //.WriteTo.File("debugLog.txt", restrictedToMinimumLevel: LogEventLevel.Debug)
             .WriteTo.Console()
             //.WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
             .CreateLogger();
        }



        public void Debug(object message)
        {
            Serilog.Log.Debug((string)message);
        }

        public void Error(object message)
        {
            Serilog.Log.Error((string)message);
        }

        public void Fatal(object message)
        {
            Serilog.Log.Fatal((string)message);
        }

        public void Info(object message)
        {
            Serilog.Log.Information((string)message);
        }

        public void Warn(object message)
        {
            Serilog.Log.Warning((string)message);
        }
    }
}
