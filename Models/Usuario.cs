using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SIGEVALP.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Cliente")]
        public string username { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public int idLocal { get; set; }
        public int idPersona { get; set; }

        [ForeignKey("idLocal")]
        public Local Local { get; set; }

        [ForeignKey("idPersona")]
        public Persona Persona { get; set; }

        //public List<UsuarioxRol> UsuarioxRol { get; set; }
        public List<OrdenCompra> OrdenCompra { get; set; }
        public List<Solicitud> Solicitud { get; set; }
        public List<Cotizacion> Cotizacion { get; set; }
    }
}