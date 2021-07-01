using System;
using System.Collections.Generic;
using System.Text;

namespace ApiControlAcceso.MODELS.Models
{
    public class CustomFields
    {
        public int CustomFieldId { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public int Tab { get; set; }
        public int FieldType { get; set; }
        public string DefaultValue { get; set; }
        public int CustomFieldList { get; set; }
        public bool DisplayDropDownList { get; set; }
        public DateTime LastModified { get; set; }
        public bool LastModifiedValid { get; set; }
        public DateTime Created { get; set; }
        public string LastOperator { get; set; }
        public int ImageWidthPixels { get; set; }
        public int ImageHeightPixels { get; set; }
        public int RecordGroup { get; set; }
    }
}
