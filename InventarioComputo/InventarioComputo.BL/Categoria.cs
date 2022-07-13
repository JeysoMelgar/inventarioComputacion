using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioComputo.BL
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo vacio, por favor ingrese la categoria nuevamente.")]
        public string  Descripcion { get; set; }
    }
}
