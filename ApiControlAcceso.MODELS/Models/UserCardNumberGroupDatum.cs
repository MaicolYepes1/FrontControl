using System;
using System.Collections.Generic;
using System.Text;

namespace ApiControlAcceso.MODELS.Models
{
    public class UserCardNumberGroupDatum
    {
        public int UserId { get; set; }
        public int UserCardNumberGroupDataId { get; set; }
        public int Site { get; set; }
        public string CardNumber { get; set; }
        public string FamilyNumber { get; set; }
        public bool CardDisabled { get; set; }
        public int CardInactivityPeriodInMinutes { get; set; }
        public bool CardInactivityPeriodIsActive { get; set; }
        public int CardInactivityPeriodAction { get; set; }
        public DateTime CardLastUsed { get; set; }
        public bool CardLastUsedValid { get; set; }
    }
}
