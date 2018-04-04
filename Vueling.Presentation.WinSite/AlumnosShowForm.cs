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

        private ICrudBl<Alumno> lBussines;
        Enums.TipoFichero tipoFichero;
        public AlumnosShowForm()
        {
            InitializeComponent();
            lBussines = new AlumnoBl();
            tipoFichero = lBussines.GetActualFormat();
            this.cbTipo.SelectedIndex = (int)tipoFichero;
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
            Menu menu = new Menu();
            this.Owner.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadData()
        {
            var list = ListadoAlumnosXml.Instance;
            this.dataGridAlumnos.DataSource = list.GetListValues();
            this.dataGridAlumnos.Update();
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tipoFichero = (Enums.TipoFichero)this.cbTipo.SelectedIndex;
            lBussines.Formater(this.tipoFichero);
            var tipo = lBussines.GetActualFormat();
            this.cbTipo.SelectedIndex = (int)tipo;
            ViewData(tipo);
        }

        private void dataGridAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            String column = cbCampo.Text;
            String value = txtBuscar.Text;
            GetLinqData(column, value);

        }

        private void GetLinqData(String column, String value)
        {
            if (!String.IsNullOrEmpty(value)&&!String.IsNullOrEmpty(column))
            {
                Alumno al = new Alumno(Guid.NewGuid(), 1, "carl", "yllan", "a", DateTime.Now, 24, DateTime.Now);
                String a =(string)al["Nombre"];
                switch (tipoFichero)
                {
                    case Enums.TipoFichero.TXT:
                        var queryTxt =
                            from Alumno item in ListadoAlumnosTxt.Instance.GetListValues()
                            where ((String)item[column]).Equals(value)
                             select item;
                        dataGridAlumnos.DataSource = queryTxt.ToList(); dataGridAlumnos.Update();
                        break;
                    case Enums.TipoFichero.JSON:
                        var queryJson =
                            from Alumno item in ListadoAlumnosJson.Instance.GetListValues()
                            where (item[column]).Equals(value)
                            select item;
                        dataGridAlumnos.DataSource = queryJson.ToList();
                        dataGridAlumnos.Update();
                        break;

                    case Enums.TipoFichero.XML:
                        var queryXml =
                            from Alumno item in ListadoAlumnosXml.Instance.GetListValues()
                            where ((String)item[column]).Equals(value)
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


    }
}
