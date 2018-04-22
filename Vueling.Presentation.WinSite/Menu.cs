using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using System.Reflection;

namespace Vueling.Presentation.WinSite
{
    public partial class Menu : Form
    {
        private ICrudBl<Alumno> _alumnoBl;
        ResourceManager res_man;
        CultureInfo cul;
        ConfigManager confManager = null;

        public Menu()
        {
          
            cul = CultureInfo.CreateSpecificCulture("ca");
            res_man = new ResourceManager("Vueling.Presentation.WinSite.Properties.Resource", Assembly.GetExecutingAssembly());

            InitializeComponent();
            _alumnoBl = new GenericBL();
            confManager = new ConfigManager();
            //Comprobamos el menú
            CheckFormatMenuItem();
            CheckLanguageMenuItem();
            //Actualizamos componentes
            UpdateLanguage();
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

        private void UpdateLanguage()
        {
            this.lblTitulo.Text = res_man.GetString("menuTitle", cul);
            this.btnMostrar.Text = res_man.GetString("menuShowList", cul);
            this.btnSalir.Text = res_man.GetString("menuExit", cul);
            this.btnAñadir.Text = res_man.GetString("menuAdd", cul);
            this.iDiomaToolStripMenuItem.Text = res_man.GetString("menuLanguage", cul);
            this.formatoToolStripMenuItem.Text = res_man.GetString("menuFormat", cul);
        }


        #region Language Menu Item
        private void eSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eSToolStripMenuItem.Checked = true;
            this.cATToolStripMenuItem.Checked = false;
            this.eNToolStripMenuItem.Checked = false;
            cul = CultureInfo.CreateSpecificCulture("es");
            confManager.GrabarIdioma(Idioma.ES);
            UpdateLanguage();
        }

        private void cATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eNToolStripMenuItem.Checked = false;
            this.eSToolStripMenuItem.Checked = false;
            this.cATToolStripMenuItem.Checked = true;
            cul = CultureInfo.CreateSpecificCulture("ca");
            confManager.GrabarIdioma(Idioma.CAT);
            UpdateLanguage();
        }

        private void eNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eSToolStripMenuItem.Checked = false;
            this.cATToolStripMenuItem.Checked = false;
            this.eNToolStripMenuItem.Checked = true;
            cul = CultureInfo.CreateSpecificCulture("en");
            confManager.GrabarIdioma(Idioma.EN);

            UpdateLanguage();
        }




        private void CheckLanguageMenuItem()
        {
            switch (confManager.GetActualLanguage())
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
        #endregion

        #region Format Menu Item
        private void tXTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tXTToolStripMenuItem1.Checked = true;
            this.jSONToolStripMenuItem1.Checked = false;
            this.xMLToolStripMenuItem1.Checked = false;
            this.sqlItem.Checked = false;
            confManager.Formater(TipoFichero.TXT);

        }

        private void jSONToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tXTToolStripMenuItem1.Checked = false;
            this.jSONToolStripMenuItem1.Checked = true;
            this.xMLToolStripMenuItem1.Checked = false;
            this.sqlItem.Checked = false;
            confManager.Formater(TipoFichero.JSON);
        }
        private void xMLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tXTToolStripMenuItem1.Checked = false;
            this.jSONToolStripMenuItem1.Checked = false;
            this.xMLToolStripMenuItem1.Checked = true;
            this.sqlItem.Checked = false;

            confManager.Formater(TipoFichero.XML);
        }

        private void sqlItem_Click(object sender, EventArgs e)
        {
            this.tXTToolStripMenuItem1.Checked = false;
            this.jSONToolStripMenuItem1.Checked = false;
            this.xMLToolStripMenuItem1.Checked = false;
            this.sqlItem.Checked = true;
            confManager.Formater(TipoFichero.SQL);
        }

        private void CheckFormatMenuItem()
        {

            switch (confManager.GetActualFormat())
            {
                case TipoFichero.TXT:
                    this.tXTToolStripMenuItem1.Checked = true;
                    break;
                case TipoFichero.JSON:
                    this.jSONToolStripMenuItem1.Checked = true;
                    break;

                case TipoFichero.XML:
                    this.xMLToolStripMenuItem1.Checked = true;
                    break;
                case TipoFichero.SQL:
                    this.sqlItem.Checked = true;
                    break;
            }

        } 
        #endregion




    }
    
}
