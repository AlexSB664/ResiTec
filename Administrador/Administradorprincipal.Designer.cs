namespace Administrador
{
    partial class Administradorprincipal
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.noProyectoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreProyectoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDeLaEmpresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreAsesorExternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargoAsesorExternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoAsesorExternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correoAsesorExternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAsesorInternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proyectoResidenciaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proyectosdeResidencia = new Administrador.ProyectosdeResidencia();
            this.proyecto_ResidenciaTableAdapter = new Administrador.ProyectosdeResidenciaTableAdapters.Proyecto_ResidenciaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoResidenciaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectosdeResidencia)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noProyectoDataGridViewTextBoxColumn,
            this.nombreProyectoDataGridViewTextBoxColumn,
            this.nombreDeLaEmpresaDataGridViewTextBoxColumn,
            this.nombreAsesorExternoDataGridViewTextBoxColumn,
            this.cargoAsesorExternoDataGridViewTextBoxColumn,
            this.telefonoAsesorExternoDataGridViewTextBoxColumn,
            this.correoAsesorExternoDataGridViewTextBoxColumn,
            this.fechaRegistroDataGridViewTextBoxColumn,
            this.idAsesorInternoDataGridViewTextBoxColumn,
            this.idStatusDataGridViewTextBoxColumn,
            this.periodoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.proyectoResidenciaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1139, 278);
            this.dataGridView1.TabIndex = 0;
            // 
            // noProyectoDataGridViewTextBoxColumn
            // 
            this.noProyectoDataGridViewTextBoxColumn.DataPropertyName = "No Proyecto";
            this.noProyectoDataGridViewTextBoxColumn.HeaderText = "No Proyecto";
            this.noProyectoDataGridViewTextBoxColumn.Name = "noProyectoDataGridViewTextBoxColumn";
            this.noProyectoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreProyectoDataGridViewTextBoxColumn
            // 
            this.nombreProyectoDataGridViewTextBoxColumn.DataPropertyName = "Nombre Proyecto";
            this.nombreProyectoDataGridViewTextBoxColumn.HeaderText = "Nombre Proyecto";
            this.nombreProyectoDataGridViewTextBoxColumn.Name = "nombreProyectoDataGridViewTextBoxColumn";
            // 
            // nombreDeLaEmpresaDataGridViewTextBoxColumn
            // 
            this.nombreDeLaEmpresaDataGridViewTextBoxColumn.DataPropertyName = "Nombre de la Empresa";
            this.nombreDeLaEmpresaDataGridViewTextBoxColumn.HeaderText = "Nombre de la Empresa";
            this.nombreDeLaEmpresaDataGridViewTextBoxColumn.Name = "nombreDeLaEmpresaDataGridViewTextBoxColumn";
            // 
            // nombreAsesorExternoDataGridViewTextBoxColumn
            // 
            this.nombreAsesorExternoDataGridViewTextBoxColumn.DataPropertyName = "Nombre Asesor Externo";
            this.nombreAsesorExternoDataGridViewTextBoxColumn.HeaderText = "Nombre Asesor Externo";
            this.nombreAsesorExternoDataGridViewTextBoxColumn.Name = "nombreAsesorExternoDataGridViewTextBoxColumn";
            // 
            // cargoAsesorExternoDataGridViewTextBoxColumn
            // 
            this.cargoAsesorExternoDataGridViewTextBoxColumn.DataPropertyName = "Cargo Asesor Externo";
            this.cargoAsesorExternoDataGridViewTextBoxColumn.HeaderText = "Cargo Asesor Externo";
            this.cargoAsesorExternoDataGridViewTextBoxColumn.Name = "cargoAsesorExternoDataGridViewTextBoxColumn";
            // 
            // telefonoAsesorExternoDataGridViewTextBoxColumn
            // 
            this.telefonoAsesorExternoDataGridViewTextBoxColumn.DataPropertyName = "Telefono Asesor Externo";
            this.telefonoAsesorExternoDataGridViewTextBoxColumn.HeaderText = "Telefono Asesor Externo";
            this.telefonoAsesorExternoDataGridViewTextBoxColumn.Name = "telefonoAsesorExternoDataGridViewTextBoxColumn";
            // 
            // correoAsesorExternoDataGridViewTextBoxColumn
            // 
            this.correoAsesorExternoDataGridViewTextBoxColumn.DataPropertyName = "Correo Asesor Externo";
            this.correoAsesorExternoDataGridViewTextBoxColumn.HeaderText = "Correo Asesor Externo";
            this.correoAsesorExternoDataGridViewTextBoxColumn.Name = "correoAsesorExternoDataGridViewTextBoxColumn";
            // 
            // fechaRegistroDataGridViewTextBoxColumn
            // 
            this.fechaRegistroDataGridViewTextBoxColumn.DataPropertyName = "Fecha Registro";
            this.fechaRegistroDataGridViewTextBoxColumn.HeaderText = "Fecha Registro";
            this.fechaRegistroDataGridViewTextBoxColumn.Name = "fechaRegistroDataGridViewTextBoxColumn";
            // 
            // idAsesorInternoDataGridViewTextBoxColumn
            // 
            this.idAsesorInternoDataGridViewTextBoxColumn.DataPropertyName = "IdAsesorInterno";
            this.idAsesorInternoDataGridViewTextBoxColumn.HeaderText = "IdAsesorInterno";
            this.idAsesorInternoDataGridViewTextBoxColumn.Name = "idAsesorInternoDataGridViewTextBoxColumn";
            // 
            // idStatusDataGridViewTextBoxColumn
            // 
            this.idStatusDataGridViewTextBoxColumn.DataPropertyName = "IdStatus";
            this.idStatusDataGridViewTextBoxColumn.HeaderText = "IdStatus";
            this.idStatusDataGridViewTextBoxColumn.Name = "idStatusDataGridViewTextBoxColumn";
            // 
            // periodoDataGridViewTextBoxColumn
            // 
            this.periodoDataGridViewTextBoxColumn.DataPropertyName = "Periodo";
            this.periodoDataGridViewTextBoxColumn.HeaderText = "Periodo";
            this.periodoDataGridViewTextBoxColumn.Name = "periodoDataGridViewTextBoxColumn";
            // 
            // proyectoResidenciaBindingSource
            // 
            this.proyectoResidenciaBindingSource.DataMember = "Proyecto Residencia";
            this.proyectoResidenciaBindingSource.DataSource = this.proyectosdeResidencia;
            // 
            // proyectosdeResidencia
            // 
            this.proyectosdeResidencia.DataSetName = "ProyectosdeResidencia";
            this.proyectosdeResidencia.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // proyecto_ResidenciaTableAdapter
            // 
            this.proyecto_ResidenciaTableAdapter.ClearBeforeFill = true;
            // 
            // Administradorprincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 499);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Administradorprincipal";
            this.Text = "Administradorprincipal";
            this.Load += new System.EventHandler(this.Administradorprincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoResidenciaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proyectosdeResidencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ProyectosdeResidencia proyectosdeResidencia;
        private System.Windows.Forms.BindingSource proyectoResidenciaBindingSource;
        private ProyectosdeResidenciaTableAdapters.Proyecto_ResidenciaTableAdapter proyecto_ResidenciaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn noProyectoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProyectoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDeLaEmpresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreAsesorExternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargoAsesorExternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoAsesorExternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn correoAsesorExternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAsesorInternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodoDataGridViewTextBoxColumn;
    }
}