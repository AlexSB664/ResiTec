namespace Administrador
{
    partial class DetallesAsesorinterno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetallesAsesorinterno));
            this.panel3 = new System.Windows.Forms.Panel();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Correoasesorinterno = new System.Windows.Forms.TextBox();
            this.Telefonoasesorinterno = new System.Windows.Forms.TextBox();
            this.NombreAsesorinterno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Eliminar);
            this.panel3.Controls.Add(this.Correoasesorinterno);
            this.panel3.Controls.Add(this.Telefonoasesorinterno);
            this.panel3.Controls.Add(this.NombreAsesorinterno);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(847, 95);
            this.panel3.TabIndex = 33;
            // 
            // Eliminar
            // 
            this.Eliminar.BackColor = System.Drawing.Color.White;
            this.Eliminar.BackgroundImage = global::Administrador.Properties.Resources.delete;
            this.Eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Eliminar.Location = new System.Drawing.Point(740, 12);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(82, 67);
            this.Eliminar.TabIndex = 26;
            this.Eliminar.UseVisualStyleBackColor = false;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // Correoasesorinterno
            // 
            this.Correoasesorinterno.Location = new System.Drawing.Point(367, 66);
            this.Correoasesorinterno.Name = "Correoasesorinterno";
            this.Correoasesorinterno.ReadOnly = true;
            this.Correoasesorinterno.Size = new System.Drawing.Size(155, 20);
            this.Correoasesorinterno.TabIndex = 25;
            // 
            // Telefonoasesorinterno
            // 
            this.Telefonoasesorinterno.Location = new System.Drawing.Point(123, 66);
            this.Telefonoasesorinterno.Name = "Telefonoasesorinterno";
            this.Telefonoasesorinterno.ReadOnly = true;
            this.Telefonoasesorinterno.Size = new System.Drawing.Size(169, 20);
            this.Telefonoasesorinterno.TabIndex = 24;
            // 
            // NombreAsesorinterno
            // 
            this.NombreAsesorinterno.Location = new System.Drawing.Point(123, 32);
            this.NombreAsesorinterno.Name = "NombreAsesorinterno";
            this.NombreAsesorinterno.ReadOnly = true;
            this.NombreAsesorinterno.Size = new System.Drawing.Size(399, 20);
            this.NombreAsesorinterno.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Correo";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Telefono asesor";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(114, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Nombre Asesor interno";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 286);
            this.panel1.TabIndex = 34;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(847, 286);
            this.dataGridView1.TabIndex = 2;
            // 
            // DetallesAsesorinterno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(847, 417);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetallesAsesorinterno";
            this.Text = "DetallesAsesorinterno";
            this.Load += new System.EventHandler(this.DetallesAsesorinterno_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox Correoasesorinterno;
        private System.Windows.Forms.TextBox Telefonoasesorinterno;
        private System.Windows.Forms.TextBox NombreAsesorinterno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Eliminar;
    }
}