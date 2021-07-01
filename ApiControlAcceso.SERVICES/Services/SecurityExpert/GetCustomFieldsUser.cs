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
    public class GetCustomFieldsUser : IGetCustomFieldsUser
    {
        #region Dependency
        private readonly SeDataContext _context;
        private readonly IMapper _mapper;
        #endregion

        public GetCustomFieldsUser(SeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InfoDto> GetInfo(Request request)
        {
            InfoDto info = new InfoDto();
            if (request.UserID != 0)
            {
                var resCards = await _context.UserCardNumberGroupData.Where(s => s.UserId == request.UserID).ToListAsync();
                var mapCards = _mapper.Map<List<UserCardNumberGroupDatumDto>>(resCards);
                var resCustoms = await _context.UserCustomFieldGroupData.Where(s => s.UserId == request.UserID).ToListAsync();
                var mapCustoms = _mapper.Map<List<UserCustomFieldGroupDatumDto>>(resCustoms);
                var resAccess = await _context.UserAccessLevelGroupData.Where(s => s.UserId == request.UserID).ToListAsync();
                var mapAccess = _mapper.Map<List<UserAccessLevelGroupDatumDto>>(resAccess);
                for (int i = 0; i < mapAccess.Count; i++)
                {
                    var name = _context.AccessLevels.Where(s => s.AccessLevelId == mapAccess[i].UserAccessLevel).Select(n => n.Name).FirstOrDefault();
                    mapAccess[i].Name = name;
                }
                if (mapCards.Count != 0)
                {
                    info.Cards = mapCards;
                }

                if (mapCustoms.Count != 0)
                {
                    info.Customs = mapCustoms;
                }

                if (mapAccess.Count != 0)
                {
                    info.Access = mapAccess;
                }
                return info;
            }
            else
            {
                return null;
            }
        }
    }
}
