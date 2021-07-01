using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.MODELS.Loads.SecurityExpert;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Services.SecurityExpert
{
    public class GetCustomFieldList : IGetCustomFieldList
    {
        #region Dependency
        private readonly SeDataContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public GetCustomFieldList(SeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<CustomFieldListGroupDatumDto>> GetListCustomFields(CustomFieldsLoad model)
        {
            var result = await _context.CustomFieldListGroupData.Where(x => x.CustomFieldId == model.CustomFieldId).ToListAsync();
            var map = _mapper.Map<List<CustomFieldListGroupDatumDto>>(result);
            return map;
        }
        #endregion
    }
}
