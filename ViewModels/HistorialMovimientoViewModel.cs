using SIGEVALP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIGEVALP.ViewModels
{
    public class HistorialMovimientoViewModel
    {
        public List<DetalleSolicitud> detalleSolicitud { get; set; }
        public List<DetalleCompra> detalleCompra { get; set; }
    }
}