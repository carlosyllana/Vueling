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
    public partial class AlumnosShowForm : Form
    {

        private ICrudBl<Alumno> _alumnoBl;
        Enums.TipoFichero tipoFichero;
        public AlumnosShowForm()
        {
            InitializeComponent();
            _alumnoBl = new AlumnoBl();
            tipoFichero = _alumnoBl.GetActualFormat();
            CheckFormatMenu();
            this.dataGridAlumnos.ReadOnly = true;
            ViewData(tipoFichero);
            LoadCbCampo();
        }

        private void LoadCbCampo()
        {
            foreach (DataGridViewColumn item in this.dataGridAlumnos.Columns)
            {
                cbCampo.Items.Add(item.HeaderText);
            }
        }

        private void ViewData(Enums.TipoFichero tipo)
        {
            switch (tipo)
            {
                case Enums.TipoFichero.TXT:
                    dataGridAlumnos.DataSource = ListadoAlumnosTxt.Instance.GetListValues();
                    dataGridAlumnos.Update();
                    break;
                case Enums.TipoFichero.JSON:
                    dataGridAlumnos.DataSource = ListadoAlumnosJson.Instance.GetListValues();
                    dataGridAlumnos.Update();
                    break;

                case Enums.TipoFichero.XML:
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

/*
        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tipoFichero = (Enums.TipoFichero)this.cbTipo.SelectedIndex;
            _alumnoBl.Formater(this.tipoFichero);

            var tipo = _alumnoBl.GetActualFormat();
            this.cbTipo.SelectedIndex = (int)tipo;
            ViewData(tipo);
        }*/


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
                    case Enums.TipoFichero.TXT:
                        var queryTxt =
                            from Alumno item in ListadoAlumnosTxt.Instance.GetListValues()
                            where (item[column]).Equals(Convert.ChangeType(value, item.GetPropertyTypeByName(column)))
                            select item;
                        dataGridAlumnos.DataSource = queryTxt.ToList(); dataGridAlumnos.Update();
                        break;
                    case Enums.TipoFichero.JSON:
                        var queryJson =
                            from Alumno item in ListadoAlumnosJson.Instance.GetListValues()
                            where (item[column]).Equals(Convert.ChangeType(value, item.GetPropertyTypeByName(column)))
                            select item;

                        dataGridAlumnos.DataSource = queryJson.ToList();
                        dataGridAlumnos.Update();
                        break;

                    case Enums.TipoFichero.XML:
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

        private void eSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eSToolStripMenuItem.Checked = true;
            this.cATToolStripMenuItem.Checked = false;
        }

        private void cATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eSToolStripMenuItem.Checked = false;
            this.cATToolStripMenuItem.Checked = true;
        }

        private void tXTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tXTToolStripMenuItem1.Checked = true;
            this.jSONToolStripMenuItem1.Checked = false;
            this.xMLToolStripMenuItem1.Checked = false;
            _alumnoBl.Formater(Enums.TipoFichero.TXT);
            ViewData(_alumnoBl.GetActualFormat());

        }

        private void jSONToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tXTToolStripMenuItem1.Checked = false;
            this.jSONToolStripMenuItem1.Checked = true;
            this.xMLToolStripMenuItem1.Checked = false;
            _alumnoBl.Formater(Enums.TipoFichero.JSON);
            ViewData(_alumnoBl.GetActualFormat());

        }
        private void xMLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tXTToolStripMenuItem1.Checked = false;
            this.jSONToolStripMenuItem1.Checked = false;
            this.xMLToolStripMenuItem1.Checked = true;
            _alumnoBl.Formater(Enums.TipoFichero.XML);
            ViewData(_alumnoBl.GetActualFormat());
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
    }
}