using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ConnecionBDMSQL.myclass;
using System.Data;

namespace ConnecionBDMSQL
{
     public class Program
    {
        static void Main(string[] args)
        {

            List<base_conexion> Coneciones = new List<base_conexion>();

            Coneciones.Add(new conexionMsSql("The_Badm_Davila", "Badm", "1234", "postgres"));
            Coneciones.Add(new conexionSqlPosgret("localhost", "postgres", "innovative", "test"));

            Coneciones[0].open();

            DataTable resultado1 = Coneciones[0].obtener_datos("SELECT * FROM Cajas");

            foreach (DataRow x in resultado1.Rows)
            {
                Console.WriteLine("ID = {0} ID Bodega = {1} Nombre Bodega = {2}", x.ItemArray[0], x.ItemArray[1], x.ItemArray[2]);
            }



            Coneciones[1].open();

            DataTable resultado2 = Coneciones[1].obtener_datos("SELECT * from persona");


            foreach (DataRow x in resultado2.Rows)
            {
                Console.WriteLine("ID = {0} ID nombre = {1} ", x.ItemArray[0], x.ItemArray[1]);
            }



            Console.ReadKey();
 
        }
        
    }
}







