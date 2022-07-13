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
        CategoriaBL _categoriasBL;
        public EquiposController()
        {
            _equiposBL = new EquiposBL();
            _categoriasBL = new CategoriaBL();
        }
        // GET: Equipos
        public ActionResult Index()
        {
            var listadeEquipos = _equiposBL.ObtenerEquipos();
            return View(listadeEquipos);
        }

        public ActionResult Crear()
        {
            var nuevoEquipo = new Equipo();
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.ListaCategoria = new SelectList(categorias, "Id", "Descripcion");
            return View(nuevoEquipo);
        }

        [HttpPost]  

        public ActionResult Crear(Equipo equipo) {
            _equiposBL.GuardarEquipo(equipo);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var equipo = _equiposBL.ObtenerEquipo(id);
            var categorias = _categoriasBL.ObtenerCategorias();
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", equipo.CategoriaId);
            return View(equipo);
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