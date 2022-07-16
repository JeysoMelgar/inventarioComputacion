using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioComputo.BL
{
    public class Usuarios
    {
        public int Id { get; set; }
        [Display(Name = "Usuario Responsable")]
        [Required(ErrorMessage = "Ingrese el Responsable")]
        [MinLength(5, ErrorMessage = "Ingrese minimo 5 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese un maximo de 20 caracteres")]
        public string Responsable { get; set; }

        [Required(ErrorMessage = "Ingrese el Departamento")]
        [MinLength(6, ErrorMessage = "Ingrese minimo 6 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese un maximo de 20 caracteres")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "Ingrese la EquipoId")]
        [Range(1, 999, ErrorMessage = "Ingrese una EquipoId entre 1 y 999")]
        public int EquipoId { get; set; }

        public Equipo Equipo { get; set; }

        [Required(ErrorMessage = "Ingrese El tiempo de uso")]
        [MinLength(6, ErrorMessage = "Ingrese minimo 6 caracteres")]
        [MaxLength(12, ErrorMessage = "Ingrese un maximo de 20 caracteres")]
        public string TiempodeUso { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Asignacion")]
        public DateTime FechaAsignacion { get; set; }

        public bool Activo { get; set; }
    }
}
