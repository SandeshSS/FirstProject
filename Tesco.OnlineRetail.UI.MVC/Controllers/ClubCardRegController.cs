using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Tesco.OnlineRetail.Business;
using Tesco.OnlineRetail.Data.EFRepository;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.UI.MVC.Controllers
{
    public class ClubCardRegController : Controller
    {
        private IClubCardRegManager clubcardMgr = null;
        private ICustomerManager customerMgr = null;
        

       
       
        private EntityContext db = new EntityContext();
        public ClubCardRegController(IClubCardRegManager clubcardMgr, ICustomerManager customerMgr)
        {
            this.clubcardMgr = clubcardMgr;
            this.customerMgr = customerMgr;
        }

        




        public ClubCardRegController(IClubCardRegManager clubcardMgr)
        {
            this.clubcardMgr = clubcardMgr;
        }



        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
                
        public ActionResult Create()
        {
            IList<Customer> listcust = customerMgr.GetCustomers().ToList<Customer>();
            if (User.Identity.Name.Length > 0)
            {
                Customer c = (from cust in listcust
                              where cust.EmailId == User.Identity.Name
                              select cust).FirstOrDefault<Customer>();

                Session["custid"] = c.CustomerID;
                Session["custname"] = c.CustomerName;
            }


            return View();
        }

        [HttpPost]
        public ActionResult Create(ClubCardReg clubcardreg)
        {
            clubcardreg.CustomerID = int.Parse(Session["custid"].ToString());
            

            try
            {
                if (ModelState.IsValid)
                {
                    Random rnd = new Random();

                    Int32 x = rnd.Next();

                    clubcardreg.ClubCardNumber = Convert.ToString(x);


                    clubcardMgr.SaveClubCardReg(clubcardreg);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(null, ex.Message);
                throw;
            }

            return View(clubcardreg);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubCardReg cat = db.ClubCardRegs.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }
        public ActionResult Show()
        {
            return View();
        }

    }
}