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
        public string codigo { get; set; }
        
        public DateTime fechaFin { get; set; }
        public string estado { get; set; }
        public double iva { get; set; }
        public double total { get; set; }
        public int idUsuario { get; set; }
        public int idProveedor { get; set; }

        [Column(TypeName = "datetime2"), DisplayName("Fecha de Cotizacion")]
        public DateTime fechaInicio { get; set; }

        [ForeignKey("idUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("idProveedor")]
        public Proveedor Proveedor { get; set; }

        public List<DetalleCotizacion> DetalleCotizacion { get; set; }
    }
}