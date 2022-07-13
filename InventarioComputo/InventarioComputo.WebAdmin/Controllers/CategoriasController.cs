using InventarioComputo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventarioComputo.WebAdmin.Controllers
{
    public class CategoriasController : Controller
    {
        CategoriaBL _categoriasBL;
        public CategoriasController()
        {
            _categoriasBL = new CategoriaBL();
        }
        // GET: Categorias
        public ActionResult Index()
        {
            var listadeCategorias = _categoriasBL.ObtenerCategorias();
            return View(listadeCategorias);
        }

        public ActionResult Crear()
        {
            var nuevaCategoria = new Categoria();
            return View(nuevaCategoria);
        }

        [HttpPost]

        public ActionResult Crear(Categoria equipo)
        {
            _categoriasBL.GuardarCategoria(equipo);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var equipo = _categoriasBL.ObtenerCategoria(id);

            return View(equipo);
        }

        [HttpPost]
        public ActionResult Editar(Categoria equipo)
        {
            _categoriasBL.GuardarCategoria(equipo);
            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var equipo = _categoriasBL.ObtenerCategoria(id);
            return View(equipo);
        }

        public ActionResult Eliminar(int id)
        {
            var equipo = _categoriasBL.ObtenerCategoria(id);
            return View(equipo);
        }

        [HttpPost]
        public ActionResult Eliminar(Categoria equipo)
        {
            _categoriasBL.EliminarCategoria(equipo.Id);
            return RedirectToAction("Index");
        }
    }
}