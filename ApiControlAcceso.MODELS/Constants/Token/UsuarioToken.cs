using ApiControlAcceso.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiControlAcceso.MODELS.Constants.Token
{
    public class UsuarioToken
    {
        public UsuarioToken()
        {
            Token = string.Empty;
            Lista = new List<Roles>();
        }

        public string Foto { get; set; }
        public string Usuario { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpiracion { get; set; }
        public List<Roles> Lista { get; set; }
    }
}
