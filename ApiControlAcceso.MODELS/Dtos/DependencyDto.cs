using ApiControlAcceso.MODELS.Models;
using System.Collections.Generic;

namespace ApiControlAcceso.MODELS.Dtos
{
    public class DependencyDto
    {
        public List<UserCustomFieldGroupDatum> Area { get; set; }
        public List<UserCustomFieldGroupDatum> Identificacion { get; set; }
        public List<UserCustomFieldGroupDatum> Dependencia { get; set; }
    }
}
