namespace RGB
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.txtRed = new System.Windows.Forms.TextBox();
            this.txtGreen = new System.Windows.Forms.TextBox();
            this.txtBlue = new System.Windows.Forms.TextBox();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.tkbRed = new System.Windows.Forms.TrackBar();
            this.tkbGreen = new System.Windows.Forms.TrackBar();
            this.tkbBlue = new System.Windows.Forms.TrackBar();
            this.cmbPuerto = new System.Windows.Forms.ComboBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.cmsColor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkDemo = new System.Windows.Forms.CheckBox();
            this.tlpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 5;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.55639F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.44361F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tlpPanel.Controls.Add(this.txtRed, 2, 1);
            this.tlpPanel.Controls.Add(this.txtGreen, 2, 2);
            this.tlpPanel.Controls.Add(this.txtBlue, 2, 3);
            this.tlpPanel.Controls.Add(this.lblRed, 0, 1);
            this.tlpPanel.Controls.Add(this.lblGreen, 0, 2);
            this.tlpPanel.Controls.Add(this.lblBlue, 0, 3);
            this.tlpPanel.Controls.Add(this.tkbRed, 1, 1);
            this.tlpPanel.Controls.Add(this.tkbGreen, 1, 2);
            this.tlpPanel.Controls.Add(this.tkbBlue, 1, 3);
            this.tlpPanel.Controls.Add(this.cmbPuerto, 1, 0);
            this.tlpPanel.Controls.Add(this.btnConfig, 2, 0);
            this.tlpPanel.Controls.Add(this.pic, 3, 1);
            this.tlpPanel.Controls.Add(this.btnCerrar, 3, 4);
            this.tlpPanel.Controls.Add(this.lblStatus, 1, 4);
            this.tlpPanel.Controls.Add(this.chkDemo, 3, 0);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 5;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPanel.Size = new System.Drawing.Size(455, 177);
            this.tlpPanel.TabIndex = 0;
            // 
            // txtRed
            // 
            this.txtRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRed.Location = new System.Drawing.Point(281, 42);
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(53, 20);
            this.txtRed.TabIndex = 7;
            // 
            // txtGreen
            // 
            this.txtGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGreen.Location = new System.Drawing.Point(281, 77);
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.Size = new System.Drawing.Size(53, 20);
            this.txtGreen.TabIndex = 8;
            // 
            // txtBlue
            // 
            this.txtBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlue.Location = new System.Drawing.Point(281, 112);
            this.txtBlue.Name = "txtBlue";
            this.txtBlue.Size = new System.Drawing.Size(53, 20);
            this.txtBlue.TabIndex = 9;
            // 
            // lblRed
            // 
            this.lblRed.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblRed.AutoSize = true;
            this.lblRed.ForeColor = System.Drawing.Color.Lime;
            this.lblRed.Location = new System.Drawing.Point(24, 46);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(35, 13);
            this.lblRed.TabIndex = 3;
            this.lblRed.Text = "label1";
            // 
            // lblGreen
            // 
            this.lblGreen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGreen.AutoSize = true;
            this.lblGreen.ForeColor = System.Drawing.Color.Lime;
            this.lblGreen.Location = new System.Drawing.Point(24, 81);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(35, 13);
            this.lblGreen.TabIndex = 4;
            this.lblGreen.Text = "label2";
            // 
            // lblBlue
            // 
            this.lblBlue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBlue.AutoSize = true;
            this.lblBlue.ForeColor = System.Drawing.Color.Lime;
            this.lblBlue.Location = new System.Drawing.Point(24, 116);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(35, 13);
            this.lblBlue.TabIndex = 5;
            this.lblBlue.Text = "label3";
            // 
            // tkbRed
            // 
            this.tkbRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tkbRed.BackColor = System.Drawing.Color.Black;
            this.tkbRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tkbRed.Location = new System.Drawing.Point(65, 38);
            this.tkbRed.Name = "tkbRed";
            this.tkbRed.Size = new System.Drawing.Size(210, 29);
            this.tkbRed.TabIndex = 0;
            this.tkbRed.Scroll += new System.EventHandler(this.tkbRed_Scroll);
            // 
            // tkbGreen
            // 
            this.tkbGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tkbGreen.BackColor = System.Drawing.Color.Black;
            this.tkbGreen.Location = new System.Drawing.Point(65, 73);
            this.tkbGreen.Name = "tkbGreen";
            this.tkbGreen.Size = new System.Drawing.Size(210, 29);
            this.tkbGreen.TabIndex = 1;
            this.tkbGreen.Scroll += new System.EventHandler(this.tkbGreen_Scroll);
            // 
            // tkbBlue
            // 
            this.tkbBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tkbBlue.BackColor = System.Drawing.Color.Black;
            this.tkbBlue.Location = new System.Drawing.Point(65, 108);
            this.tkbBlue.Name = "tkbBlue";
            this.tkbBlue.Size = new System.Drawing.Size(210, 29);
            this.tkbBlue.TabIndex = 2;
            this.tkbBlue.Scroll += new System.EventHandler(this.tkbBlue_Scroll);
            // 
            // cmbPuerto
            // 
            this.cmbPuerto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPuerto.FormattingEnabled = true;
            this.cmbPuerto.Location = new System.Drawing.Point(65, 7);
            this.cmbPuerto.Name = "cmbPuerto";
            this.cmbPuerto.Size = new System.Drawing.Size(210, 21);
            this.cmbPuerto.TabIndex = 10;
            this.cmbPuerto.SelectedIndexChanged += new System.EventHandler(this.cmbPuerto_SelectedIndexChanged);
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.Location = new System.Drawing.Point(281, 6);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(53, 23);
            this.btnConfig.TabIndex = 11;
            this.btnConfig.Text = "button2";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnSetings_Click);
            // 
            // pic
            // 
            this.pic.ContextMenuStrip = this.cmsColor;
            this.pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic.Location = new System.Drawing.Point(340, 38);
            this.pic.Name = "pic";
            this.tlpPanel.SetRowSpan(this.pic, 3);
            this.pic.Size = new System.Drawing.Size(97, 99);
            this.pic.TabIndex = 12;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.pic_Click);
            // 
            // cmsColor
            // 
            this.cmsColor.Name = "cmsColor";
            this.cmsColor.Size = new System.Drawing.Size(61, 4);
            this.cmsColor.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsColor_ItemClicked);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tlpPanel.SetColumnSpan(this.btnCerrar, 2);
            this.btnCerrar.Location = new System.Drawing.Point(382, 147);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(70, 23);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "button1";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.tlpPanel.SetColumnSpan(this.lblStatus, 2);
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.ForeColor = System.Drawing.Color.Lime;
            this.lblStatus.Location = new System.Drawing.Point(65, 140);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(269, 37);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status";
            // 
            // chkDemo
            // 
            this.chkDemo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkDemo.AutoSize = true;
            this.chkDemo.ForeColor = System.Drawing.Color.Lime;
            this.chkDemo.Location = new System.Drawing.Point(340, 9);
            this.chkDemo.Name = "chkDemo";
            this.chkDemo.Size = new System.Drawing.Size(80, 17);
            this.chkDemo.TabIndex = 15;
            this.chkDemo.Text = "checkBox1";
            this.chkDemo.UseVisualStyleBackColor = true;
            this.chkDemo.CheckedChanged += new System.EventHandler(this.chkDemo_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(455, 177);
            this.Controls.Add(this.tlpPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.Text = "RGB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.TextBox txtRed;
        private System.Windows.Forms.TextBox txtGreen;
        private System.Windows.Forms.TextBox txtBlue;
        private System.Windows.Forms.TrackBar tkbRed;
        private System.Windows.Forms.TrackBar tkbGreen;
        private System.Windows.Forms.TrackBar tkbBlue;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox cmbPuerto;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.ContextMenuStrip cmsColor;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkDemo;
    }
}

