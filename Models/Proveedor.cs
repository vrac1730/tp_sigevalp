using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIGEVALP.Models
{
    [Table("Proveedor")]
    public class Proveedor
    {
        [Key]
        public int id { get; set; }

        [DisplayName ("Proveedor")]
        [Required]
        [RegularExpression("^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "* Solo se permiten letras.")]
        public string nombre { get; set; }
        
        [DisplayName("Dirección")]
        [Required]
        [StringLength(55, ErrorMessage = "Dirección no debe superar los 55 caracteres.")]
        public string direccion { get; set; }

        [DisplayName("Correo")]
        [Required]
        [EmailAddress]        
        public string correo { get; set; }

        [DisplayName("Teléfono")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        [Range(100000000, 999999999, ErrorMessage = "Campo valido de 9 digitos")]        
        public long telefono { get; set; }

        [DisplayName("RUC")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        [Range(10000000000, 99999999999, ErrorMessage = "Campo valido de 11 digitos")]        
        public long ruc { get; set; }

        [DisplayName("Razón social")]
        [Required]
        [StringLength(55, ErrorMessage = "Razón social no debe superar los 55 caracteres.")]
        public string razon_social { get; set; }

        public List<DetalleCotizacion> DetalleCotizacion { get; set; }
        public List<OrdenCompra> OrdenCompra { get; set; }
    }
}