using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnecionBDMSQL.myclass
{
    class conexionMsSql : base_conexion
    {
        private SqlConnection conexion = new SqlConnection();
        private SqlCommand comando;
        private SqlDataReader lector;  
       public conexionMsSql(string host, string user, string password, string database)
        {
            this.host = host;
            this.user = user;
            this.password = password;
            this.database = database;

            stringConeccion = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True",host,database);

            conexion.ConnectionString = stringConeccion;  

        }
        public override void open()
        {
            try
            { 
                conexion.Open();
                Console.WriteLine("Conexión establecida con el servidor {0} y base de datos {1}", host, database);
            }
            catch { Console.WriteLine("Error en el Servidor"); }
        }

        public override void close()
        {
            conexion.Close();

            Console.WriteLine("Conexión cerrada con el servidor {0}", host);

        }

        public override DataTable obtener_datos(string query)
        {
            DataTable resultado = new DataTable();

            comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = query;
            
            lector = comando.ExecuteReader();

            resultado.Load(lector);

            comando.Dispose();
            lector.Close();
            close();

            return resultado;

        }

    }
}
