using CostControlWebsite.Models;
using CostControlWebsite.QueryAll;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CostControlWebsite.Controllers;
using CostControlWebsite;
using System.Dynamic;

namespace CostControlWebsite.Controllers
{
    public class ShowController : Controller
    {

        private T_Po po = new T_Po();

        // GET: Show
        public ActionResult Index()
        {

            List<T_PoJoinPR> listTic = new List<T_PoJoinPR>();
            List<HoldingPO> listTic2 = new List<HoldingPO>();
            List<HoldingPR> listTic3 = new List<HoldingPR>();
            List<RejectPO> listTic4 = new List<RejectPO>();
            List<RejectPR> listTic5 = new List<RejectPR>();
            QueryCRUD qr = new QueryCRUD();

            listTic = qr.GetTPO();

            listTic2 = qr.GetTPOHolding();
            listTic3 = qr.GetT_PRHolding();
            listTic4 = qr.GetTPO_Reject();
            listTic5 = qr.GetTPR_Reject();

            if (listTic.Count == 0) {
                ViewBag.sumpo = "0";
                ViewBag.sumpr = "0";
            }
            listTic.ForEach((l) => {
                if (l.T_Po != null)
                {
                    ViewBag.sumpo = l.T_Po;
                    if (l.T_Po == "")
                    {
                        ViewBag.sumpo = "0";
                    }
                }
                if (l.T_PR != null)
                {
                    ViewBag.sumpr = l.T_PR;
                    if (l.T_PR == "")
                    {
                        ViewBag.sumpr = "0";
                    }
                }
            });
            try {
                if (listTic2.Count == 0)
                {

                    ViewBag.sumhopo = "0";
                }

                listTic2.ForEach((i) =>
                {
                    if (i.Area != null)
                    {
                        ViewBag.sumhopo = i.Area;
                    }
                });
                if (listTic3.Count == 0)
                {
                    ViewBag.sumhopr = "0";
                }
                listTic3.ForEach((li) => {

                    if (li.Area != null)
                    {

                        ViewBag.sumhopr = li.Area;
                    }
                });
            } catch {
                return View();
            }
            try
            {
                if (listTic4.Count == 0)
                {

                    ViewBag.sumrepo = "0";
                }

                listTic4.ForEach((s) =>
                {
                    if (s.Area != null)
                    {
                        ViewBag.sumrepo = s.Area;
                    }
                });
                if (listTic5.Count == 0)
                {
                    ViewBag.sumrepr = "0";
                }
                listTic5.ForEach((si) => {

                    if (si.Area != null)
                    {

                        ViewBag.sumrepr = si.Area;
                    }
                });
            }
            catch
            {
                return View();
            }



            return View(listTic);
        }
        public ActionResult ShowPo()
        {
            ViewBag.Po = "Search";

            dynamic listTicPO = new ExpandoObject();
            QueryCRUD qr = new QueryCRUD();
            List<T_Po> listTic = qr.GetT_Po();  
            listTicPO.T_Po = listTic;
            listTicPO.T_Job = qr.listjob();
            return View(listTicPO);


        }
        public ActionResult ShowPR()
        {
            ViewBag.PR = "Search";
            dynamic listTicPR = new ExpandoObject();
            QueryCRUD qr = new QueryCRUD();
            List<T_PR> listTic = qr.GetT_PR();
            listTicPR.T_Pr = listTic;
            listTicPR.T_Job = qr.listjobPR();
            return View(listTicPR);

        }
        [HttpGet]
        public ActionResult Holding(string PoNo)
        {
            QueryCRUD qr = new QueryCRUD();

            return PartialView(qr.GetT_PoandPoApp().Find(ID => ID.PoNo == PoNo));


        }
        [HttpPost]
        [ActionName("Holding")]
        public ActionResult Holding(PoandPoApp poandPoApp)
        {
            QueryCRUD qr = new QueryCRUD();
            if (qr.Holding(poandPoApp))
            {

                return RedirectToAction("ShowPo");

            }



            return View();
        }
        [HttpGet]
        public ActionResult HoldingPR(string PR_no)
        {
            QueryCRUD qr = new QueryCRUD();

            return PartialView(qr.GetT_PRandPrApp().Find(ID => ID.PR_no == PR_no));


        }
        [HttpPost]
        [ActionName("HoldingPR")]
        public ActionResult HoldingPR(PRandPRApp prandPRApp)
        {
            QueryCRUD qr = new QueryCRUD();
            if (qr.HoldingPR(prandPRApp))
            {

                return RedirectToAction("ShowPR");


            }



            return View();
        }



