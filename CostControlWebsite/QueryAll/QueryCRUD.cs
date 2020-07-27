using CostControlWebsite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CostControlWebsite.QueryAll
{

    public class QueryCRUD : Connection
    {
        #region Sqlconnection
        private SqlConnection conn;
        private void connection()
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["connectionStr"].ToString();
            conn = new SqlConnection(connectionStr);
        }
        #endregion
        public List<T_Job> listjob()
        {

            try
            {
                connection();
                List<T_Job> listJ = new List<T_Job>();
                string GetQuery = "select pj.Job_Code as jc from T_poandT_Job as pj";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    listJ.Add(
                        new T_Job
                        {
                            PoJob = Convert.ToString(dr["jc"]),

                        });


                }
                return listJ;


            }
            catch (Exception)
            {

                return null;

            }

        }
        public List<T_Job> listjobPR()
        {

            try
            {
                connection();
                List<T_Job> listJ = new List<T_Job>();
                string GetQuery = "select pj.Job_Code as jc from T_PRandT_Job as pj";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    listJ.Add(
                        new T_Job
                        {
                            PRJob = Convert.ToString(dr["jc"]),

                        });


                }
                return listJ;


            }
            catch (Exception)
            {

                return null;

            }

        }


        public bool CheckLogin(string User_name, string Password)
        {
            bool result = false;
            List<T_Admin> getlist = new List<T_Admin>();
            SqlCommand com = new SqlCommand();
            SqlDataReader rd = null;

            #region Connection Database
            SqlConnection con = new SqlConnection();

            con = connectionDB();

            com.Connection = con;
            #endregion

            #region Send Query

            com.CommandType = CommandType.Text;
            com.CommandText = "SELECT COUNT(ta.User_name) AS User_name, ta.Password, ta.Type as t FROM T_Admin as ta where ta.User_name= '" + User_name + "' and ta.Password = '" + Password + "' GROUP BY ta.Type, ta.Password";

            #endregion

            #region Return Data

            rd = com.ExecuteReader();

            if (rd != null && rd.HasRows)
            {
                while (rd.Read())
                {
                    int count = Convert.ToInt16(rd["User_name"].ToString());

                    if (count == 1)
                    {


                        result = true;


                    }


                }


            }

            #endregion

            return result;


        }
        public bool CheckAdmin(string User_name, string Password)
        {

            bool result = false;
            List<T_Admin> getlist = new List<T_Admin>();
            SqlCommand com = new SqlCommand();
            SqlDataReader rd = null;

            #region Connection Database
            SqlConnection con = new SqlConnection();

            con = connectionDB();

            com.Connection = con;
            #endregion

            #region Send Query

            com.CommandType = CommandType.Text;
            com.CommandText = "select count(am.User_name) as User_name  from T_Admin as am where am.User_name = '" + User_name+"' and am.Password = '"+Password+"' and am.Type = '1'";

            #endregion

            #region Return Data

            rd = com.ExecuteReader();

            if (rd != null && rd.HasRows)
            {
                while (rd.Read())
                {
                    int count = Convert.ToInt16(rd["User_name"].ToString());

                    if (count == 1)
                    {


                        result = true;


                    }


                }


            }

            #endregion

            return result;
        }

        public List<T_Admin> T_Admins(string User_name, string Password)
            {

            try
            {
                connection();

                List<T_Admin> getlist1 = new List<T_Admin>();

                string GetQuery = "SELECT ta.User_name as un, ta.Password as pw , ta.Type as type FROM T_Admin as ta WHERE (ta.User_name = N'"+User_name+"') AND (ta.Password = N'"+Password+"')GROUP BY Type, Password, User_name";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();


                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist1.Add(
                        new T_Admin
                        {

                            Type = Convert.ToString(dr["type"]),

                        });


                }
                return getlist1;



            }
            catch (Exception)
            {

                return null;

            }


        }
        public T_Admin Get_T_Admins(string User_name)
        {

            try
            {
                connection();

                T_Admin getlist1 = new T_Admin();

                string GetQuery = "select tm.User_ID as uid from T_Admin as tm where tm.User_name = '"+User_name+"' ";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();


                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {



                    getlist1.User_ID = Convert.ToInt16(dr["uid"]);

                  


                }

                return getlist1;


            }
            catch (Exception)
            {

                return null;

            }


        }
        public List<T_PoJoinPR> GetTPO()
        {
            try
            {
                connection();
                List<T_PoJoinPR> getlist = new List<T_PoJoinPR>();

                string GetQuery = "select po.Area as ar,po.T_Po as po ,pr.Area as pra,pr.T_PR as pr from T_Loc as lc left join PoandPoApp as po on lc.Area = po.Area left join PRandPRApp as pr on lc.Area = pr.Area";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();


                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist.Add(
                        new T_PoJoinPR
                        {

                            AreaPo = Convert.ToString(dr["ar"]),
                            T_Po = Convert.ToString(dr["po"]),
                            AreaPR = Convert.ToString(dr["pra"]),
                            T_PR = Convert.ToString(dr["pr"]),
                        });


                }
                return getlist;



            }
            catch (Exception)
            {

                return null;

            }
        }
        public List<HoldingPO> GetTPOHolding()
        {
            try
            {
                connection();
                List<HoldingPO> getlist = new List<HoldingPO>();

                string GetQuery = "select hopo.T_PoApp as poa,hopo.SmtStatus as smt from HoldingPO as hopo";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();


                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist.Add(
                        new HoldingPO
                        {

                            Area = Convert.ToString(dr["poa"]),
                            SmtStatus = Convert.ToInt16(dr["smt"]),
                            
                        });


                }
                return getlist;



            }
            catch (Exception)
            {

                return null;

            }
        }
        public List<HoldingPR> GetT_PRHolding()
        {
            try
            {
                connection();
                List<HoldingPR> getlist = new List<HoldingPR>();

                string GetQuery = "select hopr.T_PR_App as pra,hopr.SmtStatus as smt from HoldingPR as hopr";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();


                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist.Add(
                        new HoldingPR
                        {

                            Area = Convert.ToString(dr["pra"]),
                            SmtStatus = Convert.ToInt16(dr["smt"]),

                        });


                }
                return getlist;



            }
            catch (Exception)
            {

                return null;

            }
        }
        public List<T_Po> GetT_Po()
        {
            try
            {
                connection();

                List<T_Po> getlist = new List<T_Po>();
                string GetQuery = "select po.PoNo as poNo,po.Area as area, CONVERT(date,po.PoDate)  as PoDate ,CONVERT(date,po.DelDate) as DelDate , po.Inactive as Inactive,po.Total as Total ,po.SmtStatus as Smtstatus from ShowPO as po Order By po.SmtStatus";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();





                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist.Add(
                        new T_Po
                        {

                            PoNo = Convert.ToString(dr["PoNo"]),
                            Area = Convert.ToString(dr["area"]),
                            PoDate = Convert.ToDateTime(dr["PoDate"]),
                            DelDate = Convert.ToDateTime(dr["DelDate"].ToString()),
                            Inactive = Convert.ToBoolean(dr["Inactive"]),
                            Total = Convert.ToDouble(dr["Total"]),
                            SmtStatus = Convert.ToInt16(dr["Smtstatus"]),
                        });


                }
                return getlist;


            }
            catch (Exception)
            {

                return null;

            }
        }
        public List<T_Po> SearchT_Po(string Search)
        {
            try
            {
                connection();

                List<T_Po> getlist = new List<T_Po>();
                string GetQuery = "select po.PoNo as poNo,po.Area as area, po.PoDate as PoDate , po.DelDate as DelDate , po.Inactive as Inactive,po.Total as Total ,po.SmtStatus as Smtstatus from ShowPO as po where po.PoNo LIKE '%" + Search + "%'  Order By po.SmtStatus";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist.Add(
                        new T_Po
                        {

                            PoNo = Convert.ToString(dr["PoNo"]),
                            Area = Convert.ToString(dr["area"]),
                            PoDate = Convert.ToDateTime(dr["PoDate"]),
                            DelDate = Convert.ToDateTime(dr["DelDate"]),
                            Inactive = Convert.ToBoolean(dr["Inactive"]),
                            Total = Convert.ToDouble(dr["Total"]),
                            SmtStatus = Convert.ToInt16(dr["Smtstatus"]),
                        });


                }
                return getlist;


            }
            catch (Exception)
            {

                return null;

            }
        }
        public List<T_Po> SearchT_PoJOB(string Search)
        {
            try
            {
                connection();

                List<T_Po> getlist = new List<T_Po>();
                string GetQuery = "select po.PoNo as poNo,po.Area as area, po.PoDate as PoDate , po.DelDate as DelDate ,po.Inactive as Inactive,po.Total as Total ,po.SmtStatus as Smtstatus from ShowPO as po where po.PoJob LIKE '%"+Search+"%'  Order By po.SmtStatus";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist.Add(
                        new T_Po
                        {

                            PoNo = Convert.ToString(dr["PoNo"]),
                            Area = Convert.ToString(dr["area"]),
                            PoDate = Convert.ToDateTime(dr["PoDate"]),
                            DelDate = Convert.ToDateTime(dr["DelDate"]),
                            Inactive = Convert.ToBoolean(dr["Inactive"]),
                            Total = Convert.ToDouble(dr["Total"]),
                            SmtStatus = Convert.ToInt16(dr["Smtstatus"]),
                        });


                }
                return getlist;


            }
            catch (Exception)
            {

                return null;

            }
        }
        public List<T_PR> SearchT_PoJOBPR(string Search)
        {
            try
            {
                connection();

                List<T_PR> getlist = new List<T_PR>();
                string GetQuery = "select pr.PR_no as prNo,pr.Area as prarea ,pr.PR_date as prDate , pr.Inactive as InactivePR,pr.Total as totalPR,pr.SmtStatus as smtStatusPR from ShowPR as pr where pr.PR_job LIKE '%"+Search+"%' Order By pr.SmtStatus";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();





                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist.Add(
                        new T_PR
                        {
                            PR_no = Convert.ToString(dr["prNo"]),
                            Area = Convert.ToString(dr["prarea"]),
                            PR_date = Convert.ToDateTime(dr["prDate"]),
                            InactivePR = Convert.ToInt16(dr["InactivePR"]),
                            Total = Convert.ToDouble(dr["totalPR"]),
                            SmtStatus = Convert.ToInt16(dr["smtStatusPR"]),

                        });



                }
                return getlist;


            }
            catch (Exception)
            {

                return null;

            }
        }
        public List<T_PR> GetT_PR()
        {
            try
            {
                connection();

                List<T_PR> getlist = new List<T_PR>();
                string GetQuery = "select pr.PR_no as prNo,pr.Area as prarea ,pr.PR_date as prDate , pr.Inactive as InactivePR,pr.Total as totalPR,pr.SmtStatus as smtStatusPR from ShowPR as pr Order By pr.SmtStatus";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();





                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist.Add(
                        new T_PR
                        {
                            PR_no = Convert.ToString(dr["prNo"]),
                            Area = Convert.ToString(dr["prarea"]),
                            PR_date = Convert.ToDateTime(dr["prDate"]),
                            InactivePR = Convert.ToInt16(dr["InactivePR"]),
                            Total = Convert.ToDouble(dr["totalPR"]),
                            SmtStatus = Convert.ToInt16(dr["smtStatusPR"]),

                        });


                }
                return getlist;


            }
            catch (Exception)
            {

                return null;

            }



        }
        public List<T_PR> SearchT_PR(string Search)
        {
            try
            {
                connection();

                List<T_PR> getlist = new List<T_PR>();
                string GetQuery = "select pr.PR_no as prNo,pr.Area as prarea ,pr.PR_date as prDate , pr.Inactive as InactivePR,pr.Total as totalPR,pr.SmtStatus as smtStatusPR from ShowPR as pr where pr.PR_no LIKE '%"+Search+"%' Order By pr.SmtStatus";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();





                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist.Add(
                        new T_PR
                        {
                            PR_no = Convert.ToString(dr["prNo"]),
                            Area = Convert.ToString(dr["prarea"]),
                            PR_date = Convert.ToDateTime(dr["prDate"]),
                            InactivePR = Convert.ToInt16(dr["InactivePR"]),
                            Total = Convert.ToDouble(dr["totalPR"]),
                            SmtStatus = Convert.ToInt16(dr["smtStatusPR"]),

                        });


                }
                return getlist;


            }
            catch (Exception)
            {

                return null;

            }

        }
        public bool EditDt(PoandPoApp poandPoApp,int byid)
        {
            try
            {
                DateTime dt = DateTime.Now;
                connection();

                string QueryEdit = "update T_PoApp set SmtStatus = '2',AppBy = '"+ byid + "' ,AppDate = '"+dt+"'  where PoNo = '"+poandPoApp.PoNo+"'";

                SqlCommand cmd = new SqlCommand(QueryEdit, conn);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i >= 1)
                {

                    return true;


                }
                else
                {

                    return false;

                }
            }
            catch (Exception)
            {

                return false;

            }

        }
        public List<PoandPoApp> GetT_PoandPoApp()
        {
            try
            {
                connection();

                List<PoandPoApp> getlist = new List<PoandPoApp>();
                string GetQuery = "select po.PoNo as poNo,po.Area as area, po.PoDate as PoDate , po.DelDate as DelDate , po.Inactive as Inactive,po.Total as Total ,po.SmtStatus as Smtstatus from ShowPO as po  where po.PoNo != '' ";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist.Add(
                        new PoandPoApp
                        {
                            PoNo = Convert.ToString(dr["poNo"]),
                            Area = Convert.ToString(dr["area"]),
                            PoDate = Convert.ToDateTime(dr["PoDate"]),
                            DelDate = Convert.ToString(dr["DelDate"]),
                            Inactive = Convert.ToBoolean(dr["Inactive"]),
                            Total = Convert.ToString(dr["Total"]),
                            SmtStatus = Convert.ToInt16(dr["Smtstatus"]),

                        });


                }
                return getlist;


            }
            catch (Exception)
            {

                return null;

            }
        }
        public List<PRandPRApp> GetT_PRandPrApp()
        {
            try
            {
                connection();

                List<PRandPRApp> getlist = new List<PRandPRApp>();
                string GetQuery = "select pr.PR_no as prNo,pr.Area as prarea ,pr.PR_date as prDate , pr.Inactive as InactivePR,pr.Total as totalPR,pr.SmtStatus as smtStatusPR from ShowPR as pr  where pr.PR_no != '' ";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist.Add(
                        new PRandPRApp
                        {
                            PR_no = Convert.ToString(dr["prNo"]),
                            Area = Convert.ToString(dr["prarea"]),
                            PR_date = Convert.ToDateTime(dr["prDate"]),
                            InactivePR = Convert.ToInt16(dr["InactivePR"]),
                            Total = Convert.ToString(dr["totalPR"]),
                            SmtStatus = Convert.ToInt16(dr["smtStatusPR"]),

                        });


                }
                return getlist;


            }
            catch (Exception)
            {

                return null;

            }


        }
        public bool EditPR(PRandPRApp prandprapp, int byid)
        {
            DateTime dt = DateTime.Now;
            try
            {
                connection();
                
                string QueryEdit = "update T_PR_App set SmtStatus = '2', AppBy = '"+ byid + "', AppDate = '"+ dt + "' where PR_no = '" + prandprapp.PR_no + "'";

                SqlCommand cmd = new SqlCommand(QueryEdit, conn);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i >= 1)
                {

                    return true;


                }
                else
                {

                    return false;

                }
            }
            catch (Exception)
            {

                return false;

            }

        }
        public bool Holding(PoandPoApp PoNo)
        {
                try
                {
                    connection();

                    string QueryEdit = "update T_PoApp set SmtStatus = '3' where PoNo = '" + PoNo.PoNo + "'";

                    SqlCommand cmd = new SqlCommand(QueryEdit, conn);
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (i >= 1)
                    {

                        return true;

                    }
                    else
                    {

                        return false;

                    }
                }
                catch (Exception)
                {

                    return false;

                }

        }
        public bool HoldingPR(PRandPRApp PR_no)
        {

            try
            {
                connection();

                string QueryEdit = "update T_PR_App set SmtStatus = '3' where PR_no = '" + PR_no.PR_no + "'";

                SqlCommand cmd = new SqlCommand(QueryEdit, conn);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    return false;

                }
            }
            catch (Exception)
            {

                return false;

            }

        }
        public bool RejectPo(PoandPoApp PoNo)
        {

            try
            {
                connection();

                string QueryEdit = "update T_PoApp set SmtStatus = '4' where PoNo = '" + PoNo.PoNo + "'";

                SqlCommand cmd = new SqlCommand(QueryEdit, conn);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    return false;

                }
            }
            catch (Exception)
            {

                return false;

            }

        }
        public bool RejectPR(PRandPRApp PR_no)
        {

            try
            {
                connection();

                string QueryEdit = "update T_PR_App set SmtStatus = '4' where PR_no = '" + PR_no.PR_no + "'";

                SqlCommand cmd = new SqlCommand(QueryEdit, conn);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    return false;

                }
            }
            catch (Exception)
            {

                return false;

            }

        }
        public List<RejectPO> GetTPO_Reject()
        {
            try
            {
                connection();
                List<RejectPO> getlist = new List<RejectPO>();

                string GetQuery = "select po.T_Po as poarea ,po.T_PoApp as poaarea ,po.SmtStatus as smt from RejectPO as po";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();


                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist.Add(
                        new RejectPO
                        {

                            Area = Convert.ToString(dr["poarea"]),
                            SmtStatus = Convert.ToInt16(dr["smt"]),

                        });


                }
                return getlist;



            }
            catch (Exception)
            {

                return null;

            }
        }
        public List<RejectPR> GetTPR_Reject()
        {
            try
            {
                connection();
                List<RejectPR> getlist = new List<RejectPR>();

                string GetQuery = "select pr.T_Pr as prarea ,pr.T_PR_App as praarea ,pr.SmtStatus as smt from RejectPR as pr";
                SqlCommand cmd = new SqlCommand(GetQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();


                conn.Open();
                adapter.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    getlist.Add(
                        new RejectPR
                        {

                            Area = Convert.ToString(dr["prarea"]),
                            SmtStatus = Convert.ToInt16(dr["smt"]),

                        });


                }
                return getlist;



            }
            catch (Exception)
            {

                return null;

            }
        }

    }
}
