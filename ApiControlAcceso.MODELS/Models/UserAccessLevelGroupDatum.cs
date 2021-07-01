using System;

namespace ApiControlAcceso.MODELS.Models
{
    public class UserAccessLevelGroupDatum
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserAccessLevelGroupDataId { get; set; }
        public int Site { get; set; }
        public int UserAccessLevel { get; set; }
        public DateTime UserAccessLevelStart { get; set; }
        public DateTime UserAccessLevelEnd { get; set; }
        public bool UserAccessLevelExpire { get; set; }
        public int UserAccessLevelSchedule { get; set; }
    }
}
