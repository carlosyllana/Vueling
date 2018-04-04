using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Model
{
    public class Alumno : VuelingObject 
    {

        public Alumno(string guid, string id, string nombre, string apellidos, string dni, string fechaDeNacimiento, string edad, string fechaDeRegistro)
        {
            Guid = Guid.Parse(guid);
            Id = Convert.ToInt32(id);
            Nombre = nombre;
            Apellido = apellidos;
            Dni = dni;
            FechaNacimiento = DateTime.Parse(fechaDeNacimiento);
            FechaRegistro = DateTime.Parse(fechaDeRegistro);
            Edad = Convert.ToInt32(edad);
        }

        public Alumno(Guid guid, int id, string nombre, string apellidos, string dni, DateTime fechaDeNacimiento, int edad, DateTime fechaDeRegistro)
        {
            Guid = guid;
            Id = id;
            Nombre = nombre;
            Apellido = apellidos;
            Dni = dni;
            FechaNacimiento = fechaDeNacimiento;
            FechaRegistro = fechaDeRegistro;
            Edad = edad;
        }

        //public Guid Guid { get; set; }
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Dni { get; set; }
        public DateTime  FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public DateTime FechaRegistro { get; set; }
        //Fecha de nacimiento.
        //Edad (calculado)
        //Fecha hora de registro.

        public Alumno()
        {
            this.Guid = Guid.NewGuid();
        }

        

        public Alumno(Guid guid, int id, string nombre, string apellido, string dni, DateTime fechaNacimiento)
        {
            this.Guid = guid;
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.FechaNacimiento = fechaNacimiento;
            this.FechaRegistro = new DateTime();
        }


        public override string ToString()
        {
            return Guid.ToString() + "," + Id.ToString() + "," + Nombre + "," + Apellido + "," + Dni + "," + FechaNacimiento.ToString() + "," + Edad.ToString() + "," + FechaNacimiento.ToString(); 
        }

        public override bool Equals(object obj)
        {
            var alumno = obj as Alumno;
            return alumno != null &&
                   Id == alumno.Id &&
                   Nombre == alumno.Nombre &&
                   Apellido == alumno.Apellido &&
                   Dni == alumno.Dni;
        }

        public override int GetHashCode()
        {
            var hashCode = -1910929195;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellido);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Guid.ToString());
            return hashCode;
        }

        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }


    }
}
