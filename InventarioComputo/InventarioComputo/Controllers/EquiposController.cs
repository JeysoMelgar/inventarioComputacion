using InventarioComputo.BL;
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
            var equiposBL = new EquiposBL();
            var listadeEquipos = equiposBL.ObtenerEquipos();
            //Llamamaremos la funcion de lista de los objetos
            return View(listadeEquipos);
        }
    }
}