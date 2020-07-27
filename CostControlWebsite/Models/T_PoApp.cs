using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CostControlWebsite.Models
{
    public class T_PoApp
    {
        List<T_PoApp> listPoApp = new List<T_PoApp>();
        
        public string Area { get; set; }
        public string PoNo { get; set; }
        public int SmtStatus { get; set; }
        public string ReasonRev { get; set; }
        public string ReasonApp { get; set; }
        public DateTime SmtDate { get; set; }
        public string SmtBy { get; set; }
        public DateTime RevDate { get; set; }
        public string RevBy { get; set; }
        public DateTime AppDate { get; set; }
        public string AppBy { get; set; }
        public int SendEmail { get; set; }


    }
}


   

 

