using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AutomatizacionResidencias.Modelos;
namespace AutomatizacionResidencias.Acciones
{
   public  class Conexion
    {
        public static EntityConnectionStringBuilder csb = new EntityConnectionStringBuilder();
       public string Metadata = "res://*/EmbarquesOrigen.csdl|res://*/EmbarquesOrigen.ssdl|res://*/EmbarquesOrigen.msl";
      public string Provider = "System.Data.SqlClient";
        public string connectionstring;
        private TimeSpan ciclo;
        private int millisecondsciclo;

        public  Conexion() {
            string directory = System.IO.Path.GetDirectoryName(new System.Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            string text = System.IO.File.ReadAllText(directory + @"\Conexion.txt");
            Modelos.Settings set = JsonConvert.DeserializeObject<Settings>(text);
            ciclo = TimeSpan.Parse(set.tiempo);
            try
            {
                millisecondsciclo = int.Parse(ciclo.TotalMilliseconds.ToString());
            }
            catch { }
            csb.Metadata = Metadata;
            csb.Provider = Provider;
            csb.ProviderConnectionString = set.connectionstring;
        }
        public EntityConnectionStringBuilder  returnconexion() {
            return csb;
        }


       
        private static bool IsServerConnected(string connectionString, out string Errores)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    Errores = "";
                    return true;
                }
                catch (SqlException ex)
                {
                    Errores = ex.Message;
                    return false;
                }
            }
        }
    }
}
