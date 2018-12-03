using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomatizacionResidencias;
using AutomatizacionResidencias.Decorator;
using AutomatizacionResidencias.Acciones;
using System.Text.RegularExpressions;

namespace AplicacionAlumnos
{
    public partial class Editardatos : Form
    {
        public Asesor_Interno asesorinterno = null;
        public static Proyectoresidencia regresidencia = new Proyectoresidencia();
        public static AsesorInterno regasesorinterno = new AsesorInterno();
        public Proyecto_Residencia proyectoresidencia = null;
        public string oldNocontrol;
        public static BindingSource bindingsourceproyectos = new BindingSource();
        public static BindingSource bindingsourceasesores = new BindingSource();
        public List<Proyecto_Residencia> proyectos = new List<Proyecto_Residencia>();
        public List<Asesor_Interno> asesores = new List<Asesor_Interno>();
        public static Sugerencias sugerencia = new Sugerencias();
        public static bool residenciaexistente = true;
        public static bool asesorinternoexistente = true;
        public static EdicionDatosalumno edicion = new EdicionDatosalumno();
        public static int Nopro;
        public  string Correo = null;
        public Editardatos(string correo)
        {
            InitializeComponent();
            this.Correo = correo;

        }

        private void Editardatos_Load(object sender, EventArgs e)
        {
            //Carga datos del alumno residencia
            edicion.buscaralumno(Correo);

            NoControl.Text = edicion.alumno.NoControl.ToString();
            //Establece datos de alumno en los campos
            nombrealumno.Text = edicion.alumno.Nombre.ToString();
            Apellidopalumno.Text = edicion.alumno.Apellido_Paterno;
            Apellidomalumno.Text = edicion.alumno.Apellido_Materno;
            numsemestre.Text = edicion.alumno.Semestre.ToString();
            numtelefonoalumno.Text = edicion.alumno.Telefono;
            correoelectronicoalumno.Text = edicion.alumno.Correo;
            Genero.SelectedItem = edicion.alumno.Genero;

            //establece datos del proyecto en los campos
            try
            {
                Nombreproyecto.Text = edicion.alumno.Proyecto_Residencia.Nombre_Proyecto;
                Nombreempresa.Text = edicion.alumno.Proyecto_Residencia.Nombre_de_la_Empresa;
                NombreAsesorexterno.Text = edicion.alumno.Proyecto_Residencia.Nombre_Asesor_Externo;
                cargoasesor.Text = edicion.alumno.Proyecto_Residencia.Cargo_Asesor_Externo;
                correoasesorext.Text = edicion.alumno.Proyecto_Residencia.Correo_Asesor_Externo;
                telefonoasesorext.Text = edicion.alumno.Proyecto_Residencia.Telefono_Asesor_Externo;
                Area.Text = edicion.alumno.Proyecto_Residencia.Area_del_Proyecto;

            }
            catch { }

            //Establece datos del asesor en los campos
            try
            {
                NombreAsesorinterno.Text = edicion.alumno.Proyecto_Residencia.Asesor_Interno.Nombre;
                Telefonoasesorinterno.Text = edicion.alumno.Proyecto_Residencia.Asesor_Interno.Telefono;
                Correoasesorinterno.Text = edicion.alumno.Proyecto_Residencia.Asesor_Interno.Correo;
            }
            catch { }
            try
            {
                asesores = sugerencia.Asesoresinternos();
                bindingsourceasesores.DataSource = asesores;
                AsesoresInternos.DataSource = bindingsourceasesores.DataSource;
                AsesoresInternos.DisplayMember = "Nombre";
                AsesoresInternos.ValueMember = "IdAsesor";

                proyectos = sugerencia.proyectosregistrados();
                bindingsourceproyectos.DataSource = proyectos;
                Residencias.DataSource = bindingsourceproyectos.DataSource;
                Residencias.DisplayMember = "Nombre_Proyecto";
                Residencias.ValueMember = "No_Proyecto";
                Residencias.SelectedValue = edicion.alumno.NoProyecto;

               
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (validar()) {
                //se guarda cualquier cambio hecho

                edicion.alumno.Nombre = nombrealumno.Text;
                edicion.alumno.Apellido_Paterno = Apellidopalumno.Text;
                edicion.alumno.Apellido_Materno = Apellidomalumno.Text;
                edicion.alumno.Correo = correoelectronicoalumno.Text;
                edicion.alumno.Semestre = int.Parse(numsemestre.Text);
                edicion.alumno.Telefono = numtelefonoalumno.Text;
                edicion.alumno.Genero = Genero.Text;

                try
                {
                    edicion.alumno.NoProyecto = proyectoresidencia.No_Proyecto;
                    edicion.alumno.Proyecto_Residencia.Nombre_Proyecto = Nombreproyecto.Text;
                    edicion.alumno.Proyecto_Residencia.Nombre_de_la_Empresa = Nombreempresa.Text;
                    edicion.alumno.Proyecto_Residencia.Nombre_Asesor_Externo = NombreAsesorexterno.Text;
                    edicion.alumno.Proyecto_Residencia.Cargo_Asesor_Externo = cargoasesor.Text;
                    edicion.alumno.Proyecto_Residencia.Correo_Asesor_Externo = correoasesorext.Text;
                    edicion.alumno.Proyecto_Residencia.Telefono_Asesor_Externo = telefonoasesorext.Text;
                    edicion.alumno.Proyecto_Residencia.Area_del_Proyecto = Area.Text;

                }
                catch { }
                try
                {
                    edicion.alumno.Proyecto_Residencia.IdAsesorInterno = asesorinterno.IdAsesor;
                    edicion.alumno.Proyecto_Residencia.Asesor_Interno.Nombre = NombreAsesorinterno.Text;
                    edicion.alumno.Proyecto_Residencia.Asesor_Interno.Telefono = Telefonoasesorinterno.Text;
                    edicion.alumno.Proyecto_Residencia.Asesor_Interno.Correo = Correoasesorinterno.Text;
                }
                catch (Exception ex) {
                    edicion.alumno.Proyecto_Residencia.Asesor_Interno = new Asesor_Interno();

                    edicion.alumno.Proyecto_Residencia.Asesor_Interno.Nombre = NombreAsesorinterno.Text;
                    edicion.alumno.Proyecto_Residencia.Asesor_Interno.Telefono = Telefonoasesorinterno.Text;
                    edicion.alumno.Proyecto_Residencia.Asesor_Interno.Correo = Correoasesorinterno.Text;

                }




                //se guardan los cambios a la bd

                edicion.Guardarcambios(int.Parse(Correo), edicion.alumno.NoProyecto, edicion.alumno.Proyecto_Residencia.IdAsesorInterno);

                MessageBox.Show("Se han guardado los cambios");
            }
        }

        private void AsesoresInternos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var asesor = asesores.FirstOrDefault(x => x.IdAsesor == AsesoresInternos.SelectedIndex);

                NombreAsesorinterno.Text = asesor.Nombre;
                Telefonoasesorinterno.Text = asesor.Telefono;
                Correoasesorinterno.Text = asesor.Correo;
                residenciaexistente = true;
                asesorinternoexistente = true;
            }
            catch { }
            /*
            edicion.alumno.Proyecto_Residencia.IdAsesorInterno = AsesoresInternos.SelectedIndex;
            edicion.Guardarcambios();
    */
        }

