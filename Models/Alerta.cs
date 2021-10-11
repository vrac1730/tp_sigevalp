using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIGEVALP.Models
{
    [Table("Alerta")]
    public class Alerta
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Observación")]
        public string nombre { get; set; }

        public string descripcion { get; set; }
    }
}