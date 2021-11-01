using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIGEVALP.Models
{
    [Table("Cotizacion")]
    public class Cotizacion
    {
        [Key]
        public int id { get; set; }
        
        [DisplayName("Código")]
        public string codigo { get; set; }
        
        [DisplayName("Estado")]
        public string estado { get; set; }

        public double parcial { get; set; }

        public double descuento { get; set; }

        [DisplayName("Neto")]
        public double neto { get; set; }

        [DisplayName("IVA")]
        public double iva { get; set; }

        [DisplayName("Total")]
        public double total { get; set; }

        public int idUsuario { get; set; }
        public int idProveedor { get; set; }

        [Column(TypeName = "datetime2"), DisplayName("Fecha")]
        public DateTime fecha { get; set; }

        [ForeignKey("idUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("idProveedor")]
        public Proveedor Proveedor { get; set; }

        public List<DetalleCotizacion> DetalleCotizacion { get; set; }
    }
}