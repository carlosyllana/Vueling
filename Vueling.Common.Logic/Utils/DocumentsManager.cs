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
            LoadDocument();
        }

        public void LoadDocument()
        {
            PATH = GetPath();

            if (!File.Exists(PATH))
            {
               File.CreateText(PATH);
            }
            
        }

        public String GetPath()
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

    }

}
