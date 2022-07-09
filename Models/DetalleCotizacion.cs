using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIGEVALP.Models
{
    [Table("DetalleCotizacion")]
    public class DetalleCotizacion
    {
        public int idProducto { get; set; }
        public int idProveedor { get; set; }

        public string codigo { get; set; }

        [DisplayName("Precio Unit.")]
        public double costo { get; set; }
        
        [DisplayName("Cantidad")]
        public int cantidad { get; set; }

        [DisplayName("Descuento")]
        public double descuento { get; set; }

        [DisplayName("Total")]
        public double total { get; set; }

        [DisplayName("Estado")]
        public string estado { get; set; }

        public int idCotizacion { get; set; }

        [ForeignKey("idProducto")]
        public Producto Producto { get; set; }

        [ForeignKey("idProveedor")]
        public Proveedor Proveedor { get; set; }

        [ForeignKey("idCotizacion")]
        public Cotizacion Cotizacion { get; set; }
    }
}