using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Constants;
using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.MODELS.Models;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Services.SecurityExpert
{
    public class AddUsserService : IAddUsserService
    {
        #region Dependency
        private readonly SeDataContext _context;
        #endregion

        #region Constructor
        public AddUsserService(SeDataContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<Response> Add(UsserInfoDto model)
        {
            try
            {
                var  ds = _context.SpUsers.FromSqlRaw("EXEC Agil_spAddUsers @UserID = {0}, @SiteID = {1}, @LastName = {2}, @FirstName = {3}, @RecordGroup = {4}, @LastOperator = {5}", model.userID, model.siteID, model.lastName, model.firstName, model.recordGroup, model.lastOperator).ToList();
                if (ds.Count == 0)
                {
                    return null;
                }
                else
                {
                    Response response = new Response();
                    response.UserId = Convert.ToInt32(ds[0].IdUser);
                    return response;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
    }
}
