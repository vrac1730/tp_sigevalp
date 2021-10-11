using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIGEVALP.Models
{
    [Table("DetalleSolicitud")]
    public class DetalleSolicitud
    {
        [Key]
        public int id{ get; set; }       
        
        [DisplayName("Cantidad Requerida")]
        public int cantSolicitada { get; set; }

        [DisplayName("Cantidad Entregada")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten  positivos.")]
        public int cantEntregada { get; set; }

        public string observacion { get; set; }

        [DisplayName("Producto")]
        public int idProducto { get; set; }

        public int idSolicitud { get; set; }

        [ForeignKey("idSolicitud")]
        public Solicitud Solicitud { get; set; }

        [ForeignKey("idProducto")]
        public Producto Producto { get; set; }        
    }
}