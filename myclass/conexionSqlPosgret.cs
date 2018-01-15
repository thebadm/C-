using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace ConnecionBDMSQL.myclass
{
    class conexionSqlPosgret : base_conexion
    {
        NpgsqlCommand comando;
        NpgsqlConnection conexion= new NpgsqlConnection();
        NpgsqlDataReader lector;
        public conexionSqlPosgret(string host, string user, string password, string database)
        {

            this.host = host;
            this.user = user;
            this.password = password;
            this.database = database;

            stringConeccion = string.Format("Host={0};Username={1};Password={2};Database={3}", host,user ,password , database);

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

            comando = new NpgsqlCommand();

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
