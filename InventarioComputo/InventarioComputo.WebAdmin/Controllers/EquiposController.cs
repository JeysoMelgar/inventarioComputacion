using InventarioComputo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventarioComputo.WebAdmin.Controllers
{
    public class EquiposController : Controller
    {
        EquiposBL _equiposBL;
        public EquiposController()
        {
            _equiposBL = new EquiposBL();
        }
        // GET: Equipos
        public ActionResult Index()
        {
            var listadeProductos = _equiposBL.ObtenerEquipos();
            return View(listadeProductos);
        }

        public ActionResult Crear(){
            var nuevoEquipo = new Equipo();
            return View(nuevoEquipo);
        }

        [HttpPost]

        public ActionResult Crear(Equipo equipo) {
            _equiposBL.GuardarEquipo(equipo);
            return RedirectToAction("Index");
        }
    }
}