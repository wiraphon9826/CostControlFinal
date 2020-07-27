using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace CostControlWebsite
{
    public class Connection
    {
        public SqlConnection connectionDB()
        {

            SqlConnection sqlcon = new SqlConnection();
            string sqlconstr = ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;

            sqlcon.ConnectionString = sqlconstr;

            if (sqlcon != null || sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();



            }
            return sqlcon;
        }


    }

}
