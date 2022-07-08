using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioComputo.BL
{
    public class EquiposBL
    {
        public List<Equipo> ObtenerEquipos()
        {
            // Creamos el objeto 
            var equipo1 = new Equipo();
            equipo1.Id = 0001;
            equipo1.Descripcion = "Equipos de computo";
            equipo1.Precio = 14000;
            equipo1.Categoria = "Computadora de Escritorio";
            equipo1.Marca ="DELL";
            equipo1.Modelo = "Optiplex";
            equipo1.Serie = "9Z82RF2";
            equipo1.Estado = "Nuevo";
            equipo1.Fecha = "24/06/2022";

            //Creamos varios objetos
            var equipo2 = new Equipo();
            equipo2.Id = 0002;
            equipo2.Descripcion = "Equipos de Impresion";
            equipo2.Precio = 16000;
            equipo2.Categoria = "Impresora";
            equipo2.Marca = "Kyocera";
            equipo2.Modelo = "Ecosys M2540dn";
            equipo2.Serie = "12ZYT0019M";
            equipo2.Estado = "Usado";
            equipo2.Fecha = "15/03/2022";

            var equipo3 = new Equipo();
            equipo3.Id = 0003;
            equipo3.Descripcion = "Equipos Perifericos";
            equipo3.Precio = 1000;
            equipo3.Categoria = "Teclados";
            equipo3.Marca = "KlipExtreme";
            equipo3.Modelo = "M1902";
            equipo3.Serie = "19XUP20KL";
            equipo3.Estado = "Usados";
            equipo3.Fecha = "07/04/2022";

            // Creamos una lista de los Objetos
            var listadeEquipos = new List<Equipo>();
            listadeEquipos.Add(equipo1);
            listadeEquipos.Add(equipo2);
            listadeEquipos.Add(equipo3);

            return listadeEquipos;
        }
    }
}
