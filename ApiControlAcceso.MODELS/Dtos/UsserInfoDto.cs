using System;
using System.Collections.Generic;
using System.Text;

namespace ApiControlAcceso.MODELS.Dtos
{
    public class UsserInfoDto
    {
        public int siteID { get; set; }
        public int userID { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public int recordGroup { get; set; }
        public string lastOperator { get; set; }
    }
}
