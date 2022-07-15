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

        public ActionResult Crear(Equipo equipo, HttpPostedFileBase imagen) {

            if (ModelState.IsValid)
            {
                if (equipo.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una Categoria");
                    return View(equipo);
                }

                if (imagen != null)
                {
                    equipo.UrlImagen = GuardarImagen(imagen);
                }
               
                _equiposBL.GuardarEquipo(equipo);
                return RedirectToAction("Index");
            }
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.ListaCategoria = new SelectList(categorias, "Id", "Descripcion");
            return View(equipo);
        }

        public ActionResult Editar(int id)
        {
            var equipo = _equiposBL.ObtenerEquipo(id);
            var categorias = _categoriasBL.ObtenerCategorias();
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", equipo.CategoriaId);
            return View(equipo);
        }

        [HttpPost]
        public ActionResult Editar(Equipo equipo, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (equipo.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una Categoria");
                    return View(equipo);
                }
                if (imagen != null)
                {
                    equipo.UrlImagen = GuardarImagen(imagen);
                }
                _equiposBL.GuardarEquipo(equipo);
                return RedirectToAction("Index");
            }
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.ListaCategoria = new SelectList(categorias, "Id", "Descripcion");
            return View(equipo);
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

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);
            return "/Imagenes/" + imagen.FileName;
        }

    }
}