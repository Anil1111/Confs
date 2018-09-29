using Domain.Entities;
using MVC.Helpers;
using MVC.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ConferenceController : Controller
    {

        // GET: ReservationEvent
        IConferenceService resEvSer = null;
        IEmployeeService EmpServ = null;
        IAssignEmployee assSer = null;
        public ConferenceController()
        {

            resEvSer = new ConferenceService();
            EmpServ = new EmployeeService();
            assSer = new AssignEmployee();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        resEvSer.Dispose();
        //    }
        //    base.Dispose(disposing);

        //}
        public ActionResult Index()
        {
            var x = resEvSer.getAll();


            return View(x);
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var x = resEvSer.getAll();

            if (!String.IsNullOrEmpty(searchString)) { x = x.Where(m => m.subject.Contains(searchString)).ToList(); }
            return View(x);
        }
        /*************************************************/
        public ActionResult listEmpByConf(int idConf)
        {
            var x = assSer.ListEmpByConf(idConf);


            return View(x);
        }


        /********************************************************/

        public ActionResult AssignEmp(int id)
        {

            ViewBag.z = id;
            var x = EmpServ.getAll();
            return View(x);
        }
       
        public ActionResult sortBySalary(int idConf)
        {
            ViewBag.z = idConf;
            var x = EmpServ.sortBySalary();


            return View(x);
        }
        /****************************************************/
        public ActionResult AssignThisEmp(int idConf,int id)
        {
            ViewBag.z = idConf;
            var x = new ConferenceEmployee {
                idConference= idConf,
                idEmp=id
            };
            ConferenceEmployee y = assSer.getByIds(idConf, id);
            if (y == null)
            {
                assSer.Add(x);
                assSer.Commit();
                assSer.Dispose();
                ViewBag.msg = "Employé Invité";
   

            }
            else
            {
                ViewBag.err = "L'employé est déjà assigné à cette conférence";
            }
      
            
            
            return View();
        }

        /**************************************************************/
        public ActionResult RetractThisEmp(int idConf, int id )
        {
            ViewBag.z = idConf;
            return View();

        }
        /**************************************************************/
        [HttpPost]
        public ActionResult RetractThisEmp(int idConf, int id,EmployeeModel EM)
        {
            ViewBag.z = idConf;
            
            ConferenceEmployee RE = assSer.getByIds(idConf, id);
            if (RE == null)
            {
                ViewBag.err = "employé n'est pas assigné à cette conférence";


            }
            else
            {
               ViewBag.a= RE.ToString();
                ViewBag.msg = "Employé exclu de la conférence";
                assSer.Delete(RE);
                resEvSer.Commit();

            }





            return View();
        }
        /***************************************************************/

        // GET: ReservationEvent/Details/5
        public ActionResult Details(int id)
        {
            Conference RE = resEvSer.GetById(id);
            return View(RE);
        }

        // GET: ReservationEvent/Create
        public ActionResult Create()
        {
            List<String> listMovies = new List<string> { "Obligatoire", "Facultative" };
            IEnumerable<SelectListItem> x = listMovies.DropDownList();
            ViewBag.l = x;
            return View();
        }

        // POST: ReservationEvent/Create
        [HttpPost]
        public ActionResult Create(ConferenceModel REM)
        {
        

            Conference RE = new Conference
            {
                subject = REM.subject,
                lieu = REM.lieu,
                dateConference =REM.dateConference,
               rate=REM.rate,
               typeConference=REM.typeConference
              
            };



            resEvSer.Add(RE);
            resEvSer.Commit();
            resEvSer.Dispose();

            RedirectToAction("Index");
            return View();
        }




        //GET: ReservationEvent/Edit/5
        public ActionResult Edit(int id)
        {
            Conference RE = resEvSer.GetById(id);
            ConferenceModel REM = new ConferenceModel
            {
               subject=RE.subject,
               lieu=RE.lieu,
               dateConference=RE.dateConference,
               rate=RE.rate,
               typeConference=RE.typeConference
            };

            return View(REM);

        }
        // POST: ReservationEvent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ConferenceModel REM)
        {
            Conference RE = resEvSer.GetById(id);

            try
            {
                resEvSer.Update(RE);
                UpdateModel(RE);

                resEvSer.Commit();
                return RedirectToAction("Index");


            }
            catch
            {


                return View(RE);
            }


        }

        // GET: ReservationEvent/Delete/5
        public ActionResult Delete(int id)
        {
            Conference RE = resEvSer.GetById(id);
            if (RE == null)
            {
                return HttpNotFound();
            }
            ConferenceModel REM = new ConferenceModel
            {
                subject = RE.subject,
                lieu = RE.lieu,
                dateConference = RE.dateConference,
                rate = RE.rate,
                typeConference =RE.typeConference



            };

            return View(REM);
        }


        // POST: ReservationEvent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ConferenceModel REM)
        {
            Conference RE = resEvSer.GetById(id);


            resEvSer.Delete(RE);
            resEvSer.Commit();
            return RedirectToAction("Index");



        }
 
   

        /*******************************************STATS******************************************/
        public ActionResult ConfByDateChart()
        {
            ViewBag.jan = resEvSer.confJan();
            ViewBag.fev = resEvSer.confFev();
            ViewBag.mar = resEvSer.confMar();
            ViewBag.avr = resEvSer.confAvr();
            ViewBag.mai = resEvSer.confMai();
            ViewBag.jun = resEvSer.confJun();
            ViewBag.jul = resEvSer.confJul();
            ViewBag.aot = resEvSer.confAout();
            ViewBag.sep = resEvSer.confSep();
            ViewBag.oct = resEvSer.confOct();
            ViewBag.nov = resEvSer.confNov();
            ViewBag.dec = resEvSer.confDec();
          
            return View();

        }

        public ActionResult ConfByType()
        {
            ViewBag.obl = resEvSer.confOblg();
            ViewBag.fac = resEvSer.confFac();
       

            return View();

        }

        public ActionResult EmpByConfType()
        {
            ViewBag.Fact = assSer.NumberEmplByConTypeFacultative();
            ViewBag.oblg = assSer.NumberEmplByConTypeObligatoire();


            return View();

        }
    }
}