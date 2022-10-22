using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCinepolis
{
    public class DataClasificacion
    {
        public DataTable GetClasificacion()
        {
            string connString = ConfigurationManager.ConnectionStrings["cinepolisConnection"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand("select clasi_id, clasi_nombre from cata_clasificacion", con);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(dt);


            }
            return dt;
        }




        public DataTable GetClasificacion(int idClasific)
        {
            string connString = ConfigurationManager.ConnectionStrings["CinepolisConnection"].ConnectionString;

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand($"select clasi_id, clasi_nombre from cata_clasificacion where clasi_id = {idClasific}", con);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

                da.Fill(dt);
            }

            return dt;
        }

        public int UpdateClasificacion(int idClasific, string nombreClasific) //Firma del método, se está mapeando a una tabla
        {
            string connString = ConfigurationManager.ConnectionStrings["CinepolisConnection"].ConnectionString; //Leer del web.config la cadena de conexión 

            using (SqlConnection con = new SqlConnection(connString)) // Bloque de código para liberar recursos después de ejecutarse
            {
                SqlCommand sqlCommand = new SqlCommand($"update cata_clasificacion set clasi_nombre='{nombreClasific}' where clasi_id = {idClasific}", con);
                con.Open(); //Abrir la conexión (necesario para ejecutar la línea de abajo)
                var filasAfectadas = sqlCommand.ExecuteNonQuery();
                return filasAfectadas;
            }
        }


        public int DeleteClasificacion(int idClasif)
        {
            string connString = ConfigurationManager.ConnectionStrings["CinepolisConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand($"	DELETE FROM cata_clasificacion WHERE clasi_id = {idClasif}", con);

                con.Open();
                var filasAfectadas = sqlCommand.ExecuteNonQuery();

                return filasAfectadas;
            }
        }

        public int InsertClasificacion(string nombreClasif)
        {
            var connString = ConfigurationManager.ConnectionStrings["CinepolisConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand($"insert into cata_clasificacion (clasi_nombre)  values ('{nombreClasif}') ", con);

                con.Open();
                var filasAfectadas = sqlCommand.ExecuteNonQuery();

                return filasAfectadas;
            }

        }

    }
}
