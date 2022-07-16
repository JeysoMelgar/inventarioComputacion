using InventarioComputo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventarioComputo.WebAdmin.Controllers
{
    public class UsuariosController : Controller
    {
        UsuariosBL _usuariosBL;
        EquiposBL _equiposBL;
        public UsuariosController()
        {
            _usuariosBL = new UsuariosBL();
            _equiposBL = new EquiposBL();
        }
        // GET: Usuarios
        public ActionResult Index()
        {
            var listadeUsuarios = _usuariosBL.ObtenerUsuarios();
            return View(listadeUsuarios);
        }

        public ActionResult Crear()
        {
            var nuevoUsuario = new Usuarios();
            var equipo = _equiposBL.ObtenerEquipos();

            ViewBag.EquipoId = new SelectList(equipo, "Id", "Modelo", "Marca");
            return View(nuevoUsuario);
        }

        [HttpPost]

        public ActionResult Crear(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.EquipoId == 0)
                {
                    ModelState.AddModelError("EquipoId", "Seleccione un equipo");
                    return View(usuario);
                }
                _usuariosBL.GuardarUsuarios(usuario);
                return RedirectToAction("Index");
            }
            var equipo = _equiposBL.ObtenerEquipos();

            ViewBag.EquipoId = new SelectList(equipo, "Id", "Modelo", "Marca");
            return View(usuario);
        }

        public ActionResult Editar(int id)
        {
            var usuario = _usuariosBL.ObtenerUsuarios(id);
            var equipo = _equiposBL.ObtenerEquipos();
            ViewBag.EquipoId = new SelectList(equipo, "Id", "Modelo", "Marca", usuario.EquipoId);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.EquipoId == 0)
                {
                    ModelState.AddModelError("EquipoId", "Seleccione un Equipo");
                    return View(usuario);
                }
                _usuariosBL.GuardarUsuarios(usuario);
                return RedirectToAction("Index");
            }
            var equipos = _equiposBL.ObtenerEquipos();
            ViewBag.EquipoId = new SelectList(equipos, "Id", "Descripcion");
            return View(usuario);
        }

        public ActionResult Detalle(int id)
        {
            var usuario = _usuariosBL.ObtenerUsuarios(id);
            return View(usuario);
        }

        public ActionResult Eliminar(int id)
        {
            var usuario = _usuariosBL.ObtenerUsuarios(id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Eliminar(Usuarios usuario)
        {
            _usuariosBL.EliminarUsuarios(usuario.Id);
            return RedirectToAction("Index");
        }
    }
}