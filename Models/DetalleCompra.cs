using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIGEVALP.Models
{
    [Table("DetalleCompra")]
    public class DetalleCompra
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Cantidad")]
        public int cantidad { get; set; }

        [DisplayName("Recibido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten  positivos.")]
        public int cantidadRecibida { get; set; }

        [DisplayName("Total")]
        public double total { get; set; }
        public int idOrdenCompra { get; set; }
        public int idProducto { get; set; }

        [ForeignKey("idOrdenCompra")]
        public OrdenCompra OrdenCompra { get; set; }

        [ForeignKey("idProducto")]
        public Producto Producto { get; set; }
        //[ForeignKey("idProducto, idProveedor")]
        //public DetalleCotizacion DetalleCotizacion { get; set; }
    }
}