using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioComputo.BL
{
    public class Equipo
    {
        public Equipo() {
            Activo = true;
        }
        /*Validacion de requerimientos y campos publicos de la clase Equipo*/
        public int Id { get; set; }
        [Required(ErrorMessage ="Ingrese la Descripcion")]
        [MinLength(5,ErrorMessage = "Ingrese minimo 5 caracteres")]
        [MaxLength(20,ErrorMessage = "Ingrese un maximo de 20 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese el Precio")]
        [Range(0,50000,ErrorMessage = "Ingrese un precio entre 0 y 50000")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "Ingrese la CategoriaId")]
        [Range(1, 1000, ErrorMessage = "Ingrese una CategoriaId entre 1 y 1000")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Ingrese la Marca")]
        [MinLength(2, ErrorMessage = "Ingrese minimo 2 caracteres")]
        [MaxLength(12, ErrorMessage = "Ingrese un maximo de 12 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Ingrese el Modelo")]
        [MinLength(3, ErrorMessage = "Ingrese minimo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese un maximo de 20 caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Ingrese la Serie")]
        [MinLength(7, ErrorMessage = "Ingrese minimo 7 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese un maximo de 20 caracteres")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "Ingrese el Estado")]
        [MinLength(5, ErrorMessage = "Ingrese minimo 5 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese un maximo de 20 caracteres")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha")]
        [MinLength(8, ErrorMessage = "Ingrese minimo 10 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese un maximo de 20 caracteres")]
        public string Fecha { get; set; }

        public bool Activo { get; set; }



    }
}
