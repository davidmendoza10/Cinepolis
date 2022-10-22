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
    public class DataGenero
    {
        public DataTable GetGenero()
        {
            string connString = ConfigurationManager.ConnectionStrings["cinepolisConnection"].ConnectionString;
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand("select gene_id,gne_inombre from cata_genero", con);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(dt);


            }
            return dt;
        }




        public DataTable GetGenero(int idGenero)
        {
            string connString = ConfigurationManager.ConnectionStrings["CinepolisConnection"].ConnectionString;

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand($"select gene_id,gene_nombre from cata_genero where gene_id = {idGenero}", con);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

                da.Fill(dt);
            }

            return dt;
        }

        public int UpdateGenero(int idGen, string nombreGen) //Firma del método, se está mapeando a una tabla
        {
            string connString = ConfigurationManager.ConnectionStrings["CinepolisConnection"].ConnectionString; //Leer del web.config la cadena de conexión 

            using (SqlConnection con = new SqlConnection(connString)) // Bloque de código para liberar recursos después de ejecutarse
            {
                SqlCommand sqlCommand = new SqlCommand($"update cata_genero set gene_nombre={nombreGen} where gene_id {idGen}", con);
                con.Open(); //Abrir la conexión (necesario para ejecutar la línea de abajo)
                var filasAfectadas = sqlCommand.ExecuteNonQuery();
                return filasAfectadas;
            }
        }


        public int DeleteGenero(int idGen)
        {
            string connString = ConfigurationManager.ConnectionStrings["CinepolisConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM pelicula WHERE ani_id = {idGen}", con);

                con.Open();
                var filasAfectadas = sqlCommand.ExecuteNonQuery();

                return filasAfectadas;
            }
        }

        public int InsertGenero(string nombreGenero)
        {
            var connString = ConfigurationManager.ConnectionStrings["CinepolisConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand($"insert into cata_genero (gene_nombre)  values ('{nombreGenero}') ", con);

                con.Open();
                var filasAfectadas = sqlCommand.ExecuteNonQuery();

                return filasAfectadas;
            }

        }


    }
}
