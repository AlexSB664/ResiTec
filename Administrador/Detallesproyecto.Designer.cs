namespace Administrador
{
    partial class Detallesproyecto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Detallesproyecto));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Status = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cargoasesor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.correoasesorext = new System.Windows.Forms.TextBox();
            this.telefonoasesorext = new System.Windows.Forms.TextBox();
            this.NombreAsesorexterno = new System.Windows.Forms.TextBox();
            this.Nombreproyecto = new System.Windows.Forms.TextBox();
            this.Nombreempresa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Eliminar);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.cargoasesor);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.correoasesorext);
            this.panel2.Controls.Add(this.telefonoasesorext);
            this.panel2.Controls.Add(this.NombreAsesorexterno);
            this.panel2.Controls.Add(this.Nombreproyecto);
            this.panel2.Controls.Add(this.Nombreempresa);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 148);
            this.panel2.TabIndex = 32;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Status);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 27);
            this.panel1.TabIndex = 34;
            // 
            // Status
            // 
            this.Status.FormattingEnabled = true;
            this.Status.Location = new System.Drawing.Point(75, 0);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(121, 21);
            this.Status.TabIndex = 30;
            this.Status.SelectedIndexChanged += new System.EventHandler(this.Status_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(202, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 25);
            this.button1.TabIndex = 33;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cargoasesor
            // 
            this.cargoasesor.Location = new System.Drawing.Point(732, 103);
            this.cargoasesor.Name = "cargoasesor";
            this.cargoasesor.ReadOnly = true;
            this.cargoasesor.Size = new System.Drawing.Size(100, 20);
            this.cargoasesor.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(637, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Cargo asesor";
            // 
            // correoasesorext
            // 
            this.correoasesorext.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.correoasesorext.Location = new System.Drawing.Point(107, 106);
            this.correoasesorext.Name = "correoasesorext";
            this.correoasesorext.ReadOnly = true;
            this.correoasesorext.Size = new System.Drawing.Size(100, 20);
            this.correoasesorext.TabIndex = 26;
            // 
            // telefonoasesorext
            // 
            this.telefonoasesorext.Location = new System.Drawing.Point(531, 107);
            this.telefonoasesorext.Name = "telefonoasesorext";
            this.telefonoasesorext.ReadOnly = true;
            this.telefonoasesorext.Size = new System.Drawing.Size(100, 20);
            this.telefonoasesorext.TabIndex = 25;
            // 
            // NombreAsesorexterno
            // 
            this.NombreAsesorexterno.Location = new System.Drawing.Point(305, 106);
            this.NombreAsesorexterno.Name = "NombreAsesorexterno";
            this.NombreAsesorexterno.ReadOnly = true;
            this.NombreAsesorexterno.Size = new System.Drawing.Size(100, 20);
            this.NombreAsesorexterno.TabIndex = 24;
            // 
            // Nombreproyecto
            // 
            this.Nombreproyecto.Location = new System.Drawing.Point(152, 33);
            this.Nombreproyecto.Name = "Nombreproyecto";
            this.Nombreproyecto.ReadOnly = true;
            this.Nombreproyecto.Size = new System.Drawing.Size(354, 20);
            this.Nombreproyecto.TabIndex = 23;
            // 
            // Nombreempresa
            // 
            this.Nombreempresa.Location = new System.Drawing.Point(689, 35);
            this.Nombreempresa.Name = "Nombreempresa";
            this.Nombreempresa.ReadOnly = true;
            this.Nombreempresa.Size = new System.Drawing.Size(153, 20);
            this.Nombreempresa.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Correo asesor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Telesono asesor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Asesor externo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(583, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Empresa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Nombre de Proyecto";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 148);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(960, 313);
            this.panel3.TabIndex = 33;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(960, 313);
            this.dataGridView1.TabIndex = 1;
            // 
            // Eliminar
            // 
            this.Eliminar.BackColor = System.Drawing.Color.White;
            this.Eliminar.BackgroundImage = global::Administrador.Properties.Resources.delete;
            this.Eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Eliminar.Location = new System.Drawing.Point(866, 39);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(82, 67);
            this.Eliminar.TabIndex = 35;
            this.Eliminar.UseVisualStyleBackColor = false;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // Detallesproyecto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(960, 504);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Detallesproyecto";
            this.Text = "Detallesproyecto";
            this.Load += new System.EventHandler(this.Detallesproyecto_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox cargoasesor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox correoasesorext;
        private System.Windows.Forms.TextBox telefonoasesorext;
        private System.Windows.Forms.TextBox NombreAsesorexterno;
        private System.Windows.Forms.TextBox Nombreproyecto;
        private System.Windows.Forms.TextBox Nombreempresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Status;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Eliminar;
    }
}