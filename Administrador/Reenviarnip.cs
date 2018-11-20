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
using AutomatizacionResidencias;
namespace Administrador
{
    public partial class Reenviarnip : Form
    {
        public static int Nocontrol;
        public static string passwornew;
        public Reenviarnip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alumno al=null;
            if (int.TryParse(textBox1.Text,out Nocontrol)) {

                using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
                {
                    al = context.Alumno.FirstOrDefault(x=>x.NoControl==Nocontrol);
                    
                }

                if (al != null)
                {
                    using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString))
                    {
                        var alumno = context.Alumno.FirstOrDefault(x => x.NoControl == Nocontrol);
                        Random r = new Random();
                        var usuario = context.Usuario.FirstOrDefault(m => m.Usuario1 == alumno.Correo);
                        passwornew = r.Next(10000, 99999).ToString();
                        usuario.Password = passwornew;
                        
                        Enviarcorreo enviar = new Enviarcorreo();
                        enviar.password = passwornew;
                        enviar.correo = alumno.Correo;
                        enviar.enviar();
                        context.SaveChanges();
                        MessageBox.Show("Nip: " + passwornew);
                        
                    }
                }
                else {
                    MessageBox.Show("No existe un alumno con este No de control");
                }
                
            }
        }
    }
}
