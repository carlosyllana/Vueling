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
        public Menu()
        {
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
    }
}
