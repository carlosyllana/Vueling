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
        private ICrudBl<Alumno> _alumnoBl;

        public AlumnoForm()
        {
            InitializeComponent();
            alumno = new Alumno();
            _alumnoBl = new AlumnoBl();

        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            GenerarAlumno();
            Alumno al = _alumnoBl.Add(alumno);
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
            alumno.FechaNacimiento = dpFechaNacimiento.Value;
            alumno.Guid = Guid.NewGuid();
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            upId.Value = 0;
            dpFechaNacimiento.Value = DateTime.Today.Date;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void cATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eSToolStripMenuItem.Checked = false;
            this.cATToolStripMenuItem.Checked = true;
        }

        private void eSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eSToolStripMenuItem.Checked = true;
            this.cATToolStripMenuItem.Checked = false;

        }

        private void tXTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tXTToolStripMenuItem1.Checked = true;
            this.jSONToolStripMenuItem1.Checked = false;
            this.xMLToolStripMenuItem1.Checked = false;
            _alumnoBl.Formater(Enums.TipoFichero.TXT);
        }

        private void jSONToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tXTToolStripMenuItem1.Checked = false;
            this.jSONToolStripMenuItem1.Checked = true;
            this.xMLToolStripMenuItem1.Checked = false;
            _alumnoBl.Formater(Enums.TipoFichero.JSON);
        }
        private void xMLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tXTToolStripMenuItem1.Checked = false;
            this.jSONToolStripMenuItem1.Checked = false;
            this.xMLToolStripMenuItem1.Checked = true;
            _alumnoBl.Formater(Enums.TipoFichero.XML);
        }
    }
}
