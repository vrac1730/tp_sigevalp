using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIGEVALP.Models
{
    public class HistorialMovimiento
    {
        [Key]
        public int id { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }        
        public string tipo { get; set; }
        public int idProductoxAlmacen { get; set; }
        
        //[ForeignKey("idProductoxAlmacen")]
        //public ProductoxAlmacen ProductoxAlmacen { get; set; }

    }
}