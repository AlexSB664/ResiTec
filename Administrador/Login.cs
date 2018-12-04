using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomatizacionResidencias.Acciones;

namespace Administrador
{
    public partial class Login : Form
    {
        public bool login;
        Administradorprincipal a = null;
        public Login()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Errores;
            Autentificacion auten = new Autentificacion();
           login= (auten.autentificar(textBox1.Text, textBox2.Text, out Errores));

            if (login == true)
            {
                if (a == null)
                {
                    a = new Administradorprincipal(this);

                }
                if (a.IsDisposed)
                {
                    a = new Administradorprincipal(this);
                }
                // th
                textBox1.Text = "";
                textBox2.Text = "";

                this.Visible = false;
                a.Show();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
            

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
