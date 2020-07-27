using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CostControlWebsite.Models
{
    public class T_Admin
    {
        List<T_Admin> listT_Admin = new List<T_Admin>();

        public int User_ID { get; set; }
      
        public string User_name { get; set; }
        
        public string Password { get; set; }
        public string First_name { get; set; }
        public string Type { get; set; }
        public string Loc { get; set; }
        public int RowID { get; set; }
    }
}