using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesco.OnlineRetail.Business;
using Tesco.OnlineRetail.Data.EFRepository;
using Tesco.OnlineRetail.Models;

namespace Tesco.OnlineRetail.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryManager CategoryMgr = null;
        
        private EntityContext db = new EntityContext();
        private ICustomerManager custmgr = null;

        public HomeController(ICategoryManager categoryMgr,  ICustomerManager custmgr)
        {
            this.custmgr = custmgr;
            this.CategoryMgr = categoryMgr;
            
        }

        public IEnumerable<Category> getCategoryList()
        {

            var categories = CategoryMgr.GetCategories().ToList<Category>();
            
            IEnumerable<Category> value = (IEnumerable<Category>)from cat in categories

                                                                 select cat;

            return value;

        }


        

       

        public ActionResult Index()
        {
            List<Customer> listcust = custmgr.GetCustomers().ToList<Customer>();
            if (User.Identity.Name.Length > 0)
            {
                Customer c = (from cust in listcust
                              where cust.EmailId == User.Identity.Name
                              select cust).FirstOrDefault<Customer>();

                Session["custid"] = c.CustomerID;
                Session["custname"] = c.CustomerName;
            }

            if (User.Identity.Name == "sanadmin@gmail.com")
            {                
                return RedirectToAction("AdminIndex");
            }
            else
                return View(getCategoryList());
        }

        public ActionResult AdminIndex()
        {
            return View();
        }     

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult AboutClubCard()
        {
            return View();
        }

        [Authorize]
        public ActionResult ClubCard()
        {
            return View();
        }
    }
}