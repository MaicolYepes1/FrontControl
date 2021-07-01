using System;
using System.Collections.Generic;
using System.Text;

namespace ApiControlAcceso.MODELS.Dtos
{
    public class CustomFieldsDto
    {
        public int CustomFieldId { get; set; }
        public string Name { get; set; }
        public int SiteId { get; set; }
        public int FieldType { get; set; }
    }
}
