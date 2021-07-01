using System;
using System.Collections.Generic;
using System.Text;

namespace ApiControlAcceso.MODELS.Models
{
    public class LoginControl
    {
        public int Id { get; set; }
        public string Usser { get; set; }
        public string Pass { get; set; }
        public int? Area { get; set; }
        public bool? Activo { get; set; }
        public int? IdUsuario { get; set; }
        public string Foto { get; set; }
    }
}
