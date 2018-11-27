namespace Administrador
{
    partial class Nuevohorario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nuevohorario));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.Horainicio = new System.Windows.Forms.ComboBox();
            this.minutoinicio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Minutofin = new System.Windows.Forms.ComboBox();
            this.Horafin = new System.Windows.Forms.ComboBox();
            this.Noproyecto = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(73, 28);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // Horainicio
            // 
            this.Horainicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Horainicio.FormattingEnabled = true;
            this.Horainicio.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.Horainicio.Location = new System.Drawing.Point(12, 224);
            this.Horainicio.Name = "Horainicio";
            this.Horainicio.Size = new System.Drawing.Size(63, 21);
            this.Horainicio.TabIndex = 1;
            // 
            // minutoinicio
            // 
            this.minutoinicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.minutoinicio.FormattingEnabled = true;
            this.minutoinicio.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.minutoinicio.Location = new System.Drawing.Point(97, 224);
            this.minutoinicio.Name = "minutoinicio";
            this.minutoinicio.Size = new System.Drawing.Size(63, 21);
            this.minutoinicio.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hasta";
            // 
            // Minutofin
            // 
            this.Minutofin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Minutofin.FormattingEnabled = true;
            this.Minutofin.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.Minutofin.Location = new System.Drawing.Point(278, 224);
            this.Minutofin.Name = "Minutofin";
            this.Minutofin.Size = new System.Drawing.Size(63, 21);
            this.Minutofin.TabIndex = 5;
            // 
            // Horafin
            // 
            this.Horafin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Horafin.FormattingEnabled = true;
            this.Horafin.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.Horafin.Location = new System.Drawing.Point(193, 224);
            this.Horafin.Name = "Horafin";
            this.Horafin.Size = new System.Drawing.Size(63, 21);
            this.Horafin.TabIndex = 4;
            // 
            // Noproyecto
            // 
            this.Noproyecto.AutoSize = true;
            this.Noproyecto.Location = new System.Drawing.Point(168, 9);
            this.Noproyecto.Name = "Noproyecto";
            this.Noproyecto.Size = new System.Drawing.Size(62, 13);
            this.Noproyecto.TabIndex = 7;
            this.Noproyecto.Text = "Noproyecto";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(129, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = ":";
            // 
            // Nuevohorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(379, 328);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Noproyecto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Minutofin);
            this.Controls.Add(this.Horafin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minutoinicio);
            this.Controls.Add(this.Horainicio);
            this.Controls.Add(this.monthCalendar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Nuevohorario";
            this.Text = "Nuevohorario";
            this.Load += new System.EventHandler(this.Nuevohorario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ComboBox Horainicio;
        private System.Windows.Forms.ComboBox minutoinicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Minutofin;
        private System.Windows.Forms.ComboBox Horafin;
        private System.Windows.Forms.Label Noproyecto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}