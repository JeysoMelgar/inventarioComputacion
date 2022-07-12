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
            var listadeEquipos = _equiposBL.ObtenerEquipos();
            return View(listadeEquipos);
        }

        public ActionResult Crear() {
            var nuevoEquipo = new Equipo();
            return View(nuevoEquipo);
        }

        [HttpPost]

        public ActionResult Crear(Equipo equipo) {
            _equiposBL.GuardarEquipo(equipo);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var producto = _equiposBL.ObtenerEquipo(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Equipo equipo)
        {
            _equiposBL.GuardarEquipo(equipo);
            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var equipo = _equiposBL.ObtenerEquipo(id);
            return View(equipo);
        }

        public ActionResult Eliminar(int id)
        {
            var equipo = _equiposBL.ObtenerEquipo(id);
            return View(equipo);
        }

        [HttpPost]
        public ActionResult Eliminar(Equipo equipo)
        {
            _equiposBL.EliminarEquipo(equipo.Id);
            return RedirectToAction("Index");
        }
    }
}