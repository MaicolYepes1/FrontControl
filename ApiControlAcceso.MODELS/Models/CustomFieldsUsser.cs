using System;
using System.Collections.Generic;
using System.Text;

namespace ApiControlAcceso.MODELS.Models
{
    public class CustomFieldsUsser
    {
        public int Id { get; set; }
        public int CustomFieldId { get; set; }
        public int CustomFieldType { get; set; }
        public string CustomFieldTextData { get; set; }
    }
}
