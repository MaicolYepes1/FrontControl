using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.MODELS.Loads.Visitantes;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Services.SecurityExpert
{
    public class GetUsserCustomFieldsData : IGetUsserCustomFieldsData
    {
        private readonly SeDataContext _context;
        private readonly IMapper _mapper;

        public GetUsserCustomFieldsData(SeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CustomFieldDto>> GetInfo(GetInfoLoad model)
        {
            var result = await _context.CustomFields.FromSqlRaw("GetUsserCustomFIeldGroupData @UserId = {0}", model.UserId).ToListAsync();
            var map = _mapper.Map<List<CustomFieldDto>>(result);
            return map;
        }
    }
}
