using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
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
        ResourceManager res_man;
        CultureInfo cul;
        public AlumnoForm()
        {
            InitializeComponent();
            cul = CultureInfo.CreateSpecificCulture("ca");
            res_man = new ResourceManager("Vueling.Presentation.WinSite.Properties.Resource", Assembly.GetExecutingAssembly());

            UpdateLanguage();
            alumno = new Alumno();
            _alumnoBl = new AlumnoBl();
            LoadLenguageItem();
            CheckFormatMenu();

        }
        private void UpdateLanguage()
        {

            this.lblId.Text = res_man.GetString("alumnoForm_lblId", cul);
            this.lblFechaDeNacimiento.Text = res_man.GetString("alumnoForm_lblFechaDeNacimiento", cul);
            this.lblDni.Text = res_man.GetString("alumnoForm_lblDni", cul);
            this.lblApellido.Text = res_man.GetString("alumnoForm_lblApellido", cul);
            this.lblNombre.Text = res_man.GetString("alumnoForm_lblNombre", cul);
            this.btnSalir.Text = res_man.GetString("menuExit", cul);
            this.btnAñadir.Text = res_man.GetString("menuAdd", cul);
            this.iDiomaToolStripMenuItem.Text = res_man.GetString("menuLanguage", cul);
            this.formatoToolStripMenuItem.Text = res_man.GetString("menuFormat", cul);
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
            cul = CultureInfo.CreateSpecificCulture("ca");
            _alumnoBl.GrabarIdioma(Idioma.CAT);
            UpdateLanguage();
        }

        private void eSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eSToolStripMenuItem.Checked = true;
            this.cATToolStripMenuItem.Checked = false;
            cul = CultureInfo.CreateSpecificCulture("es");
            _alumnoBl.GrabarIdioma(Idioma.ES);

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

       

        private void xmlAlumnoForm_Click(object sender, EventArgs e)
        {
            this.txtAlumnoForm.Checked = false;
            this.jsonAlumnoForm.Checked = false;
            this.xmlAlumnoForm.Checked = true;
            _alumnoBl.Formater(Enums.TipoFichero.XML);
        }

        private void jsonAlumnoForm_Click(object sender, EventArgs e)
        {
            this.txtAlumnoForm.Checked = false;
            this.jsonAlumnoForm.Checked = true;
            this.xmlAlumnoForm.Checked = false;
            _alumnoBl.Formater(Enums.TipoFichero.JSON);
        }

        private void txtAlumnoForm_Click(object sender, EventArgs e)
        {
            this.txtAlumnoForm.Checked = true;
            this.jsonAlumnoForm.Checked = false;
            this.xmlAlumnoForm.Checked = false;
            _alumnoBl.Formater(Enums.TipoFichero.TXT);
        }
        private void CheckFormatMenu()
        {


            switch (_alumnoBl.GetActualFormat())
            {
                case Enums.TipoFichero.TXT:
                    this.txtAlumnoForm.Checked = true;
                    break;
                case Enums.TipoFichero.JSON:
                    this.jsonAlumnoForm.Checked = true;
                    break;

                case Enums.TipoFichero.XML:
                    this.xmlAlumnoForm.Checked = true;
                    break;

            }

        }

        private void esAlumnoForm_Click(object sender, EventArgs e)
        {
            this.esAlumnoForm.Checked = true;
            this.catAlumnoForm.Checked = false;
            this.eNToolStripMenuItem.Checked = false;
            cul = CultureInfo.CreateSpecificCulture("es");
            _alumnoBl.GrabarIdioma(Idioma.ES);
            UpdateLanguage();
        }

        private void catAlumnoForm_Click(object sender, EventArgs e)
        {
            this.esAlumnoForm.Checked = false;
            this.catAlumnoForm.Checked = true;
            this.eNToolStripMenuItem.Checked = false;
            cul = CultureInfo.CreateSpecificCulture("ca");
            _alumnoBl.GrabarIdioma(Idioma.CAT);
            UpdateLanguage();
        }

        private void eNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.esAlumnoForm.Checked = false;
            this.catAlumnoForm.Checked = false;
            this.eNToolStripMenuItem.Checked = true;
            cul = CultureInfo.CreateSpecificCulture("en");
            _alumnoBl.GrabarIdioma(Idioma.EN);
            UpdateLanguage();
        }
        private void LoadLenguageItem()
        {
            switch (_alumnoBl.GetActualLanguage())
            {
                case Idioma.CAT:
                    this.catAlumnoForm.Checked = true;
                    break;
                case Idioma.ES:
                    this.esAlumnoForm.Checked = true;
                    break;

                case Idioma.EN:
                    this.eNToolStripMenuItem.Checked = true;
                    break;

            }
        }
    }
}
