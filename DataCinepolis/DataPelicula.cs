using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.NetworkInformation;

namespace DataCinepolis
{
    public class DataPelicula
    {
        public DataTable GetPeliculas()
        {
            string connString = ConfigurationManager.ConnectionStrings["cinepolisConnection"].ConnectionString;
            //estamos instanciando la clase datatable
            DataTable dt = new DataTable();
            //envolviendo una instancia de la clase
            using (SqlConnection con = new SqlConnection(connString))
            {    //instanciando la clase sql comand de tipo sqlcomand
                SqlCommand sqlCommand = new SqlCommand("select peli_id,peli_nombre,peli_genero_id,peli_genero_id,peli_clasificacion_id,peli_anio,peli_productor,peli_sinopsis,peli_poster_url,peli_mini_url,peli_rating,peli_video,peli_fecha_creacion_,peli_status from pelicula", con); //cadena de conexion //con= sobre carga de sqlconnection

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand); //
                da.Fill(dt);


            }
            return dt;
        }




        public DataTable GetPelicula(int idPelicula)
        {
            string connString = ConfigurationManager.ConnectionStrings["PeliculaConnection"].ConnectionString;

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand($"select peli_id,peli_nombre,peli_genero_id,peli_genero_id,peli_clasificacion_id,peli_anio,peli_productor,peli_sinopsis,peli_poster_url,peli_mini_url,peli_rating,peli_video,peli_fecha_creacion_,peli_status from pelicula where peli_id{idPelicula}", con);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

                da.Fill(dt);
            }

            return dt;
        }

        public int UpdatePelicula(int id, string nombre, int genero, int clasificacion, int anio, string productor, string sinopsis, string poster, string mini, double rating, string video, DateTime fecha_creacion, bool status) //Firma del método, se está mapeando a una tabla
        {
            string connString = ConfigurationManager.ConnectionStrings["peliculaConnection"].ConnectionString; //Leer del web.config la cadena de conexión 

            using (SqlConnection con = new SqlConnection(connString)) // Bloque de código para liberar recursos después de ejecutarse
            {
                SqlCommand sqlCommand = new SqlCommand($"update pelicula set peli_id {id},peli_nombre{nombre},peli_genero_id{genero},peli_clasificacion_id{clasificacion},peli_anio{anio}peli_productor{productor},peli_sinopsis{sinopsis},peli_poster_url{poster},peli_mini_url{mini},peli_rating{rating},peli_video{video} peli_fecha_creacion='{fecha_creacion.ToString("dd/MM/yyyy HH:mm:ss")},peli_status{status}", con);
                con.Open(); //Abrir la conexión (necesario para ejecutar la línea de abajo)
                var filasAfectadas = sqlCommand.ExecuteNonQuery();
                return filasAfectadas;
            }
        }


        public int DeletePelicula(int idPelicula)
        {
            string connString = ConfigurationManager.ConnectionStrings["peliculaConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM pelicula WHERE ani_id = {idPelicula}", con);

                con.Open();
                var filasAfectadas = sqlCommand.ExecuteNonQuery();

                return filasAfectadas;
            }
        }

        public int InsertPelicula(string nombre, int genero, int clasificacionId, int anio, string productor, string sinopsis, string poster, string mini, double rating, string video, bool status)
        {
            string connString = ConfigurationManager.ConnectionStrings["peliculaConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand sqlCommand = new SqlCommand($"insert into pelicula(peli_nombre,peli_genero_id,peli_clasificacion_id,peli_anio,peli_productor,peli_sinopsis,peli_poster_url,peli_mini_url,peli_rating,peli_video_url,peli_fecha_creacion,peli_status) values 8{nombre},{genero},{clasificacionId},{anio},{productor},{poster},{mini},{rating},{video},GETDATE(),'true')", con);

                con.Open();
                var filasAfectadas = sqlCommand.ExecuteNonQuery();

                return filasAfectadas;
            }
        }

    }
}

