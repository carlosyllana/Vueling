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
        ResourceManager res_man;
        CultureInfo cul;
        ConfigManager confManager = null;
        public AlumnosShowForm()
        {
            InitializeComponent();
            this.dataGridAlumnos.ReadOnly = true;
            cul = Thread.CurrentThread.CurrentCulture;
            res_man = new ResourceManager("Vueling.Presentation.WinSite.Properties.Resource", Assembly.GetExecutingAssembly());
            //Iniciamos utilidades y componentes
            confManager = new ConfigManager();
            _alumnoBl = new AlumnoBl();
            //Cargamos el menú
            LoadFormatItem();
            LoadLenguageItem();
            //Actualizamos Componentes por idoma
            UpdateLanguage();
            //Mostramos La pantalla.
            ViewData();
            LoadCbCampo();

        }

        private void LoadCbCampo()
        {
            foreach (DataGridViewColumn item in this.dataGridAlumnos.Columns)
            {
                cbCampo.Items.Add(item.HeaderText);
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            String column = cbCampo.Text;
            String value = txtBuscar.Text;
            GetLinqData(column, value);
        }

        private void GetLinqData(String column, String value)
        {
            if (!String.IsNullOrEmpty(value) && !String.IsNullOrEmpty(column))
            {
                var query =
                         from Alumno item in _alumnoBl.getList()
                            where (item[column]).Equals(Convert.ChangeType(value, item.GetPropertyTypeByName(column)))
                            select item;
                        dataGridAlumnos.DataSource = query.ToList(); dataGridAlumnos.Update();
            }
            else
            {
                ViewData();
            }

        }

        private void ViewData()
        {
            dataGridAlumnos.DataSource = _alumnoBl.getList();
        }




        private void LoadFormatItem()
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
                case TipoFichero.SQL:
                    this.sQLToolStripMenuItem.Checked = true;
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


        #region Format Button Menu

        private void txtFormatAlShowForm_Click(object sender, EventArgs e)
        {
            this.txtFormatAlShowForm.Checked = true;
            this.jsonFormatAlShowForm.Checked = false;
            this.xmlFormatAlShowForm.Checked = false;
            this.sQLToolStripMenuItem.Checked = false;
            confManager.Formater(TipoFichero.TXT);
            ViewData();
        }

        private void jsonFormatAlShowForm_Click(object sender, EventArgs e)
        {
            this.txtFormatAlShowForm.Checked = false;
            this.jsonFormatAlShowForm.Checked = true;
            this.xmlFormatAlShowForm.Checked = false;
            this.sQLToolStripMenuItem.Checked = false;

            confManager.Formater(TipoFichero.JSON);
            ViewData();
        }

        private void xmlFormatAlShowForm_Click(object sender, EventArgs e)
        {

            this.txtFormatAlShowForm.Checked = false;
            this.jsonFormatAlShowForm.Checked = false;
            this.xmlFormatAlShowForm.Checked = true;
            this.sQLToolStripMenuItem.Checked = false;

            confManager.Formater(TipoFichero.XML);
            ViewData();
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtFormatAlShowForm.Checked = false;
            this.jsonFormatAlShowForm.Checked = false;
            this.xmlFormatAlShowForm.Checked = false;
            this.sQLToolStripMenuItem.Checked = true;
            confManager.Formater(TipoFichero.SQL);
            ViewData();
        }
        #endregion

        #region Language Button Menu
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
        #endregion
    }
}