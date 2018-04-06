using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vueling.Common.Logic.Enums;
using Serilog;
using System.Reflection;
using Vueling.Common.Logic.Log;
using System.Security;
using Vueling.Common.Logic.Utils;

namespace Vueling.Common.Logic
{
    public class DocumentsManager
    {
        public static String PATH;
        private Enums.TipoFichero tipo;
        private readonly IVuelingLogger _log = new VuelingLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private SendMail mailer;

        public DocumentsManager(Enums.TipoFichero tipo)
        {
            mailer = new SendMail();
            this.tipo = tipo;
            LoadDocument();
        }

        public void LoadDocument()
        {
            PATH = GetPath();
            try
            {
                _log.Info("Inicio DocumentManager " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                if (!File.Exists(PATH))
                {
                    File.CreateText(PATH);
                }
            }
            catch (FileNotFoundException ex)
            {
                mailer.email_send("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (IOException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;

            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            finally
            {
                _log.Info("Fin de DocumentManager " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
            
        }

        public String GetPath()
        {
            try
            {
                var fileName = string.Empty;
                switch (tipo)
                {
                    case TipoFichero.TXT:
                        fileName = Environment.GetEnvironmentVariable("txtFile", EnvironmentVariableTarget.User);
                        break;
                    case TipoFichero.JSON:
                        fileName = Environment.GetEnvironmentVariable("jsonFile", EnvironmentVariableTarget.User);
                        break;
                    case TipoFichero.XML:
                        fileName = Environment.GetEnvironmentVariable("xmlFile", EnvironmentVariableTarget.User);
                        break;
                }
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + " \\" + fileName;
            }
            catch (SecurityException ex)
            {
                _log.Fatal("Error en " + MethodBase.GetCurrentMethod().Name + "--> El autor de la llamada no tiene el permiso requerido para llevar a cabo esta operación.");
                throw;
            }
            catch (ArgumentNullException ex)
            {
                _log.Fatal("Error en " +MethodBase.GetCurrentMethod().Name + " El valor de variable es null.--> " + ex.Message);
                throw;
            }
            catch (IOException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;

            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            finally
            {
                _log.Info("Fin de DocumentManager " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
            
        }

    }

}
