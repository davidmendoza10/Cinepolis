using BusCinepolis.Entidades;
using DataCinepolis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusCinepolis
{
    public class BusPelicula
    {
        public List<Pelicula> GetPeliculas() // estoy creando un metodo publico llamado GetPeliculas que retorna una lista peliculas con una firma vacia¨; y que en su firma recibe los parametros de tipo ... entero , string etc.....
        {
            DataPelicula objtData = new DataPelicula(); //
            DataTable dt = objtData.GetPeliculas();// estoy declarando un objeto de tipo Datatable (dato cmpleto)

            List<Pelicula> peliculas = new List<Pelicula>();

            foreach (DataRow dr in dt.Rows) //iterando las filas de datatable, cada una de las filas es de tipo DataRow
            {
                Pelicula pelicula = new Pelicula(); 
                pelicula.Id = Convert.ToInt32(dr["peli_id"]);
                pelicula.Nombre = dr["peli_nombre"] is DBNull ? "" : dr["peli_nombre"].ToString();
                pelicula.GeneroId = Convert.ToInt32(dt.Rows[0]["peli_genero_id"]);
                pelicula.ClasificacionId = Convert.ToInt32(dr["peli_clasificacion_id"]);
                pelicula.Anio = Convert.ToInt32(dr["peli_anio"]);
                pelicula.Productor = dr["peli_productor"] is DBNull ? "" : dr["peli_productor"].ToString();
                pelicula.Sinopsis = dr["peli_sinopsis"] is DBNull ? "" : dr["peli_sinopsis"].ToString();
                pelicula.PosterUrl = dr["peli_poster_url"] is DBNull ? "" : dr["peli_poster_url"].ToString();
                pelicula.MiniUrl = dr["peli_mini_url"] is DBNull ? "" : dr["peli_mini_url"].ToString();
                pelicula.Rating = Convert.ToDouble(dr["peli_rating"]);
                pelicula.VideoUrl = dr["peli_video_url"] is DBNull ? "" : dr["peli_video_url"].ToString();
                pelicula.FechaCreacion = Convert.ToDateTime(dr["peli_fecha_creacion"]);
                pelicula.Status = Convert.ToBoolean(dr["peli_status"]);

                //agregar pelicula a la lista
                peliculas.Add(pelicula);






            }
            return peliculas;
        }

        public Pelicula GetPeliculas(int idPelicula)

        {
            DataPelicula objData = new DataPelicula();
            DataTable dt = objData.GetPelicula(idPelicula);
            Pelicula pelicula = new Pelicula();

            if (dt.Rows.Count > 0)
            {
                pelicula.Id = Convert.ToInt32(dt.Rows[0]["peli_id"]);
                pelicula.Nombre = dt.Rows[0]["peli_nombre"].ToString();
                pelicula.GeneroId = Convert.ToInt32(dt.Rows[0]["peli_genero_id"]);
                pelicula.ClasificacionId = Convert.ToInt32(dt.Rows[0]["peli_clasificacion_id"]);
                pelicula.Anio = Convert.ToInt32(dt.Rows[0]["peli_anio"]);
                pelicula.Productor = dt.Rows[0]["peli_productor"].ToString();
                pelicula.Sinopsis = dt.Rows[0]["peli_sinopsis"].ToString();
                pelicula.PosterUrl = dt.Rows[0]["peli_poster_url"].ToString();
                pelicula.MiniUrl = dt.Rows[0]["peli_mini_url"].ToString();
                pelicula.Rating = Convert.ToDouble(dt.Rows[0]["peli_rating"]);
                pelicula.VideoUrl = dt.Rows[0]["peli_video_url"].ToString();
                pelicula.FechaCreacion = Convert.ToDateTime(dt.Rows[0]["peli_fecha_creacion"]);
                pelicula.Status = Convert.ToBoolean(dt.Rows[0]["peli_estatus"]);


            }
            return pelicula;
        }

        public bool UpdatePelicula(Pelicula pelicula)
        {
            DataPelicula objData = new DataPelicula();
            var filas = objData.UpdatePelicula(pelicula.Id, pelicula.Nombre, pelicula.GeneroId, pelicula.ClasificacionId, pelicula.Anio, pelicula.Productor, pelicula.Sinopsis, pelicula.PosterUrl, pelicula.MiniUrl, pelicula.Rating, pelicula.VideoUrl, pelicula.FechaCreacion, pelicula.Status);

            return filas == 1;//  return filas == 1 ? true : false; esto esta novato
        }
        public bool DeletePelicula(int idPelicula)
        {
            DataPelicula objData = new DataPelicula();
            int filas = objData.DeletePelicula(idPelicula);

            return filas == 1;

        }

        public bool InsertPelicula(Pelicula pelicula)
        {
            DataPelicula objData = new DataPelicula();
            int filas = objData.InsertPelicula(pelicula.Nombre, pelicula.GeneroId, pelicula.ClasificacionId, pelicula.Anio, pelicula.Productor, pelicula.Sinopsis, pelicula.PosterUrl, pelicula.MiniUrl, pelicula.Rating, pelicula.VideoUrl,pelicula.Status);

            return filas == 1;

        }
    }
}
