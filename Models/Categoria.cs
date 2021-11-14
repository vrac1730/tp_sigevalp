using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIGEVALP.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Categoría")]
        [Required]
        [RegularExpression("^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "* Solo se permiten letras.")]
        public string nombre { get; set; }

        [DisplayName("Descripción")]
        [Required]
        [StringLength(55, ErrorMessage = "Descripción no debe superar los 55 caracteres.")]
        public string descripcion { get; set; }
    }
}