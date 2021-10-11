using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIGEVALP.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Código")]        
        public string codigo { get; set; }

        [DisplayName("Nombre")]
        [Required]
        [RegularExpression("^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "* Solo se permiten letras.")]
        public string nombre { get; set; }

        [DisplayName("Descripción")]
        [Required]
        public string descripcion { get; set; }

        [DisplayName("Marca")]
        [Required]
        [RegularExpression("^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "* Solo se permiten letras.")]
        public string marca { get; set; }

        [DisplayName("Categoría")]
        public int idCategoria { get; set; }

        [DisplayName("Alerta")]
        public int idAlerta { get; set; }

        [ForeignKey("idAlerta")]
        public Alerta Alerta { get; set; }      

        [ForeignKey("idCategoria")]
        public Categoria Categoria { get; set; }        
               
        public List<DetalleCotizacion> DetalleCotizacion { get; set; }
    }
}