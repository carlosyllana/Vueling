using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vueling.Common.Logic.Enums;

namespace Vueling.Common.Logic
{
    public class DocumentsManager
    {
        public static String PATH;

        private Enums.TipoFichero tipo;
        public DocumentsManager(Enums.TipoFichero tipo)
        {
            this.tipo = tipo;
        }

        public void LoadDocument()
        {
            switch (tipo)
            {
                case TipoFichero.TXT:
                    PATH = GetTxtPath();

                    break;
                case TipoFichero.JSON:
                    PATH = GetJsonPath();
                    break;
                case TipoFichero.XML:
                    PATH = GetXmlPath();
                    break;
            }

            if (!File.Exists(PATH))
            {
                File.CreateText(PATH);

            }
            
        }

        public static string GetJsonPath()
        {
            //jsonFile
            string value = Environment.GetEnvironmentVariable("jsonFile", EnvironmentVariableTarget.User);
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + " \\" + value;
            
        }

        public static string GetTxtPath()
        {
            //txtFile
            string value;
            value = Environment.GetEnvironmentVariable("txtFile", EnvironmentVariableTarget.User);
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + value;
            
        }

        public static string GetXmlPath()
        {
            //xmlFile
            string value;
            value = Environment.GetEnvironmentVariable("xmlFile", EnvironmentVariableTarget.User);
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + value;
            
        }




    }

}
