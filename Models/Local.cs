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
        [StringLength(45, ErrorMessage = "Local no debe superar los 45 caracteres.")]
        public string nombre { get; set; }

        [Required]
        [DisplayName("Dirección")]
        [StringLength(55, ErrorMessage = "Dirección no debe superar los 55 caracteres.")]
        public string direccion { get; set; }

        [DisplayName("Teléfono")]
        [Range(100000000, 999999999, ErrorMessage = "Campo valido de 9 digitos")]
        public long telefono { get; set; }

        [DisplayName("RUC")]        
        [Range(10000000000, 99999999999, ErrorMessage = "Campo valido de 11 digitos")]      
        public long ruc { get; set; }

        [DisplayName("Razon Social")]
        [Required]
        [StringLength(45, ErrorMessage = "Razon Social no debe superar los 45 caracteres.")]
        public string razon_social { get; set; }
    }
}