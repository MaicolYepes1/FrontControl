using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.MODELS.Models;
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
    public class UpdateUserSe : IUpdateUserSe
    {
        #region Dependency
        private readonly SeDataContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public UpdateUserSe(SeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<bool> Update(SeInfoDto model)
        {
            try
            {
                var res = _context.Users.Where(s => s.UserId == model.UserInfo[0].userID).FirstOrDefault();
                res.FirstName = model.UserInfo[0].firstName;
                res.LastName = model.UserInfo[0].lastName;
                res.LastOperator = model.UserInfo[0].lastOperator;
                res.RecordGroup = model.UserInfo[0].recordGroup;
                res.SiteId = model.UserInfo[0].siteID;
                _context.Users.Update(res);
                _context.Entry(res).State = EntityState.Modified;
                _context.SaveChanges();
                foreach (var item in model.InfoTarjet)
                {
                    var resTarjet = _context.UserCardNumberGroupData.Where(c => c.CardNumber == item.CardNumber && c.UserId == model.UserInfo[0].userID).FirstOrDefault();
                    if (resTarjet != null)
                    {
                        resTarjet.FamilyNumber = item.FamilyNumber;
                        resTarjet.CardDisabled = item.CardDisabled;
                        resTarjet.UserId = model.UserInfo[0].userID;
                        _context.UserCardNumberGroupData.Update(resTarjet);
                        _context.Entry(resTarjet).State = EntityState.Modified;
                        var upod = _context.SaveChanges();
                    }
                    else
                    {
                        for (int i = 0; i < model.InfoTarjet.Count; i++)
                        {
                            var exi = _context.UserCardNumberGroupData.Where(s => s.UserId == model.InfoTarjet[i].UserId && s.CardNumber == model.InfoTarjet[i].CardNumber).FirstOrDefault();
                            if (exi != null)
                            {
                                return false;
                            }
                            else
                            {
                                var user = _context.Users.Where(x => x.UserId == model.InfoTarjet.UserId).FirstOrDefault();
                                if (user != null)
                                {
                                    if (model.InfoTarjet[i].ExpiritDate != null)
                                    {
                                        user.ExpiryDate = Convert.ToDateTime(model.InfoTarjet[i].ExpiritDate);
                                    }
                                    else
                                    {
                                        user.ExpiryDate = DateTime.Now;
                                    }
                                    if (model.InfoTarjet[i].StartDate != null)
                                    {
                                        user.StartDate = Convert.ToDateTime(model.InfoTarjet[i].StartDate);
                                    }
                                    else
                                    {
                                        user.StartDate = DateTime.Now;
                                    }
                                    _context.Users.Update(user);
                                }
                                foreach (var item1 in model.InfoTarjet)
                                {
                                    var ent = _mapper.Map<UserCardNumberGroupDatum>(item1);
                                    _context.UserCardNumberGroupData.Add(ent);
                                }
                                await _context.SaveChangesAsync();
                                return true;
                            }
                        }
                    }
                }
                foreach (var item in model.LevelAccess)
                {
                    var resLevels = _context.UserAccessLevelGroupData.Where(l => l.UserAccessLevel == item.UserAccessLevel && l.UserId == model.UserInfo[0].userID).FirstOrDefault();
                    resLevels.UserAccessLevelStart = Convert.ToDateTime(item.UserAccessLevelStart);
                    resLevels.UserAccessLevelEnd = Convert.ToDateTime(item.UserAccessLevelEnd);
                    _context.UserAccessLevelGroupData.Update(resLevels);
                    _context.Entry(resLevels).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                foreach (var item in model.Dependency)
                {
                    var resArea = _context.UserCustomFieldGroupData.Where(f => f.UserId == model.UserInfo[0].userID && f.CustomFieldId == item.Area[0].CustomFieldId).FirstOrDefault();
                    resArea.CustomFieldTextData = item.Area[0].CustomFieldTextData;
                    resArea.UserId = model.UserInfo[0].userID;
                    resArea.CustomFieldType = item.Area[0].CustomFieldType;
                    resArea.CustomFieldNumericalData = item.Area[0].CustomFieldNumericalData;
                    _context.UserCustomFieldGroupData.Update(resArea);
                    var resDependency = _context.UserCustomFieldGroupData.Where(f => f.UserId == model.UserInfo[0].userID && f.CustomFieldId == item.Dependencia[0].CustomFieldId).FirstOrDefault();
                    resDependency.CustomFieldTextData = item.Dependencia[0].CustomFieldTextData;
                    resDependency.UserId = model.UserInfo[0].userID;
                    resDependency.CustomFieldType = item.Dependencia[0].CustomFieldType;
                    resDependency.CustomFieldNumericalData = item.Dependencia[0].CustomFieldNumericalData;
                    _context.UserCustomFieldGroupData.Update(resDependency);
                    var resIdenti = _context.UserCustomFieldGroupData.Where(f => f.UserId == model.UserInfo[0].userID && f.CustomFieldId == item.Identificacion[0].CustomFieldId).FirstOrDefault();
                    resIdenti.CustomFieldTextData = item.Identificacion[0].CustomFieldTextData;
                    resIdenti.UserId = model.UserInfo[0].userID;
                    resIdenti.CustomFieldType = item.Identificacion[0].CustomFieldType;
                    resIdenti.CustomFieldNumericalData = item.Identificacion[0].CustomFieldNumericalData;
                    _context.UserCustomFieldGroupData.Update(resIdenti);
                    _context.Entry(resIdenti).State = EntityState.Modified;
                }
                _context.SaveChanges();
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
