using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.Business.Logic
{
    public interface ICrudBl<T> where T : VuelingObject
    {
        T Add(T alumno);
        List<T> getList();
        //void Formater(TipoFichero tipoFichero);
        //TipoFichero GetActualFormat();
        //void GrabarIdioma(Idioma idioma);
        //Idioma GetActualLanguage();
    }
}
