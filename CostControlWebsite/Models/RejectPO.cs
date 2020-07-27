using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostControlWebsite.Models
{
    public class RejectPO
    {
        public string T_Po { get; set; }
        public string Area { get; set; }
        public string PoNo { get; set; }
        public DateTime PoDate { get; set; }
        public string DelDate { get; set; }
        public bool Inactive { get; set; }
        public string Total { get; set; }
        public int SmtStatus { get; set; }
    }
}