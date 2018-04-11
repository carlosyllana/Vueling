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
    public partial class Menu : Form
    {
        private ICrudBl<Alumno> _alumnoBl;

        public Menu()
        {
            _alumnoBl = new AlumnoBl();
            InitializeComponent();
            LoadList();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlumnoForm alumnoForm = new AlumnoForm();
            alumnoForm.Owner = this;
            alumnoForm.Show();
            this.Hide();

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            AlumnosShowForm alumnoShowForm = new AlumnosShowForm();
            alumnoShowForm.Owner = this;
            alumnoShowForm.Show();
            this.Hide();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadList()
        {
            ListadoAlumnosXml listXml = ListadoAlumnosXml.Instance;
            ListadoAlumnosTxt listTxt = ListadoAlumnosTxt.Instance;
            ListadoAlumnosJson listJson = ListadoAlumnosJson.Instance;
            ICrudBl<Alumno> lBussines = new AlumnoBl();
            lBussines.Formater(Enums.TipoFichero.TXT);
            listTxt.AddList(lBussines.getList());
            lBussines.Formater(Enums.TipoFichero.XML);
            listXml.AddList(lBussines.getList());
            lBussines.Formater(Enums.TipoFichero.JSON);
            listJson.AddList(lBussines.getList());

        }

        private void iDiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eSToolStripMenuItem.Checked = true;
            this.cATToolStripMenuItem.Checked = false;

        }

        private void cATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eSToolStripMenuItem.Checked = false ;
            this.cATToolStripMenuItem.Checked = true;
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
