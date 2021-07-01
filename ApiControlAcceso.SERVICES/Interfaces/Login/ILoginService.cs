using ApiControlAcceso.MODELS.Constants.Token;
using ApiControlAcceso.MODELS.Loads.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.Login
{
    public interface ILoginService
    {
        Task<UsuarioToken> Login(LoginLoad Model);
    }
}
