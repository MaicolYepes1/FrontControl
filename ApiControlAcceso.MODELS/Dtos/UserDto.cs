using System;
using System.Collections.Generic;
using System.Text;

namespace ApiControlAcceso.MODELS.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public int SiteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ExpiritDate { get; set; }
        public DateTime StartDate { get; set; }
        public int RecordGroup { get; set; }
    }
}
