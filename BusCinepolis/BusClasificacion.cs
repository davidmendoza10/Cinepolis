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
    public class BusClasificacion
    {
        public List<Clasificacion> GetClasificacion()
        {
            DataClasificacion objtData = new DataClasificacion();
            DataTable dt = objtData.GetClasificacion();

            List<Clasificacion> clasificaciones = new List<Clasificacion>();

            foreach (DataRow dr in dt.Rows)
            {
                Clasificacion clasificacion = new Clasificacion();
                clasificacion.ClasificacionId = Convert.ToInt32(dr["clasi_id"]);
                clasificacion.Nombre = dr["clasi_nombre"] is DBNull ? "" : dr["clasi_nombre"].ToString();

                clasificaciones.Add(clasificacion);


            }
            return clasificaciones;
        }

        public Clasificacion GetClasificacion(int idClasif)

        {
            DataClasificacion objData = new DataClasificacion();
            DataTable dt = objData.GetClasificacion(idClasif);
            Clasificacion clasificaciones = new Clasificacion();

            if (dt.Rows.Count > 0)
            {
                clasificaciones.ClasificacionId = Convert.ToInt32(dt.Rows[0]["gene_id"]);
                clasificaciones.Nombre = dt.Rows[0]["gene_nombre"].ToString();

            }
            return clasificaciones;
        }

        public bool UpdateClasificaciones(Clasificacion clasificacion)
        {
            DataClasificacion objData = new DataClasificacion();
            var filas = objData.UpdateClasificacion(clasificacion.ClasificacionId, clasificacion.Nombre);

            return filas == 1;
        }
        public bool DeleteClasificaciones(int idClasificaciones)
        {
            DataClasificacion objData = new DataClasificacion();
            int filas = objData.DeleteClasificacion(idClasificaciones);

            return filas == 1;

        }

        public bool InsertClasificaciones(Clasificacion clasificacion)
        {
            DataClasificacion objData = new DataClasificacion();
            int filas = objData.InsertClasificacion(clasificacion.Nombre);

            return filas == 1;

        }
    }
}