        [HttpGet]
        [ActionName("Approved")]
        public ActionResult Approved(string PoNo)
        {
            QueryCRUD qr = new QueryCRUD();

            return PartialView(qr.GetT_PoandPoApp().Find(ID => ID.PoNo == PoNo));


        }
        [HttpPost]
        [ActionName("Approved")]
        public ActionResult Approved(PoandPoApp poandPoApp,T_Admin t_Admin)
        {
           
             QueryCRUD qr = new QueryCRUD();
            T_Admin t_Admins = new T_Admin();
            if (Session["User_name"] != null)
            {

                t_Admin.User_name = Session["User_name"].ToString();
                t_Admins = qr.Get_T_Admins(t_Admin.User_name);
                
                int byid = t_Admins.User_ID ;

                if (qr.EditDt(poandPoApp,byid))
                {

                    return RedirectToAction("ShowPo");


                }

            }

            return View();
        }
        [HttpGet]
        [ActionName("ApprovedPR")]
        public ActionResult ApprovedPR(string PR_no)
        {
            QueryCRUD qr = new QueryCRUD();

            return PartialView(qr.GetT_PRandPrApp().Find(ID => ID.PR_no == PR_no));


        }
        [HttpPost]
        [ActionName("ApprovedPR")]
        public ActionResult ApprovedPR(PRandPRApp prandpra,T_Admin t_Admin)
        {
          

            QueryCRUD qr = new QueryCRUD();
            T_Admin t_Admins = new T_Admin();
            if (Session["User_name"] != null)
            {

                t_Admin.User_name = Session["User_name"].ToString();
                t_Admins = qr.Get_T_Admins(t_Admin.User_name);

                int byid = t_Admins.User_ID;

                if (qr.EditPR(prandpra,byid))
                {
                    return RedirectToAction("ShowPR");

                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult ReJectPO(string PoNo)
        {
            QueryCRUD qr = new QueryCRUD();

            return PartialView(qr.GetT_PoandPoApp().Find(ID => ID.PoNo == PoNo));


        }
        [HttpPost]
        [ActionName("ReJectPO")]
        public ActionResult ReJectPO(PoandPoApp poandPoApp)
        {
            QueryCRUD qr = new QueryCRUD();
            if (qr.RejectPo(poandPoApp))
            {

                return RedirectToAction("ShowPo");


            }



            return View();
        }
        [HttpGet]

        public ActionResult ReJectPR(string PR_no)
        {
            QueryCRUD qr = new QueryCRUD();

            return PartialView(qr.GetT_PRandPrApp().Find(ID => ID.PR_no == PR_no));


        }
        [HttpPost]
        [ActionName("ReJectPR")]
        public ActionResult ReJectPR(PRandPRApp prandpra)
        {
            QueryCRUD qr = new QueryCRUD();

            if (qr.RejectPR(prandpra))
            {
                return RedirectToAction("ShowPR");

            }
            return View();
        }

        [HttpPost]
        [ActionName("Search")]
        public ActionResult Search(string Search)
        {
            dynamic listTicPO = new ExpandoObject();
          
            QueryCRUD qr = new QueryCRUD();
            List<T_Po> listTic = qr.SearchT_Po(Search);
            

            listTicPO.T_Po = listTic;
            listTicPO.T_Job = qr.listjob();

          

            if (Search == "")
            {
               
                dynamic listTicPOn = new ExpandoObject();
                List<T_Po> listTicPo = qr.GetT_Po();
                listTicPOn.T_Po = listTicPo;
                listTicPOn.T_Job = qr.listjob();
                return View("ShowPo", listTicPOn);
            }



            ViewBag.Po = Search;
            return View("ShowPo", listTicPO);


        }
        [HttpPost]
        [ActionName("SearchPR")]
        public ActionResult SearchPR(string Search)
        {


            if (Search == "")
            {
                ViewBag.PR = "Search";
                dynamic listTicPR = new ExpandoObject();
                QueryCRUD qr = new QueryCRUD();
                List<T_PR> listTic = qr.GetT_PR();
                listTicPR.T_Pr = listTic;
                listTicPR.T_Job = qr.listjobPR();
                return View("ShowPR", listTicPR);
            }
            else {
                dynamic listTicPR = new ExpandoObject();
                QueryCRUD qr = new QueryCRUD();
                List<T_PR> listTic = qr.SearchT_PR(Search);
                listTicPR.T_Pr = listTic;
                listTicPR.T_Job = qr.listjobPR();


                return View("ShowPR", listTicPR);

            }

        }
        [HttpGet]
        [ActionName("GetReport")]
        public ActionResult GetReport(string PoNo)
        {
            string ReportURL = PoNo;
            byte[] FileBytes = new byte[10000];
            try {
             ReportURL = "C:\\Users\\wirap\\Desktop\\CostControl\\CostControlWebsite\\CostControlWebsite\\ReportPDF\\PO_" + PoNo+".pdf";
             FileBytes = System.IO.File.ReadAllBytes(ReportURL);
             return File(FileBytes, "application/pdf");
             } catch {

              return File(FileBytes, "application/pdf");

            }
            



        }
        [HttpGet]
        [ActionName("GetReportPR")]
        public ActionResult GetReportPR(string PR_no)
        {
            string ReportURL = PR_no;
            byte[] FileBytes = new byte[10000];
            try
            {
                ReportURL = "C:\\Users\\wirap\\Desktop\\CostControl\\CostControlWebsite\\CostControlWebsite\\ReportPDF\\PR_" + PR_no + ".pdf";
                FileBytes = System.IO.File.ReadAllBytes(ReportURL);
                return File(FileBytes, "application/pdf");
            }
            catch
            {

                return File(FileBytes, "application/pdf");

            }




        }
        [HttpGet]
        [ActionName("SearchJob")]
        public ActionResult SearchJob(string SearchJob)
        {
            dynamic listTicPO = new ExpandoObject();
            dynamic listTicPOn = new ExpandoObject();
            QueryCRUD qr = new QueryCRUD();
            List<T_Po> listTic = qr.SearchT_PoJOB(SearchJob);
            


            listTicPO.T_Po = listTic;
            listTicPO.T_Job = qr.listjob();
           

            if (SearchJob == "")
            {
                TempData["SearchJob"] = "";

                listTicPOn.T_Po = qr.GetT_Po();
                listTicPOn.T_Job = qr.listjob();

                return View("ShowPo", listTicPOn);
            }


            return View("ShowPo", listTicPO);


        }
        [HttpGet]
        [ActionName("SearchJobPR")]
        public ActionResult SearchJobPR(string SearchJob)
        {
            dynamic listTicPR = new ExpandoObject();
            dynamic listTicPRn = new ExpandoObject();
            QueryCRUD qr = new QueryCRUD();
            List<T_PR> listTic = qr.SearchT_PoJOBPR(SearchJob);



            listTicPR.T_Pr = listTic;
            listTicPR.T_Job = qr.listjobPR();


            if (SearchJob == "")
            {
                TempData["SearchJob"] = "";

                listTicPRn.T_Pr = qr.GetT_PR();
                listTicPRn.T_Job = qr.listjobPR();

                return View("ShowPR", listTicPRn);
            }


            return View("ShowPR", listTicPR);


        }


    }

    }
