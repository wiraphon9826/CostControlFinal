using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostControlWebsite.Models
{
    public class RejectPR
    {
        public string PR_no { get; set; }
        public string Area { get; set; }

        public DateTime PR_date { get; set; }

        public int InactivePR { get; set; }

        public string Total { get; set; }

        public int SmtStatus { get; set; }

    }
}