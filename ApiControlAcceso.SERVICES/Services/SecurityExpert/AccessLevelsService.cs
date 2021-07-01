using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Services.SecurityExpert
{
    public class AccessLevelsService : IAccessLevelsService
    {
        #region Dependency
        private readonly SeDataContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public AccessLevelsService(SeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<AccessLevelsDto>> Get(SeLoad model)
        {
            try
            {
                var res = _context.AccessLevels.Where(x => x.SiteId == model.SiteID).ToList();                
                if (res != null)
                {
                    var map = _mapper.Map<List<AccessLevelsDto>>(res);
                    return map;
                }
                else
                {
                    return null;
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
