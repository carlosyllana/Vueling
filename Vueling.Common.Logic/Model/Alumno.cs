using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Model
{

    [Table(Name = "Alumnos")]
    public class Alumno : VuelingObject 
    {

        [Column(IsPrimaryKey = true)]
        public override Guid Guid { get ; set; }


        public int Id { get; set; }
        [Column]
        public String Nombre { get; set; }

        //[Column(Storage = "Apellido")]
        [Column]
        public String Apellido { get; set; }

        //[Column(Storage = "Dni")]
        [Column]
        public String Dni { get; set; }

        //[Column(Storage = "FechaNacimiento")]
        [Column]
        public DateTime FechaNacimiento { get; set; }

        //[Column(Storage = "Edad")]
        [Column]
        public int Edad { get; set; }

        //[Column(Storage = "FechaRegistro")]
        [Column]
        public DateTime FechaRegistro { get; set; }


        

        public Alumno(string guid, string id, string nombre, string apellidos, string dni, string fechaDeNacimiento, string edad, string fechaDeRegistro)
       // :base(Guid.Parse(guid))
        {
            Guid = Guid.Parse(guid);
            Id = Convert.ToInt32(id);
            Nombre = nombre;
            Apellido = apellidos;
            Dni = dni;
            FechaNacimiento = DateTime.Parse(fechaDeNacimiento).Date;
            FechaRegistro = DateTime.Parse(fechaDeRegistro).Date;
            Edad = Convert.ToInt32(edad);
            
        }

        public Alumno(Guid guid, int id, string nombre, string apellidos, string dni, DateTime fechaDeNacimiento, int edad, DateTime fechaDeRegistro)
        {

            //Cambiar a base.
            this.Guid = guid;
            Id = id;
            Nombre = nombre;
            Apellido = apellidos;
            Dni = dni;
            FechaNacimiento = fechaDeNacimiento.Date;
            FechaRegistro = fechaDeRegistro.Date;
            Edad = edad;
        }




        public Alumno()
        //:base()
        {
            this.Guid = Guid.NewGuid();
        }

        

        public Alumno(Guid guid, int id, string nombre, string apellido, string dni, DateTime fechaNacimiento)
        //:base(guid )
        {
            this.Guid = guid;
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.FechaNacimiento = fechaNacimiento.Date;
            this.FechaRegistro = new DateTime().Date;
        }


        public override string ToString()
        {
            
            return Guid.ToString() + "," + Id.ToString() + "," + Nombre + "," + Apellido + "," + Dni + "," + FechaNacimiento.ToString() + "," + Edad.ToString() + "," + FechaRegistro.ToString(); 
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

        /*public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }*/

        public Type GetPropertyTypeByName(string propertyName)
        {
            return (Type)(this.GetType().GetProperty(propertyName).PropertyType);

            
        }

 


    }
}
