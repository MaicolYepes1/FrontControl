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
    public class GetSiteIDService : IGetSiteIDService
    {
        #region Dependency
        private readonly SeDataContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public GetSiteIDService(SeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<SiteDto>> GetSiteID()
        {
            try
            {
                var result = _context.Sites.ToList();
                var map = _mapper.Map<List<SiteDto>>(result);
                return map;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
    }
}
