using System;

namespace ApiControlAcceso.MODELS.Models
{
    public class RecordGroup
    {
        public int RecordGroupId { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public int RecordGroup1 { get; set; }
        public DateTime LastModified { get; set; }
        public bool LastModifiedValid { get; set; }
        public DateTime Created { get; set; }
        public string LastOperator { get; set; }
        public int NumericData { get; set; }
        public string TextData { get; set; }
    }
}
