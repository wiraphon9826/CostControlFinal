using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CostControlWebsite.Models
{
    public class T_PR
    {
        List<T_PR> listPo = new List<T_PR>();


        public string PR_ID { get; set; } //T_PR หลัก PR_App ลอง Lift Otherjoin 
        public string Area { get; set; }
        [DisplayName("PR No")]
        public string PR_no { get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PR_date { get; set; }
        public string PR_month { get; set; }
        public string PR_year { get; set; }
        public string PR_by { get; set; }
        public string PR_job { get; set; }
        public string No_g { get; set; }
        public string PR_note { get; set; }
        public string Attached { get; set; }
        public string Remark { get; set; }
        public string Ref_no { get; set; }
        public DateTime Need_date { get; set; }
        public string Delivery { get; set; }
        public string Supplier { get; set; }
        public string Dept { get; set; }
        public string Req_type { get; set; }
        public string Years { get; set; }
        public int Oth { get; set; }
        public int InactivePR { get; set; }
        public int PO { get; set; }
        public int NonPO { get; set; }
        public int DelPurc { get; set; }
        public int DelAcc { get; set; }
        public int BOI { get; set; }
        public int NonBOI { get; set; }
        public string Disc { get; set; }
        [DisplayName("Total Price")]
        [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        public double Total { get; set; }
        public int Vat { get; set; }
        public string VatAmt { get; set; }
        public string Amt { get; set; }
        public int RowID { get; set; }
        public int ChkRaw { get; set; }
        public int ChkService { get; set; }
        public int ChkConsume { get; set; }
        public int ChkFixed { get; set; }
        public int ChkSub { get; set; }
        public int ChkOther { get; set; }
        [DisplayName("Status")]
        public int SmtStatus { get; set; }

    }
}