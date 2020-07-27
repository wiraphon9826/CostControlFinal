using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostControlWebsite.Models
{
    public class T_PoJoinPR
    {
        public string PoNo { get; set; }
        public bool Inactive { get; set; }
        public int SmtStatus { get; set; }

        public string PR_no { get; set; }
        public int InactivePR { get; set; }
        public int SmtStatusPR { get; set; }
        public string T_Po { get; set; }
        public string T_PR { get; set; }
        public string AreaPo { get; set; }
        public string AreaPR { get; set; }
    }
}