        private void Residencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var proyecto = proyectos.FirstOrDefault(x => x.No_Proyecto == int.Parse(Residencias.SelectedValue.ToString()));
                var asesor = asesores.FirstOrDefault(x => x.IdAsesor == proyecto.IdAsesorInterno);
                Nombreproyecto.Text = proyecto.Nombre_Proyecto;
                Nombreempresa.Text = proyecto.Nombre_de_la_Empresa;
                NombreAsesorexterno.Text = proyecto.Nombre_Asesor_Externo;
                cargoasesor.Text = proyecto.Cargo_Asesor_Externo;
                correoasesorext.Text = proyecto.Correo_Asesor_Externo;
                telefonoasesorext.Text = proyecto.Telefono_Asesor_Externo;
                NombreAsesorinterno.Text = asesor.Nombre;
                proyectoresidencia = proyecto;
                Nopro = proyecto.No_Proyecto;
                residenciaexistente = true;
                asesorinternoexistente = true;
            }
            catch
            {

            }
        }

        private void Residencias_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (Residencias.SelectedValue != null)
                {

                    var proyecto = proyectos.FirstOrDefault(x => x.No_Proyecto == int.Parse(Residencias.SelectedValue.ToString()));

                    //MessageBox.Show(proyecto.IdAsesorInterno.ToString());
                    var asesor = asesores.FirstOrDefault(x => x.IdAsesor == proyecto.IdAsesorInterno);
                    Nombreproyecto.Text = proyecto.Nombre_Proyecto;
                    Nombreempresa.Text = proyecto.Nombre_de_la_Empresa;
                    NombreAsesorexterno.Text = proyecto.Nombre_Asesor_Externo;
                    cargoasesor.Text = proyecto.Cargo_Asesor_Externo;
                    correoasesorext.Text = proyecto.Correo_Asesor_Externo;
                    telefonoasesorext.Text = proyecto.Telefono_Asesor_Externo;
                    Area.Text = proyecto.Area_del_Proyecto;
                    //residenciaexistente = true;
                    proyectoresidencia = proyecto;
                    asesorinterno = asesor;
                    if (proyecto.IdAsesorInterno != null)
                    {
                        try
                        {
                            //MessageBox.Show(proyecto.IdAsesorInterno.ToString());
                            AsesoresInternos.SelectedValue = proyecto.IdAsesorInterno;
                            edicion.alumno.Proyecto_Residencia.IdAsesorInterno = proyecto.IdAsesorInterno;
                            // Cambiarasesor.Visible = true;
                            AsesoresInternos.Enabled = true;
                        }
                        catch(Exception ex) {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {

                        asesorinternoexistente = false;

                    }

                }
            }
            catch
            {

            }
        }

        private void AsesoresInternos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (AsesoresInternos.SelectedValue != null)
                {
                    var asesor = asesores.FirstOrDefault(x => x.IdAsesor == int.Parse(AsesoresInternos.SelectedValue.ToString()));
                    asesorinterno = asesor;
                    NombreAsesorinterno.Text = asesor.Nombre;
                    Telefonoasesorinterno.Text = asesor.Telefono;
                    Correoasesorinterno.Text = asesor.Correo;
                    asesorinternoexistente = true;

                }

            }
            catch (Exception ex)
            {

            }
        }



        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$").Success;
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool validar()
        {

            int nocontro;
            if (int.TryParse(NoControl.Text, out nocontro) && NoControl.Text.Length == 8)
            {
                if (nombrealumno.Text != "" && Apellidopalumno.Text != "" && Apellidomalumno.Text != "")
                {
                    int semes;
                    if (int.TryParse(numsemestre.Text, out semes))
                    {

                        if (IsPhoneNumber(numtelefonoalumno.Text))
                        {

                            if (IsValidEmail(correoelectronicoalumno.Text))
                            {

                                if (Nombreproyecto.Text != "")
                                {
                                    if (Nombreempresa.Text != "")
                                    {
                                        if (NombreAsesorexterno.Text != "")
                                        {
                                            if (cargoasesor.Text != "")
                                            {
                                                if (IsValidEmail(correoasesorext.Text))
                                                {
                                                    if (IsPhoneNumber(telefonoasesorext.Text))
                                                    {
                                                        if (NombreAsesorinterno.Text != "")
                                                        {
                                                            if (NombreAsesorinterno.Text != "" && Correoasesorinterno.Text != "" && Telefonoasesorinterno.Text != "")
                                                            {
                                                                if (IsValidEmail(Correoasesorinterno.Text))
                                                                {
                                                                    if (IsPhoneNumber(Telefonoasesorinterno.Text))
                                                                    {
                                                                        return true;

                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("El telefono del asesor interno no es vallido");
                                                                        return false;
                                                                    }

                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("El correo del asesor interno no es valido");
                                                                    return false;
                                                                }

                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Ingrese el nombre del asesor interno");
                                                                return false;
                                                            }

                                                        }
                                                        else
                                                        {
                                                            return true;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("El telefono del asesor externo es invalido");
                                                        return false;
                                                    }

                                                }
                                                else
                                                {
                                                    MessageBox.Show("El correo del asesor externo es invalido");
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Ingrese el cargo del asesor externo");
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ingrese el nombre del asesor externo");
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ingrese el nombre de la empresa");
                                        return false;
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Ingrese el nombre del proyecto");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("El correo del alumno no es valido");
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("El numero de telefono del alumno no es valido");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El semestre no es un numero valido");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Complete el nombre del alumno");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No control invalido");
                return false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
