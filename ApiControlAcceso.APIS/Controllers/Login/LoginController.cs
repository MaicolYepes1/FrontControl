using ApiControlAcceso.MODELS.Loads.Login;
using ApiControlAcceso.SERVICES.Interfaces.Login;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace ApiControlAcceso.APIS.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Dependencias
        private readonly ILoginService _login;
        #endregion

        #region Constructor
        public LoginController(ILoginService login)
        {
            _login = login;
        }
        #endregion

        #region Metodos Get

        #endregion

        #region Metodos Post
        [HttpPost]
        public async Task<IActionResult> login(LoginLoad Model)
        {
            try
            {
                var result = await _login.Login(Model);

                return result != null ? Ok(result) : (IActionResult)(NoContent());

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
