namespace Administrador
{
    partial class AgendarExpo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgendarExpo));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Residenciasasignadas = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Residenciasparaasignar = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Eliminar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.grupo = new System.Windows.Forms.Label();
            this.Asignar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Residenciasasignadas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Residenciasparaasignar)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1522, 129);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Crear Grupo";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.comboBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 44);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1522, 85);
            this.panel5.TabIndex = 0;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(1400, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Resindencias sin asgnar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grupos";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(265, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 675);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1522, 38);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Residenciasasignadas);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 129);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(694, 546);
            this.panel4.TabIndex = 4;
            // 
            // Residenciasasignadas
            // 
            this.Residenciasasignadas.AllowUserToAddRows = false;
            this.Residenciasasignadas.AllowUserToDeleteRows = false;
            this.Residenciasasignadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Residenciasasignadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Residenciasasignadas.Location = new System.Drawing.Point(0, 0);
            this.Residenciasasignadas.MultiSelect = false;
            this.Residenciasasignadas.Name = "Residenciasasignadas";
            this.Residenciasasignadas.ReadOnly = true;
            this.Residenciasasignadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Residenciasasignadas.Size = new System.Drawing.Size(694, 546);
            this.Residenciasasignadas.TabIndex = 0;
            this.Residenciasasignadas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Residenciasasignadas_CellContentClick);
            this.Residenciasasignadas.DoubleClick += new System.EventHandler(this.Residenciasasignadas_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Residenciasparaasignar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(901, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 546);
            this.panel1.TabIndex = 5;
            // 
            // Residenciasparaasignar
            // 
            this.Residenciasparaasignar.AllowUserToAddRows = false;
            this.Residenciasparaasignar.AllowUserToDeleteRows = false;
            this.Residenciasparaasignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Residenciasparaasignar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Residenciasparaasignar.Location = new System.Drawing.Point(0, 0);
            this.Residenciasparaasignar.MultiSelect = false;
            this.Residenciasparaasignar.Name = "Residenciasparaasignar";
            this.Residenciasparaasignar.ReadOnly = true;
            this.Residenciasparaasignar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Residenciasparaasignar.Size = new System.Drawing.Size(621, 546);
            this.Residenciasparaasignar.TabIndex = 1;
            this.Residenciasparaasignar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Residenciasparaasignar_CellContentClick);
            this.Residenciasparaasignar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Residenciasparaasignar_CellContentClick_1);
            this.Residenciasparaasignar.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Residenciasparaasignar_DataBindingComplete);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.Eliminar);
            this.panel6.Controls.Add(this.button2);
            this.panel6.Controls.Add(this.grupo);
            this.panel6.Controls.Add(this.Asignar);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(694, 129);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(207, 546);
            this.panel6.TabIndex = 6;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            this.panel6.DoubleClick += new System.EventHandler(this.panel6_DoubleClick);
            // 
            // Eliminar
            // 
            this.Eliminar.BackColor = System.Drawing.Color.Red;
            this.Eliminar.BackgroundImage = global::Administrador.Properties.Resources.delete;
            this.Eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Eliminar.Location = new System.Drawing.Point(62, 407);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(96, 78);
            this.Eliminar.TabIndex = 32;
            this.Eliminar.UseVisualStyleBackColor = false;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Administrador.Properties.Resources._1__3ihG_PMKFRk_TGX6x8rOw;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(62, 296);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 86);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // grupo
            // 
            this.grupo.AutoSize = true;
            this.grupo.Location = new System.Drawing.Point(89, 153);
            this.grupo.Name = "grupo";
            this.grupo.Size = new System.Drawing.Size(34, 13);
            this.grupo.TabIndex = 1;
            this.grupo.Text = "grupo";
            this.grupo.Click += new System.EventHandler(this.label2_Click);
            // 
            // Asignar
            // 
            this.Asignar.Location = new System.Drawing.Point(57, 213);
            this.Asignar.Name = "Asignar";
            this.Asignar.Size = new System.Drawing.Size(101, 28);
            this.Asignar.TabIndex = 0;
            this.Asignar.Text = "<<";
            this.Asignar.UseVisualStyleBackColor = true;
            this.Asignar.Click += new System.EventHandler(this.Asignar_Click);
            // 
            // AgendarExpo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1522, 713);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AgendarExpo";
            this.Text = "AgendarExpo";
            this.Load += new System.EventHandler(this.AgendarExpo_Load);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Residenciasasignadas)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Residenciasparaasignar)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView Residenciasasignadas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView Residenciasparaasignar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button Asignar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label grupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Eliminar;
    }
}