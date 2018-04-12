using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Vueling.Presentation.WinSite
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btnAñadir = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.iDiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tXTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAñadir
            // 
            resources.ApplyResources(this.btnAñadir, "btnAñadir");
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMostrar
            // 
            resources.ApplyResources(this.btnMostrar, "btnMostrar");
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnSalir
            // 
            resources.ApplyResources(this.btnSalir, "btnSalir");
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblTitulo
            // 
            resources.ApplyResources(this.lblTitulo, "lblTitulo");
            this.lblTitulo.Name = "lblTitulo";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iDiomaToolStripMenuItem,
            this.formatoToolStripMenuItem});
            resources.ApplyResources(this.menuStrip2, "menuStrip2");
            this.menuStrip2.Name = "menuStrip2";
            // 
            // iDiomaToolStripMenuItem
            // 
            this.iDiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eSToolStripMenuItem,
            this.cATToolStripMenuItem,
            this.eNToolStripMenuItem});
            this.iDiomaToolStripMenuItem.Name = "iDiomaToolStripMenuItem";
            resources.ApplyResources(this.iDiomaToolStripMenuItem, "iDiomaToolStripMenuItem");
            // 
            // eSToolStripMenuItem
            // 
            this.eSToolStripMenuItem.Name = "eSToolStripMenuItem";
            resources.ApplyResources(this.eSToolStripMenuItem, "eSToolStripMenuItem");
            this.eSToolStripMenuItem.Click += new System.EventHandler(this.eSToolStripMenuItem_Click);
            // 
            // cATToolStripMenuItem
            // 
            this.cATToolStripMenuItem.Name = "cATToolStripMenuItem";
            resources.ApplyResources(this.cATToolStripMenuItem, "cATToolStripMenuItem");
            this.cATToolStripMenuItem.Click += new System.EventHandler(this.cATToolStripMenuItem_Click);
            // 
            // eNToolStripMenuItem
            // 
            this.eNToolStripMenuItem.Name = "eNToolStripMenuItem";
            resources.ApplyResources(this.eNToolStripMenuItem, "eNToolStripMenuItem");
            this.eNToolStripMenuItem.Click += new System.EventHandler(this.eNToolStripMenuItem_Click);
            // 
            // formatoToolStripMenuItem
            // 
            this.formatoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tXTToolStripMenuItem1,
            this.jSONToolStripMenuItem1,
            this.xMLToolStripMenuItem1});
            this.formatoToolStripMenuItem.Name = "formatoToolStripMenuItem";
            resources.ApplyResources(this.formatoToolStripMenuItem, "formatoToolStripMenuItem");
            // 
            // tXTToolStripMenuItem1
            // 
            this.tXTToolStripMenuItem1.Name = "tXTToolStripMenuItem1";
            resources.ApplyResources(this.tXTToolStripMenuItem1, "tXTToolStripMenuItem1");
            this.tXTToolStripMenuItem1.Click += new System.EventHandler(this.tXTToolStripMenuItem1_Click);
            // 
            // jSONToolStripMenuItem1
            // 
            this.jSONToolStripMenuItem1.Name = "jSONToolStripMenuItem1";
            resources.ApplyResources(this.jSONToolStripMenuItem1, "jSONToolStripMenuItem1");
            this.jSONToolStripMenuItem1.Click += new System.EventHandler(this.jSONToolStripMenuItem1_Click);
            // 
            // xMLToolStripMenuItem1
            // 
            this.xMLToolStripMenuItem1.Name = "xMLToolStripMenuItem1";
            resources.ApplyResources(this.xMLToolStripMenuItem1, "xMLToolStripMenuItem1");
            this.xMLToolStripMenuItem1.Click += new System.EventHandler(this.xMLToolStripMenuItem1_Click);
            // 
            // Menu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.btnAñadir);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Menu";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ToolStripMenuItem sqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem txtToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem iDiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cATToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tXTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eNToolStripMenuItem;
    }
}