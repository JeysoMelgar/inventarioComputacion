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
            ListadeEquipos = _contexto.Equipos.ToList();
            return ListadeEquipos;
        }
    }
}
