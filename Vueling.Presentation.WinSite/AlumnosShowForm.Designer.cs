namespace Vueling.Presentation.WinSite
{
    partial class AlumnosShowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridAlumnos = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.listadoAlumnosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbCampo = new System.Windows.Forms.ComboBox();
            this.lblColumna = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.iDiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tXTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlumnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoAlumnosBindingSource)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridAlumnos
            // 
            this.dataGridAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAlumnos.Location = new System.Drawing.Point(12, 90);
            this.dataGridAlumnos.Name = "dataGridAlumnos";
            this.dataGridAlumnos.Size = new System.Drawing.Size(776, 303);
            this.dataGridAlumnos.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(636, 440);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(120, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(636, 411);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(120, 23);
            this.btnMenu.TabIndex = 3;
            this.btnMenu.Text = "Volver al menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // cbCampo
            // 
            this.cbCampo.BackColor = System.Drawing.Color.Honeydew;
            this.cbCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampo.FormattingEnabled = true;
            this.cbCampo.Location = new System.Drawing.Point(617, 52);
            this.cbCampo.Name = "cbCampo";
            this.cbCampo.Size = new System.Drawing.Size(171, 21);
            this.cbCampo.TabIndex = 4;
            this.cbCampo.SelectedIndexChanged += new System.EventHandler(this.cbCampo_SelectedIndexChanged);
            // 
            // lblColumna
            // 
            this.lblColumna.AutoSize = true;
            this.lblColumna.Location = new System.Drawing.Point(682, 36);
            this.lblColumna.Name = "lblColumna";
            this.lblColumna.Size = new System.Drawing.Size(48, 13);
            this.lblColumna.TabIndex = 6;
            this.lblColumna.Text = "Columna";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(283, 52);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(282, 20);
            this.txtBuscar.TabIndex = 7;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(418, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Buscar:";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iDiomaToolStripMenuItem,
            this.formatoToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 9;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // iDiomaToolStripMenuItem
            // 
            this.iDiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eSToolStripMenuItem,
            this.cATToolStripMenuItem});
            this.iDiomaToolStripMenuItem.Name = "iDiomaToolStripMenuItem";
            this.iDiomaToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.iDiomaToolStripMenuItem.Text = "Idioma";
            // 
            // eSToolStripMenuItem
            // 
            this.eSToolStripMenuItem.Name = "eSToolStripMenuItem";
            this.eSToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.eSToolStripMenuItem.Text = "ES";
            this.eSToolStripMenuItem.Click += new System.EventHandler(this.eSToolStripMenuItem_Click);
            // 
            // cATToolStripMenuItem
            // 
            this.cATToolStripMenuItem.Name = "cATToolStripMenuItem";
            this.cATToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.cATToolStripMenuItem.Text = "CAT";
            this.cATToolStripMenuItem.Click += new System.EventHandler(this.cATToolStripMenuItem_Click);
            // 
            // formatoToolStripMenuItem
            // 
            this.formatoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tXTToolStripMenuItem1,
            this.jSONToolStripMenuItem1,
            this.xMLToolStripMenuItem1});
            this.formatoToolStripMenuItem.Name = "formatoToolStripMenuItem";
            this.formatoToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.formatoToolStripMenuItem.Text = "Formato";
            // 
            // tXTToolStripMenuItem1
            // 
            this.tXTToolStripMenuItem1.Name = "tXTToolStripMenuItem1";
            this.tXTToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.tXTToolStripMenuItem1.Text = "TXT";
            this.tXTToolStripMenuItem1.Click += new System.EventHandler(this.tXTToolStripMenuItem1_Click);
            // 
            // jSONToolStripMenuItem1
            // 
            this.jSONToolStripMenuItem1.Name = "jSONToolStripMenuItem1";
            this.jSONToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.jSONToolStripMenuItem1.Text = "JSON";
            this.jSONToolStripMenuItem1.Click += new System.EventHandler(this.jSONToolStripMenuItem1_Click);
            // 
            // xMLToolStripMenuItem1
            // 
            this.xMLToolStripMenuItem1.Name = "xMLToolStripMenuItem1";
            this.xMLToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.xMLToolStripMenuItem1.Text = "XML";
            this.xMLToolStripMenuItem1.Click += new System.EventHandler(this.xMLToolStripMenuItem1_Click);
            // 
            // AlumnosShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 486);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblColumna);
            this.Controls.Add(this.cbCampo);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dataGridAlumnos);
            this.Name = "AlumnosShowForm";
            this.Text = "y";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlumnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoAlumnosBindingSource)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridAlumnos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.BindingSource listadoAlumnosBindingSource;
        private System.Windows.Forms.ComboBox cbCampo;
        private System.Windows.Forms.Label lblColumna;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem iDiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cATToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tXTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem1;
    }
}