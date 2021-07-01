using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Constants;
using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Services.SecurityExpert
{
    public class GetAsignTarjet : IGetAsignTarjet
    {
        #region Dependency
        private readonly SeDataContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public GetAsignTarjet(SeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<string>> Get()
        {
            try
            {
                var res = await _context.UserCardNumberGroupData.ToListAsync();
                var map = _mapper.Map<List<UserCardNumberGroupDatumDto>>(res);
                return map.Select(s => s.CardNumber).ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<UserCardNumberGroupDatumDto>> GetUsertTarjet(Request request)
        {
            try
            {
                var res = await _context.UserCardNumberGroupData.Where(s => s.UserId == request.UserID).ToListAsync();
                var map = _mapper.Map<List<UserCardNumberGroupDatumDto>>(res);

                return map;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}
