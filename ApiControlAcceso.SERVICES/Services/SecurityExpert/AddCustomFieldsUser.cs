using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Models;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Services.SecurityExpert
{
    public class AddCustomFieldsUser : IAddCustomFieldsUser
    {
        #region Dependency
        private readonly SeDataContext _context;
        #endregion

        #region Constructor
        public AddCustomFieldsUser(SeDataContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<bool> Add(UserCustomFieldGroupDatum model)
        {
            try
            {
                var exi = _context.UserCustomFieldGroupData.Where(s => s.CustomFieldId == model.CustomFieldId && s.UserId == model.UserId).FirstOrDefault();
                if (exi != null)
                {
                    return false;
                }
                else
                {
                    model.CustomFieldBooleanData = false;
                    model.CustomFieldDateTimeData = DateTime.Now;
                    var res = await _context.UserCustomFieldGroupData.AddAsync(model);
                    await _context.SaveChangesAsync();
                    return true;
                }               
            }
            catch (Exception e)
            {

                throw;
            }
        }
        #endregion
    }
}
