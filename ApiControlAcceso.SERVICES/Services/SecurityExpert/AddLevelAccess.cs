using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.MODELS.Models;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Services.SecurityExpert
{
    public class AddLevelAccess : IAddLevelAccess
    {
        #region Dependency
        private readonly SeDataContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public AddLevelAccess(SeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<bool> Add(List<UserAccessLevelGroupDatumDto> model)
        {
            try
            {
                for (int i = 0; i < model.Count; i++)
                {
                    var exi = _context.UserAccessLevelGroupData.Where(s => s.UserId == model[0].UserId && s.UserAccessLevel == model[0].UserAccessLevel).FirstOrDefault();
                    if (exi != null)
                    {
                        return false;
                    }
                    else
                    {
                        foreach (var item in model)
                        {
                            if (item.UserAccessLevelEnd != null)
                            {
                                item.UserAccessLevelEnd = DateTime.Now;
                            }
                            if (item.UserAccessLevelStart != null)
                            {
                                item.UserAccessLevelStart = DateTime.Now;
                            }                            
                            var map = _mapper.Map<UserAccessLevelGroupDatum>(item);
                            _context.UserAccessLevelGroupData.Add(map);
                            
                        }
                        await _context.SaveChangesAsync();
                        return true;
                    }                    
                }
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}
