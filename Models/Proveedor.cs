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

        [Required]
        [DisplayName("Dirección")]
        public string direccion { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Correo")]
        public string correo { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        [Range(000000000, 999999999, ErrorMessage = "Campo valido de 9 digitos")]
        [DisplayName("Teléfono")]
        public long telefono { get; set; }

        [Range(10000000000, 99999999999, ErrorMessage = "Campo valido de 11 digitos")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        [DisplayName("RUC")]
        public long ruc { get; set; }

        [Required]
        [DisplayName("Razón social")]
        [RegularExpression("^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "* Solo se permiten letras.")]
        public string razon_social { get; set; }

        public List<DetalleCotizacion> DetalleCotizacion { get; set; }
        public List<OrdenCompra> OrdenCompra { get; set; }
    }
}