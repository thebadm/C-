using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnecionBDMSQL
{
     public class Coneccionsql 
    {
     SqlConnection con;
     SqlCommand comando;
     SqlDataReader dt;
       public Coneccionsql()
       {
           con = new SqlConnection("Data Source=The_Badm_Davila;Initial Catalog=academia;Integrated Security=True");
           con.Open();
           Console.WriteLine("Conexión abierta al Servidor : " + con.DataSource);
           Console.WriteLine("");
           SqlCommand comando = new SqlCommand("SELECT * FROM adm_alumnos ", con);
           SqlDataReader dt = comando.ExecuteReader();
           while (dt.Read())
           {
               //int id = reader.GetInt32(0);
               String c_ncar = dt.GetString(0);
               String d_nombr = dt.GetString(1);
               String d_apellido = dt.GetString(2);
               String N_telefono = dt.GetString(3);
               String sexo = dt.GetString(4);

               Console.WriteLine("Nombres :{1} Apellidos: {2} # Telefono: {3} Sexo : {4} ", c_ncar, d_nombr, d_apellido, N_telefono, sexo);
               Console.WriteLine("-------------------------------------------------------------------------------");
           }
            
           
           
           Console.ReadKey();
           con.Close();
       }
     }
}
