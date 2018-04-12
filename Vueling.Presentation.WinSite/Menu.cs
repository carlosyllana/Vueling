using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using System.Threading;
using System.Resources;
using Vueling.Presentation.WinSite.Properties;
using System.Reflection;

namespace Vueling.Presentation.WinSite
{
    public partial class Menu : Form
    {
        private ICrudBl<Alumno> _alumnoBl;
        ResourceManager res_man;
        CultureInfo cul;


        public Menu()
        {
            _alumnoBl = new AlumnoBl();
            InitializeComponent();
            LoadList();
            cul = CultureInfo.CreateSpecificCulture("ca");
            res_man = new ResourceManager("Vueling.Presentation.WinSite.Properties.Resource", Assembly.GetExecutingAssembly());
            CheckFormatMenu();
            LoadLenguageItem();
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

        private void eSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eSToolStripMenuItem.Checked = true;
            this.cATToolStripMenuItem.Checked = false;
            this.eNToolStripMenuItem.Checked = false;
           cul = CultureInfo.CreateSpecificCulture("es");
            _alumnoBl.GrabarIdioma(Idioma.ES);
            UpdateLanguage();
        }

        private void cATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eNToolStripMenuItem.Checked = false;
           this.eSToolStripMenuItem.Checked = false;
            this.cATToolStripMenuItem.Checked = true;
            cul = CultureInfo.CreateSpecificCulture("ca");
            _alumnoBl.GrabarIdioma(Idioma.CAT);
            UpdateLanguage();
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

        private void UpdateLanguage()
        {
            this.lblTitulo.Text = res_man.GetString("menuTitle", cul);
            this.btnMostrar.Text = res_man.GetString("menuShowList", cul);
            this.btnSalir.Text = res_man.GetString("menuExit", cul);
            this.btnAñadir.Text = res_man.GetString("menuAdd", cul);
            this.iDiomaToolStripMenuItem.Text = res_man.GetString("menuLanguage", cul);
            this.formatoToolStripMenuItem.Text = res_man.GetString("menuFormat", cul);
        }

        private void LoadLenguageItem()
        {
            switch (_alumnoBl.GetActualLanguage())
            {
                case Idioma.CAT:
                    this.cATToolStripMenuItem.Checked = true;
                    break;
                case Idioma.ES:
                    this.eSToolStripMenuItem.Checked = true;
                    break;

                case Idioma.EN:
                    this.eNToolStripMenuItem.Checked = true;
                    break;

            }
        }

        private void CheckFormatMenu()
        {


            switch (_alumnoBl.GetActualFormat())
            {
                case Enums.TipoFichero.TXT:
                    this.tXTToolStripMenuItem1.Checked = true;
                    break;
                case Enums.TipoFichero.JSON:
                    this.jSONToolStripMenuItem1.Checked = true;
                    break;

                case Enums.TipoFichero.XML:
                    this.xMLToolStripMenuItem1.Checked = true;
                    break;

            }

        }

        private void eNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eSToolStripMenuItem.Checked = false;
            this.cATToolStripMenuItem.Checked = false;
            this.eNToolStripMenuItem.Checked = true;
            cul = CultureInfo.CreateSpecificCulture("en");
            _alumnoBl.GrabarIdioma(Idioma.EN);

            UpdateLanguage();
        }
    }
    
}
