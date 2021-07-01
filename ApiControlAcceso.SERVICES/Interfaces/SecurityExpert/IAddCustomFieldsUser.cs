using ApiControlAcceso.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IAddCustomFieldsUser
    {
        Task<bool> Add(UserCustomFieldGroupDatum model);
    }
}
