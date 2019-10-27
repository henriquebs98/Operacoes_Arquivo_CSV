namespace ProjetoImportacao
{
    partial class FormResultado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResultado));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iniciarExecuçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pararExecuçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.menu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarExecuçãoToolStripMenuItem,
            this.pararExecuçãoToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(173, 70);
            // 
            // iniciarExecuçãoToolStripMenuItem
            // 
            this.iniciarExecuçãoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("iniciarExecuçãoToolStripMenuItem.Image")));
            this.iniciarExecuçãoToolStripMenuItem.Name = "iniciarExecuçãoToolStripMenuItem";
            this.iniciarExecuçãoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.iniciarExecuçãoToolStripMenuItem.Text = "Iniciar Execução";
            this.iniciarExecuçãoToolStripMenuItem.Click += new System.EventHandler(this.iniciarExecuçãoToolStripMenuItem_Click);
            // 
            // pararExecuçãoToolStripMenuItem
            // 
            this.pararExecuçãoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pararExecuçãoToolStripMenuItem.Image")));
            this.pararExecuçãoToolStripMenuItem.Name = "pararExecuçãoToolStripMenuItem";
            this.pararExecuçãoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.pararExecuçãoToolStripMenuItem.Text = "Finalizar Programa";
            this.pararExecuçãoToolStripMenuItem.Click += new System.EventHandler(this.pararExecuçãoToolStripMenuItem_Click);
            // 
            // FormResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 100);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormResultado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportação de Resultado ";
            this.Load += new System.EventHandler(this.FormResultado_Load);
            this.Resize += new System.EventHandler(this.FormResultado_Resize);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem iniciarExecuçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pararExecuçãoToolStripMenuItem;

    }
}

