using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Constants.Token;
using ApiControlAcceso.MODELS.Loads.Login;
using ApiControlAcceso.SERVICES.Interfaces.Login;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiControlAcceso.SERVICES.Services.Login
{
    public class LoginService : ILoginService
    {
        #region Dependencias
        private readonly AppDataContext _context;
        private readonly AppSettingsDto _appSettings;
        #endregion

        #region Constructor
        public LoginService(AppDataContext context, IOptions<AppSettingsDto> app)
        {
            _context = context;
            _appSettings = app.Value;
        }
        #endregion

        #region Metodos
        public async Task<UsuarioToken> Login(LoginLoad Model)
        {
            try
            {
                UsuarioToken TokenResult = new UsuarioToken();
                //var user = "";
                //var isValid = false;
                //using (var context = new PrincipalContext(ContextType.Domain, "SOAM.SESAM.MANE.COM"))
                //using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                //{
                //    UserPrincipal yourUser = UserPrincipal.FindByIdentity(context, Model.Usser);
                //    isValid = context.ValidateCredentials(Model.Usser, Model.Pass);
                //    if (yourUser != null)
                //    {
                //        user = yourUser.GivenName + " " + yourUser.Surname;
                //    }
                //}
                //if (isValid)
                //{
                    var result = await _context.LoginControls.Where(x => x.Usser == Model.Usser && x.Pass == Model.Pass).FirstOrDefaultAsync();
                if (result != null)
                {
                    var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.SecureKey));

                    var _signingCredentials = new SigningCredentials(
                           signinKey, SecurityAlgorithms.HmacSha256
                        );
                    var _Header = new JwtHeader(_signingCredentials);

                    // CREAMOS LOS CLAIMS //
                    var _Claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.NameId, Model.Usser)
                    };

                    // CREAMOS EL PAYLOAD //
                    var _Payload = new JwtPayload(
                            issuer: "",
                            audience: "",
                            claims: _Claims,
                            notBefore: DateTime.Now,
                            expires: DateTime.Now.AddDays(1)
                        );

                    // GENERAMOS EL TOKEN //
                    var _Token = new JwtSecurityToken(
                            _Header,
                            _Payload
                        );
                    IdentityModelEventSource.ShowPII = true;
                    TokenResult.Token = new JwtSecurityTokenHandler().WriteToken(_Token);
                    TokenResult.TokenExpiracion = _Token.ValidTo;
                    //TokenResult.Lista = _context.Roles.Where(x => x.Activo == true && x.IdUsuario == result.Id).ToList();
                    TokenResult.Usuario = result.Usser;
                    //TokenResult.Foto = result.Foto;
                    return TokenResult;
                }
                else
                {
                    return null;
                }
                //}
                
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
    }
}
