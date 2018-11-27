using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutomatizacionResidencias;
using AutomatizacionResidencias.Acciones;
namespace Administrador
{
    public partial class DetallesAsesorinterno : Form
    {
        public static List<Tablaproyecto> proyectos = new List<Tablaproyecto>();

        public Busquedaentablas sug = new Busquedaentablas();
        public Asesor_Interno asesor = new Asesor_Interno();
        public DetallesAsesorinterno(int Idasesorinterno)
        {
            InitializeComponent();
            asesor = sug.Buscarasesorinternoespecifico(Idasesorinterno);

        }

        private void DetallesAsesorinterno_Load(object sender, EventArgs e)
        {
            NombreAsesorinterno.Text = asesor.Nombre;
            Telefonoasesorinterno.Text = asesor.Telefono;
            Correoasesorinterno.Text = asesor.Correo;

            proyectos = sug.Busquedadeproyectos(asesor.IdAsesor);
            proyecto();

        }

        public void proyecto()
        {
            // var status = sug.statusdeproyectos();
            var bindingList = new BindingList<Tablaproyecto>(proyectos);

            //var bindingSourceMonth = new BindingList<statusdeproyecto>(status);

            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;


            DataGridViewComboBoxColumn ColumnMonth = new DataGridViewComboBoxColumn();
            ColumnMonth.DataPropertyName = "status";
            ColumnMonth.HeaderText = "status";
            ColumnMonth.Width = 120;
            //ColumnMonth.DataSource = bindingSourceMonth;
            ColumnMonth.ValueMember = "IdStatus";
            ColumnMonth.DisplayMember = "nombre";
            dataGridView1.Columns["Status"].Visible = false;
            // dataGridView1.Columns.Add(ColumnMonth);
            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (row.Cells[11].Value != null)
                {
                    row.DefaultCellStyle.BackColor = Color.FromName(row.Cells[11].Value.ToString()); ;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dataGridView1.Rows[row.Index].Cells[cell.ColumnIndex].Style.ForeColor = Color.White;
                    }
                }

        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Seguro que desea eliminar", "Confirme borrado",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                MessageBox.Show("Se elimino");
            }
            else
            {
                // If 'No', do something here.
            }
        }
    }
}
