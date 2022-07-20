using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioComputo.BL
{
    public class EquiposBL
    {
        Contexto _contexto;
        //Creamos un constructor
        public List<Equipo> ListadeEquipos { get; set; }
        public EquiposBL()
        {
            _contexto = new Contexto();
            ListadeEquipos = new List<Equipo>();
        }
        public List<Equipo> ObtenerEquipos()
        {   
            //Generamos una consulta en la base de datos con include haciendo un inner join
            ListadeEquipos = _contexto.Equipos
                .Include("Categoria")
                .OrderBy(r => r.Categoria.Descripcion)
                .ThenBy(r => r.Descripcion)
                .ToList();
            return ListadeEquipos;
        }

        public List<Equipo> ObtenerEquiposActivos()
        {
            //Generamos una consulta en la base de datos con include haciendo un inner join
            //Utilizando ademas el filtrado para todos los equipos
            ListadeEquipos = _contexto.Equipos
                .Include("Categoria")
                .Where(r => r.Activo == true)
                .OrderBy(r => r.Descripcion)
                .ToList();
            return ListadeEquipos;
        }

        public void GuardarEquipo(Equipo equipo)
        {
            if (equipo.Id == 0)
            {
                _contexto.Equipos.Add(equipo);
            }
            else
            {
                var equipoExistente = _contexto.Equipos.Find(equipo.Id);
                equipoExistente.Descripcion = equipo.Descripcion;
                equipoExistente.Precio = equipo.Precio;
                equipoExistente.CategoriaId = equipo.CategoriaId;
                equipoExistente.Categoria = equipo.Categoria;
                equipoExistente.Marca = equipo.Marca;
                equipoExistente.Modelo = equipo.Modelo;
                equipoExistente.Serie = equipo.Serie;
                equipoExistente.Estado = equipo.Estado;
                equipoExistente.Fecha = equipo.Fecha;
                equipoExistente.UrlImagen = equipo.UrlImagen;
                equipoExistente.Activo = equipo.Activo;
            }
            
            _contexto.SaveChanges();
        }
        //Relacion oor medio de LinQ
        public Equipo ObtenerEquipo(int id)
        {
            var equipo = _contexto.Equipos.Include("Categoria").FirstOrDefault(p => p.Id == id);
            return equipo;
        }

        public void EliminarEquipo(int id)
        {
            var equipo = _contexto.Equipos.Find(id);
            _contexto.Equipos.Remove(equipo);
            _contexto.SaveChanges();
        }
    }
}
