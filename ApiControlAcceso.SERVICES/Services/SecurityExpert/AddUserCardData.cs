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
    public class AddUserCardData : IAddUserCardData
    {

        #region Dependency
        private readonly SeDataContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public AddUserCardData(SeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<bool> Add(List<UserCardNumberGroupDatumDto> model)
        {
            try
            {
                for (int i = 0; i < model.Count; i++)
                {
                    var exi = _context.UserCardNumberGroupData.Where(s => s.UserId == model[i].UserId && s.CardNumber == model[i].CardNumber).FirstOrDefault();
                    if (exi != null)
                    {
                        return false;
                    }
                    else
                    {
                        var user = _context.Users.Where(x => x.UserId == model[i].UserId).FirstOrDefault();
                        if (user != null)
                        {
                            if (model[i].ExpiritDate != null)
                            {
                                user.ExpiryDate = Convert.ToDateTime(model[i].ExpiritDate);
                            }
                            else
                            {
                                user.ExpiryDate = DateTime.Now;                               
                            }
                            if (model[i].StartDate != null)
                            {
                                user.StartDate = Convert.ToDateTime(model[i].StartDate);
                            }
                            else
                            {
                                user.StartDate = DateTime.Now; 
                            }
                            _context.Users.Update(user);
                        }
                        foreach (var item in model)
                        {
                            var ent = _mapper.Map<UserCardNumberGroupDatum>(item);
                            _context.UserCardNumberGroupData.Add(ent);
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
