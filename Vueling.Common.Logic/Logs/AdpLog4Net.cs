using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Log
{
    public class AdpLog4Net : IVuelingLogger
    {

        private readonly ILog log4net;

        public AdpLog4Net(Type declaringType)
        {
            log4net = LogManager.GetLogger(declaringType);
        }
        static AdpLog4Net()
        {
            Init();
        }

        public static void Init()
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository();

            var patternLayout = new PatternLayout();

            // Ingresamos la patter que seguirá el log
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            //Instancia del appender tipo rolling con sus opciones
            var roller = new RollingFileAppender();
            roller.AppendToFile = true;
            roller.File = @"Logs\Log4net.txt";
            roller.Layout = patternLayout;
            roller.MaximumFileSize = "10MB";
            roller.MaxSizeRollBackups = 10;
            roller.RollingStyle = RollingFileAppender.RollingMode.Date;
            roller.StaticLogFileName = true;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            //Instancia del appender tipo Mail con sus opciones
            //var mailer = new SmtpAppender()
            //{
            //    SmtpHost = "smtp.gmail.com",
            //    Port = 587,
            //    Authentication = SmtpAppender.SmtpAuthentication.Basic,
            //    Username = "charlvuel@gmail.com",
            //    Password = "",
            //    BufferSize = 1,
            //    From = "charlvuel@gmail.com",
            //    To = "carles.sanchez@atmira.com",
            //    EnableSsl = true,
            //    Subject = "Mail de logs de errores graves en Student 3 capas",
            //    Layout = mailingPatternLayout,
            //    Threshold = Level.Error
            //};
            //mailer.ActivateOptions();
            //hierarchy.Root.AddAppender(mailer);

            hierarchy.Root.Level = Level.Debug;
            hierarchy.Configured = true;
        }

        public void Debug(object message)
        {
            log4net.Debug(message);
        }

        public void Error(object message)
        {
            log4net.Error(message);
        }

        public void Fatal(object message)
        {
            log4net.Fatal(message);
        }

        public void Info(object message)
        {
            log4net.Info(message);
        }

        public void Warn(object message)
        {
            Serilog.Log.Warning(message.ToString());
        }
    }
}
