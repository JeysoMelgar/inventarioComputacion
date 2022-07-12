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

        public ActionResult Crear(Categoria categoria)
        {
            _categoriasBL.GuardarCategoria(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var producto = _categoriasBL.ObtenerCategoria(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            _categoriasBL.GuardarCategoria(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);
            return View(categoria);
        }

        public ActionResult Eliminar(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Eliminar(Categoria categoria)
        {
            _categoriasBL.EliminarCategoria(categoria.Id);
            return RedirectToAction("Index");
        }
    }
}