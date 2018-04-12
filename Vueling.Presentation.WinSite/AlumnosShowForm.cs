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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnosShowForm : Form
    {

        private ICrudBl<Alumno> _alumnoBl;
        TipoFichero tipoFichero;
        ResourceManager res_man;
        CultureInfo cul;
        ConfigManager confManager = null;
        public AlumnosShowForm()
        {
            InitializeComponent();
            cul = Thread.CurrentThread.CurrentCulture;
            res_man = new ResourceManager("Vueling.Presentation.WinSite.Properties.Resource", Assembly.GetExecutingAssembly());
            confManager = new ConfigManager();
            UpdateLanguage();
            _alumnoBl = new AlumnoBl();
            tipoFichero = confManager.GetActualFormat();
            CheckFormatMenu();
            this.dataGridAlumnos.ReadOnly = true;
            ViewData(tipoFichero);
            LoadCbCampo();
            LoadLenguageItem();


        }

        private void LoadCbCampo()
        {
            foreach (DataGridViewColumn item in this.dataGridAlumnos.Columns)
            {
                cbCampo.Items.Add(item.HeaderText);
            }
        }

        private void ViewData(TipoFichero tipo)
        {
            switch (tipo)
            {
                case TipoFichero.TXT:
                    dataGridAlumnos.DataSource = ListadoAlumnosTxt.Instance.GetListValues();
                    dataGridAlumnos.Update();
                    break;
                case TipoFichero.JSON:
                    dataGridAlumnos.DataSource = ListadoAlumnosJson.Instance.GetListValues();
                    dataGridAlumnos.Update();
                    break;

                case TipoFichero.XML:
                    dataGridAlumnos.DataSource = ListadoAlumnosXml.Instance.GetListValues();
                    dataGridAlumnos.Update();
                    break;

            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void cbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

            String column = cbCampo.Text;
            String value = txtBuscar.Text;
            GetLinqData(column, value);

        }

        private void GetLinqData(String column, String value)
        {
            if (!String.IsNullOrEmpty(value) && !String.IsNullOrEmpty(column))
            {

                switch (tipoFichero)
                {
                    case TipoFichero.TXT:
                        var queryTxt =
                            from Alumno item in ListadoAlumnosTxt.Instance.GetListValues()
                            where (item[column]).Equals(Convert.ChangeType(value, item.GetPropertyTypeByName(column)))
                            select item;
                        dataGridAlumnos.DataSource = queryTxt.ToList(); dataGridAlumnos.Update();
                        break;
                    case TipoFichero.JSON:
                        var queryJson =
                            from Alumno item in ListadoAlumnosJson.Instance.GetListValues()
                            where (item[column]).Equals(Convert.ChangeType(value, item.GetPropertyTypeByName(column)))
                            select item;

                        dataGridAlumnos.DataSource = queryJson.ToList();
                        dataGridAlumnos.Update();
                        break;

                    case TipoFichero.XML:
                        var queryXml =
                            from Alumno item in ListadoAlumnosXml.Instance.GetListValues()
                            where (item[column]).Equals(Convert.ChangeType(value, item.GetPropertyTypeByName(column)))
                            select item;
                        dataGridAlumnos.DataSource = queryXml.ToList();
                        dataGridAlumnos.Update();
                        break;

                }
            }
            else
            {
                ViewData(tipoFichero);
            }

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            String column = cbCampo.Text;
            String value = txtBuscar.Text;
            GetLinqData(column, value);
        }


      
        private void CheckFormatMenu()
        {


            switch (confManager.GetActualFormat())
            {
                case TipoFichero.TXT:
                    this.txtFormatAlShowForm.Checked = true;
                    break;
                case TipoFichero.JSON:
                    this.jsonFormatAlShowForm.Checked = true;
                    break;

                case TipoFichero.XML:
                    this.xmlFormatAlShowForm.Checked = true;
                    break;

            }

        }
        private void UpdateLanguage()
        {
            this.lblBuscar.Text = res_man.GetString("lblBuscar", cul);
            this.lblColumna.Text = res_man.GetString("alumnoShowForm_lblColumna", cul);
            this.btnSalir.Text = res_man.GetString("menuExit", cul);
            this.btnMenu.Text = res_man.GetString("alumnoShowForm_btnMenu", cul);
            this.Idioma_AlumnoShowForm.Text = res_man.GetString("menuLanguage", cul);
            this.format_AlumnoShowForm.Text = res_man.GetString("menuFormat", cul);
        }

      

        private void txtFormatAlShowForm_Click(object sender, EventArgs e)
        {
            this.txtFormatAlShowForm.Checked = true;
            this.jsonFormatAlShowForm.Checked = false;
            this.xmlFormatAlShowForm.Checked = false;
            confManager.Formater(TipoFichero.TXT);
            ViewData(confManager.GetActualFormat());
        }

        private void jsonFormatAlShowForm_Click(object sender, EventArgs e)
        {
            this.txtFormatAlShowForm.Checked = false;
            this.jsonFormatAlShowForm.Checked = true;
            this.xmlFormatAlShowForm.Checked = false;
            confManager.Formater(TipoFichero.JSON);
            ViewData(confManager.GetActualFormat());
        }

        private void xmlFormatAlShowForm_Click(object sender, EventArgs e)
        {

            this.txtFormatAlShowForm.Checked = false;
            this.jsonFormatAlShowForm.Checked = false;
            this.xmlFormatAlShowForm.Checked = true;
            confManager.Formater(TipoFichero.XML);
            ViewData(confManager.GetActualFormat());
        }

        private void esItemAlShowForm_Click(object sender, EventArgs e)
        {
            this.catItemAlShowForm.Checked = false;
            this.esItemAlShowForm.Checked = true;
            this.eNToolStripMenuItem.Checked = false;
            cul = CultureInfo.CreateSpecificCulture("es");
            confManager.GrabarIdioma(Idioma.ES);
            UpdateLanguage();
        }

        private void catItemAlShowForm_Click(object sender, EventArgs e)
        {
            this.catItemAlShowForm.Checked = true;
            this.esItemAlShowForm.Checked = false;
            this.eNToolStripMenuItem.Checked = false;
            cul = CultureInfo.CreateSpecificCulture("ca");
            confManager.GrabarIdioma(Idioma.CAT);
            UpdateLanguage();
        }

        private void eNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.catItemAlShowForm.Checked = false;
            this.esItemAlShowForm.Checked = false;
            this.eNToolStripMenuItem.Checked = true;
            cul = CultureInfo.CreateSpecificCulture("en");
            confManager.GrabarIdioma(Idioma.EN);
            UpdateLanguage();
        }
        private void LoadLenguageItem()
        {
            switch (confManager.GetActualLanguage())
            {
                case Idioma.CAT:
                    this.catItemAlShowForm.Checked = true;
                    break;
                case Idioma.ES:
                    this.esItemAlShowForm.Checked = true;
                    break;

                case Idioma.EN:
                    this.eNToolStripMenuItem.Checked = true;
                    break;

            }
        }

        //label1
    }
}