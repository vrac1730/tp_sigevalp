using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIGEVALP.Models
{
    [Table("ProductoAlmacen")]
    public class ProductoxAlmacen
    {
        [Key]
        public int id { get; set; }
        public int punto_pedido { get; set; }

        [DisplayName("Cantidad")]
        public int cantidad { get; set; }

        [DisplayName("Stock mínimo")]
        [Range(000, 25, ErrorMessage = "Valor positivo, no mayor a 25")]
        public int stock_min { get; set; }

        [DisplayName("Stock máximo")]
        [Range(0000, 1000, ErrorMessage = "Valor positivo, no mayor a 1000")]
        public int stock_max { get; set; }

        public int idProducto { get; set; }
        public int idEstado { get; set; }        
        public int idAlmacen { get; set; }

        [DisplayName("Alerta")]
        public int idAlerta { get; set; }

        [ForeignKey("idProducto")]
        public Producto Producto { get; set; }

        [ForeignKey("idEstado")]
        public Estado Estado { get; set; }

        [ForeignKey("idAlerta")]
        public Alerta Alerta { get; set; }

        [ForeignKey("idAlmacen")]
        public Almacen Almacen { get; set; }

        public List<HistorialMovimiento> HistorialMovimiento { get; set; }
    }
}