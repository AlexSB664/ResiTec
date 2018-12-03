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
    public partial class Periodos : Form
    {
        public static bool periodo = false;
        AutomatizacionResidencias.Acciones.Periodos op = new AutomatizacionResidencias.Acciones.Periodos();
        public List<AutomatizacionResidencias.Periodos> periodos = new List<AutomatizacionResidencias.Periodos>();

        public static Eliminar eliminar = new Eliminar();
       
        public static string curper;
        public static BindingSource bin = new BindingSource();

        public addperiodo addperiodo;
        public Periodos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Errores;
            if (int.TryParse(textBox1.Text, out int Result))
            {
                AutomatizacionResidencias.Periodos a = new AutomatizacionResidencias.Periodos() { año = Result, periodo = periodo };
                if (op.crearperiodo(a, out Errores))
                {
                    MessageBox.Show("Se ha guardado el periodo");

                    string Errore = "";
                    periodos = op.listaperiodos(out Errore);
                    datagrid();
                }
                else
                {
                    MessageBox.Show(Errores);
                }
            }
            else
            {
                MessageBox.Show("Año invalido");
            }



        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            periodo = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            periodo = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void datagrid()
        {
            var bindingList = new BindingList<AutomatizacionResidencias.Periodos>(periodos);


            var source = new BindingSource(bindingList, null);

            dataGridView1.DataSource = source;
            dataGridView1.Columns["Proyecto_Residencia"].Visible = false;



        }


        private void Periodos_Load(object sender, EventArgs e)
        {
            string Errore = "";
            periodos = op.listaperiodos(out Errore);
            datagrid();

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            currentperiodo.Text = op.periodoactual().Idperiodo.ToString();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int i = e.RowIndex; i < e.RowCount + e.RowIndex; i++)
            {
                

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Errores = "";
           curper=(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());




            if (op.Establecerperiodo(curper, out Errores))
            {
                currentperiodo.Text = curper;
                addperiodo();
            }
            else {
                MessageBox.Show(Errores);
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Errores = null;
            var confirmResult = MessageBox.Show("Seguro que desea eliminar", "Confirme borrado",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                bool si = eliminar.Eliminarperiodos(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()), out Errores);

                if (si == true)
                {

                    MessageBox.Show("Se elimino");
                    var per=periodos.FirstOrDefault(x=>x.Idperiodo== int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                    periodos.Remove(per);
                    datagrid();
                    addperiodo();


                }
                else
                {
                    MessageBox.Show("Errores: " + Errores);

                }
            }
            else
            {
                // If 'No', do something here.
            }
        }
    }
}
