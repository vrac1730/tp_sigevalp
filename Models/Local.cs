using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIGEVALP.Models
{
    [Table("Local")]
    public class Local
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Local")]
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "* Solo se permiten letras.")]
        public string nombre { get; set; }

        [Required]
        [DisplayName("Dirección")]
        [StringLength(30,ErrorMessage = "Dirección no debe superar los 30 caracteres.")]
        public string direccion { get; set; }

        [DisplayName("Teléfono")]
        [Range(100000000, 999999999, ErrorMessage = "Campo valido de 9 digitos")]
        public long telefono { get; set; }

        [DisplayName("RUC")]
        [Required]
        [Range(10000000000, 99999999999, ErrorMessage = "Campo valido de 11 digitos")]      
        public long ruc { get; set; }

        [DisplayName("Razon Social")]
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "* Solo se permiten letras.")]
        public string razon_social { get; set; }
    }
}