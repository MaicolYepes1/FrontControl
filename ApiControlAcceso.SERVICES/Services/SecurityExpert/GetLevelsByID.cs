using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Loads.SecurityExpert;
using ApiControlAcceso.MODELS.Models;
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
    public class GetLevelsByID : IGetLevelsByID
    {
        #region Dependency
        private readonly SeDataContext _context;
        private readonly IMapper _map;
        #endregion

        #region Constructor
        public GetLevelsByID(SeDataContext context, IMapper map)
        {
            _context = context;
            _map = map;
        }
        #endregion

        #region Methods
        public async Task<List<LevelsID>> Get(List<LevelsID> model)
        {
            try
            {
                List<AccessLevel> list = new List<AccessLevel>();
                foreach (var item in model)
                {
                    var res =  _context.AccessLevels.Where(p => p.AccessLevelId == item.AccessLevelId).FirstOrDefault();
                    if (res != null)
                    {
                        list.Add(res);
                    }
                }

                var map = _map.Map<List<LevelsID>>(list);
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
