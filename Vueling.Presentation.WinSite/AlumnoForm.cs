using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {

        private Alumno alumno;
        private IAlumnoBL _alumnoBl;

        public AlumnoForm()
        {
            InitializeComponent();
            alumno = new Alumno();
            _alumnoBl = new AlumnoBl();
        }



        private void btnJson_Click(object sender, EventArgs e)
        {
            GenerarAlumno();
            _alumnoBl.Formater(Enums.TipoFichero.JSON);
            Alumno al =_alumnoBl.Add(alumno);
            if (al != null)
            {
                MessageBox.Show("Usuario Añadido");
                LimpiarCampos();
            }

        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            GenerarAlumno();
            _alumnoBl.Formater(Enums.TipoFichero.TXT);
            Alumno al =_alumnoBl.Add(alumno);
            if (al != null)
            {
                MessageBox.Show("Usuario Añadido");
                LimpiarCampos();
            }


        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            GenerarAlumno();
            _alumnoBl.Formater(Enums.TipoFichero.XML);
            Alumno al =_alumnoBl.Add(alumno);

            if (al != null)
            {
                MessageBox.Show("Usuario Añadido");
                LimpiarCampos();
            }

        }

        private void GenerarAlumno()
        {
            alumno.Id = Decimal.ToInt32(upId.Value);
            alumno.Nombre = txtNombre.Text;
            alumno.Apellido = txtApellido.Text;
            alumno.Dni = txtDni.Text;
            alumno.Guid = Guid.NewGuid();
            alumno.FechaNacimiento = dpFechaNacimiento.Value;
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            upId.Value = 0;
            dpFechaNacimiento.Value = DateTime.Today;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
