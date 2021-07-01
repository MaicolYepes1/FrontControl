using System;
using System.Collections.Generic;
using System.Text;

namespace ApiControlAcceso.MODELS.Models
{
    public class Incidente
    {
        public int Id { get; set; }
        public int? IdVisitante { get; set; }
        public string Asunto { get; set; }
        public string Fecha { get; set; }
        public string Descripcion { get; set; }
    }
}
