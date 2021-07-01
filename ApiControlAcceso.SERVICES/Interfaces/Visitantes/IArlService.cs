﻿using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.MODELS.Loads.Visitantes;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.Visitantes
{
    public interface IArlService
    {
        Task<bool> InsertOrUpdate(ArlDto model);
    }
}
