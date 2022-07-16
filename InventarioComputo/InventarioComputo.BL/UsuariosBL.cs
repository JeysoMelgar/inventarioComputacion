using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioComputo.BL
{
    public class UsuariosBL
    {
        //Creamos un constructor 
        Contexto _contexto;
        public List<Usuarios> ListadeUsuarios { get; set; }
        public UsuariosBL()
        {
            _contexto = new Contexto();
            ListadeUsuarios = new List<Usuarios>();
        }
        public List<Usuarios> ObtenerUsuarios()
        {
            ListadeUsuarios = _contexto.Usuarios
            .Include("Equipo")
            .ToList();
            return ListadeUsuarios;
        }

        public void GuardarUsuarios(Usuarios usuario)
        {
            if (usuario.Id == 0)
            {
                _contexto.Usuarios.Add(usuario);
            }
            else
            {
                var usuarioExistente = _contexto.Usuarios.Find(usuario.Id);
                usuarioExistente.Responsable = usuario.Responsable;
                usuarioExistente.Departamento = usuario.Departamento;
                usuarioExistente.EquipoId = usuario.EquipoId;
                usuarioExistente.Equipo = usuario.Equipo;
                usuarioExistente.TiempodeUso = usuario.TiempodeUso;
                usuarioExistente.FechaAsignacion = usuario.FechaAsignacion;
                usuarioExistente.Activo = usuario.Activo;
            }

            _contexto.SaveChanges();
        }

        public Usuarios ObtenerUsuarios(int id)
        {
            var Usuarios = _contexto.Usuarios.Include("Equipo").FirstOrDefault(o => o.Id == id);
            return Usuarios;
        }

        public void EliminarUsuarios(int id)
        {
            var Usuarios = _contexto.Usuarios.Find(id);
            _contexto.Usuarios.Remove(Usuarios);
            _contexto.SaveChanges();
        }
    }
}
