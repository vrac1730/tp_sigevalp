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
        [DisplayName("Parcial")]
        public double parcial { get; set; }
        [DisplayName("Descuento")]
        public double descuento { get; set; }

        [DisplayName("Neto")]
        public double neto { get; set; }

        [DisplayName("IGV")]
        public double iva { get; set; }

        [DisplayName("Total")]
        public double total { get; set; }

        [DisplayName("Fecha")]
        [Column(TypeName = "datetime2")]
        public DateTime fecha { get; set; }

        [DisplayName("Cliente")]
        public int idUsuario { get; set; }

        [DisplayName("Proveedor")]
        public int idProveedor { get; set; }

        [ForeignKey("idUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("idProveedor")]
        public Proveedor Proveedor { get; set; }

        public List<DetalleCotizacion> DetalleCotizacion { get; set; }
    }
}