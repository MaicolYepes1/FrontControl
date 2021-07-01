using ApiControlAcceso.MODELS.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetSiteIDService
    {
        Task<List<SiteDto>> GetSiteID();
    }
}
