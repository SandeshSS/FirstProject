using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tesco.OnlineRetail.Business;
using Tesco.OnlineRetail.Data.EFRepository;
using Tesco.OnlineRetail.Data.Repository;
using Tesco.OnlineRetail.Models;
using PagedList;

namespace Tesco.OnlineRetail.UI.MVC.Controllers
{
    public class GiftProductCategoryController : Controller
    {
       private IGiftProductCategoryManager CategoryMgr = null;
        private IGiftProductManager ProductMgr=null;
        EntityContext db = new EntityContext();
        public GiftProductCategoryController(IGiftProductCategoryManager CategoryMgr, IGiftProductManager ProductMgr)
        {
            this.CategoryMgr = CategoryMgr;
            this.ProductMgr = ProductMgr;
        }
        public IEnumerable<GiftProductCategory> getCategoryList()
        {

            var categories = CategoryMgr.GetGiftProductCategorys().ToList<GiftProductCategory>();
            var products = ProductMgr.GetGiftProductsList().ToList<GiftProduct>();
            IEnumerable<GiftProductCategory> value = (IEnumerable<GiftProductCategory>)from cat in categories

                                                                                       select cat;

            return value;

        }
        public JsonResult GetGiftProductlistByCatId(int id)
        {

            var products = ProductMgr.GetGiftProductsList().ToList<GiftProduct>();
            IEnumerable<GiftProduct> plist = (IEnumerable<GiftProduct>)from p in products
                                                                       where p.GiftProductCategoryId == id
                                                                       select p;

            return Json(plist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            GiftProduct productInfo = db.GiftProducts.Find(id);

            return View(productInfo);

        }

        [HttpPost]
        public ActionResult SearchProduct(string product)
        {
            var plist = db.GiftProducts.AsEnumerable();
            if (!string.IsNullOrEmpty(product))
                plist = from p in plist
                        where p.Name.Contains(product)
                        select p;

            //    return View(db.ProductInfoes.ToList());
            return View(plist.ToList());
        }

        // GET: Customer
        public ActionResult Index(int? page)
        {
            List<GiftProductCategory> categories = CategoryMgr.GetGiftProductCategorys().ToList<GiftProductCategory>();

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(categories.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GiftProductCategory Category)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    List<GiftProductCategory> categories = CategoryMgr.GetGiftProductCategorys().ToList<GiftProductCategory>();
                    var values1 =
                    (from c in categories
                     where c.GiftCategoryName == Category.GiftCategoryName 
                     select c).Count();

                    if(values1 <= 0)
                    { 
                        Category.IsActive = true;
                        CategoryMgr.SaveGiftProductCategory(Category);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = Category.GiftCategoryName + " already exists";
                    }

                    
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(null, ex.Message);
                throw;
            }

            return View(Category); 
        }

        public ActionResult GiftCategory()
        {
            return View(getCategoryList());     
        }
    }
}
   