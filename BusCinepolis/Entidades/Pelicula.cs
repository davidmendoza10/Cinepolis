using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusCinepolis.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int GeneroId { get; set; }
        public int ClasificacionId { get; set; }
        public int Anio { get; set; }
        public string Productor {get; set; }
        public string Sinopsis{ get; set; }
        public string PosterUrl { get; set; }
        public string MiniUrl {get; set; }  
        public double Rating { get; set; }
        public string VideoUrl { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Status { get; set; }


    }
}
