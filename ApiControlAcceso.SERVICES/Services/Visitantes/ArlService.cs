using ApiControlAcceso.INFRA.Context;
using ApiControlAcceso.INFRA.Repository.Interfaces;
using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.MODELS.Loads.Visitantes;
using ApiControlAcceso.MODELS.Models;
using ApiControlAcceso.SERVICES.Interfaces.Visitantes;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Services.Visitantes
{
    public class ArlService : IArlService
    {
        #region Dependencies
        private readonly IGenericRepository<Arl> _reporitory;
        private readonly IMapper _mapper;
        private readonly AppDataContext _context;
        #endregion

        #region Constructor
        public ArlService(IGenericRepository<Arl> repository, IMapper mapper, AppDataContext context)
        {
            _reporitory = repository;
            _mapper = mapper;
            _context = context;
        }
        #endregion

        #region Metodos
        public async Task<bool> InsertOrUpdate(ArlDto model)
        {
            try
            {
                if (model != null)
                {
                    var map = _mapper.Map<Arl>(model);
                    if (model.Id == 0)
                    {
                        var insert = await _reporitory.Insert(map);
                    }
                    else
                    {
                        var equip = _reporitory.GetById(map.Id);
                        if (equip != null)
                        {
                            _reporitory.Update(map);
                            _reporitory.Save();
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
