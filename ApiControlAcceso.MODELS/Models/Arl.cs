using System;
using System.Collections.Generic;
using System.Text;

namespace ApiControlAcceso.MODELS.Models
{
    public class Arl
    {
        public int Id { get; set; }
        public int? IdVisitante { get; set; }
        public string Documento { get; set; }
        public string FechaExpiracion { get; set; }
        public string Detalle { get; set; }
    }
}
