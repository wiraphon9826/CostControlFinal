using CostControlWebsite.Models;
using CostControlWebsite.QueryAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CostControlWebsite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult LoginIndex()
        {
            if (Session["User_name"] != null || Session["User_name2"] != null)
            {
                Session["User_name2"] = null;
                Session["User_name"] = null;
            }


            return View();
        }
        [HttpPost]
        public ActionResult LoginIndex(T_Admin t_Admin)
        {
            

            QueryCRUD query = new QueryCRUD();
            
            bool chk = query.CheckLogin(t_Admin.User_name, t_Admin.Password);
            List<T_Admin> listTic = new List<T_Admin>();
            QueryCRUD qr = new QueryCRUD();

            bool chkadmin = query.CheckAdmin(t_Admin.User_name, t_Admin.Password);
            if (t_Admin.User_name != null )
            {
                if (t_Admin.Password != null) { 

                    if (chk == true)
            {
                if (chkadmin == true)
                {
                    TempData["User_name"] = t_Admin.User_name;
                    Session["User_name"] = t_Admin.User_name;
                   
                    Session["Type"] = listTic;
                }
                else {


                    Session["User_name2"] = t_Admin.User_name;


                }
                

                 return RedirectToAction("Index", "Show");

            }
            else
            {
                TempData["message"] = "User And Password Invalid";
                return View();

            }
                }
                else {
                    TempData["mgs"] = "Please Input Data !!!";
                    return View();
                }
            }
            else {

                TempData["mgs"] = "Please Input Data !!!";
                return View();



            }


        }
    }
}