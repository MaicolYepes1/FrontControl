using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Services.SecurityExpert
{
   public  class GetCustomFieldService : IGetCustomField
    {
        #region Dependency
        private readonly SeDataContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public GetCustomFieldService(SeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<CustomFieldsDto>> Get(SeLoad model)
        {
            try
            {
                var res =  _context.CustomFields.Where(x => x.SiteId == model.SiteID).ToList();
                if (res == null)
                {
                    return null;
                }
                else
                {
                    var map = _mapper.Map<List<CustomFieldsDto>>(res);
                    return map;
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
