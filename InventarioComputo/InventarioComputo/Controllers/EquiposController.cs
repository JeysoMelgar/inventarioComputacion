using InventarioComputo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventarioComputo.Controllers
{
    public class EquiposController : Controller
    {
        // GET: Equipos
        public ActionResult Index()
        {   
            // Creamos el objeto 
            var equipo1 = new EquipoModel();
            equipo1.Id = 1;
            equipo1.Descripcion = "200 Equipos de computo";

            //Creamos varios objetos
            var equipo2 = new EquipoModel();
            equipo2.Id = 2;
            equipo2.Descripcion = "250 Equipos de computo";

            var equipo3 = new EquipoModel();
            equipo3.Id = 3;
            equipo3.Descripcion = "300 Equipos de computo";

            // Creamos una lista de los Objetos
            var listadeEquipos = new List<EquipoModel>();
            listadeEquipos.Add(equipo1);
            listadeEquipos.Add(equipo2);
            listadeEquipos.Add(equipo3);

            //Llamamaremos la funcion de lista de los objetos
            return View(listadeEquipos);
        }
    }
}