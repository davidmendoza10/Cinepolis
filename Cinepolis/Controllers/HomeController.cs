using BusCinepolis;
using BusCinepolis.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Invocación del bus 
namespace Cinepolis.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() //Metodo que regresa un ActionResult
        {
            var objtBusPelicula = new BusPelicula();//creacion de objeto de tipo Buspelicula o Instanciando la clase BusPleicula
            var listaPeliculas = objtBusPelicula.GetPeliculas();//regresa una lista de pekiculas
            var objPelicula = objtBusPelicula.GetPeliculas(3);// invicando el metod

            var objBusPelicula = objtBusPelicula.GetPeliculas(1);
            objPelicula.Nombre = "Avengers2";
            var fueActualizado = objtBusPelicula.UpdatePelicula(objPelicula);
            var fueEliminado = objtBusPelicula.DeletePelicula(1);
            var pelicula2 = new Pelicula() { Nombre = "Iron Man", GeneroId = 1, ClasificacionId = 1, Anio = 2008, Productor = " Avi Arad", Sinopsis = "Tony Stark es un inventor de armamento brillante que es secuestrado en el extranjero. Sus captores son unos terroristas que le obligan a construir una máquina destructiva pero Tony se construirá una armadura para poder enfrentarse a ellos y escapa", PosterUrl = "https://images.app.goo.gl/MfdWUZ1WRJEJxNDC8", MiniUrl = "https://images.app.goo.gl/99QXRu1ohwgPEyTt8s", Rating = 4.5, VideoUrl = "https://www.youtube.com/watch?v=fapWnPIbNeg", Status = true };
            var fueInsertado = objtBusPelicula.InsertPelicula(pelicula2);//pasamos el objeto de tipo pelicula "pelicual2"

            var objBusGen = new BusGenero();
            var listGen = objBusGen.GetGenero();
            var objGenero = objBusGen.GetGenero(3);
            objGenero.Nombre = "Terror";
            var genActualizado = objBusGen.UpdateGenero(objGenero);
            var genEliminado = objBusGen.DeleteGenero(3);
            var genero = new Genero() { Nombre = "Amor" };
            var genInsertado = objBusGen.InsertGenero(genero);

            var objBusClasif = new BusClasificacion();
            var listClasif = objBusClasif.GetClasificacion();
            var objClasificacion = objBusClasif.GetClasificacion(3);
            objClasificacion.Nombre = "C";
            var clasifActualizado = objBusClasif.UpdateClasificaciones(objClasificacion);
            var clasifEliminado = objBusClasif.DeleteClasificaciones(3);
            var clasificacion = new Clasificacion() { Nombre = "VIP" };
            var clasifInsertado = objBusClasif.InsertClasificaciones(clasificacion);

           
            return View(); //retorna la vista renderizada 
        }
    }
}
