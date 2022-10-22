using BusCinepolis.Entidades;
using DataCinepolis;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusCinepolis
{
    public class BusGenero
    {
        public List<Genero> GetGenero()
        {
            DataGenero objtData = new DataGenero();
            DataTable dt = objtData.GetGenero();

            List<Genero> generos = new List<Genero>();

            foreach (DataRow dr in dt.Rows)
            {
                Genero genero = new Genero();
                genero.Id = Convert.ToInt32(dr["gene_id"]);
                genero.Nombre = dr["gene_nombre"] is DBNull ? "" : dr["peli_nombre"].ToString();
                
                generos.Add(genero);


            }
            return generos;
        }

        public Genero GetGenero(int idGenero)

        {
            DataGenero objData = new DataGenero();
            DataTable dt = objData.GetGenero(idGenero);
            Genero generos = new Genero();

            if (dt.Rows.Count > 0)
            {
                generos.Id = Convert.ToInt32(dt.Rows[0]["gene_id"]);
                generos.Nombre = dt.Rows[0]["gene_nombre"].ToString();
                
            }
            return generos;
        }

        public bool UpdateGenero(Genero genero)
        {
            DataGenero objData = new DataGenero();
            var filas = objData.UpdateGenero(genero.Id, genero.Nombre);

            return filas == 1;
        }
        public bool DeleteGenero(int idGenero)
        {
            DataGenero objData = new DataGenero();
            int filas = objData.DeleteGenero(idGenero);

            return filas == 1;

        }

        public bool InsertGenero(Genero genero)
        {
            DataGenero objData = new DataGenero();
            int filas = objData.InsertGenero(genero.Nombre);

            return filas == 1;

        }
    }
}
