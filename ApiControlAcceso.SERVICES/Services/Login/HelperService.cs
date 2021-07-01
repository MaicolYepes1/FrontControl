using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Models;
using ApiControlAcceso.SERVICES.Interfaces.Login;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Services.Login
{
    public class HelperService : IHelperService
    {
        #region Dependency
        private readonly AppDataContext _context;
        #endregion

        #region Constructor
        public HelperService(AppDataContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<List<Helper>> Get()
        {
            try
            {
                var res = await _context.Helpers.ToListAsync();
                if (res != null)
                {
                    return res;
                }
                else
                {
                    return null;
                }              
            }
            catch (Exception)
            {
                throw;
            }
        
        }
        #endregion
    }
}
