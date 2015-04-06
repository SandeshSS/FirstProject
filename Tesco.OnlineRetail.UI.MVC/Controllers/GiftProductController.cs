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
    public class GiftProductController : Controller
    {
        private IGiftProductManager ProductMgr = null;
        private IGiftProductCategoryManager CategoryMgr = null;
        private EntityContext db = new EntityContext();

        public GiftProductController(IGiftProductManager ProductMgr, IGiftProductCategoryManager CategoryMgr)
        {
            this.ProductMgr = ProductMgr;
            this.CategoryMgr = CategoryMgr;
        }

        public ActionResult Index(int? page)
        {
            List<GiftProduct> Products = ProductMgr.GetGiftProducts().ToList<GiftProduct>();

            //  return View(Products);

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Products.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            fetch();
            return View();
            }

       
        [HttpPost]
        public ActionResult Create(GiftProduct product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<GiftProduct> products = ProductMgr.GetGiftProducts().ToList<GiftProduct>();
                    var values1 =
                    (from c in products
                     where c.Name == product.Name
                     select c).Count();

                    if (values1 <= 0)
                    {

                        ProductMgr.SaveGiftProduct(product);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = product.Name + " already exists";

                    }


                }
            }
            catch (Exception ex)
            {
                // return RedirectToAction("Create");
                ModelState.AddModelError(null, ex.Message);
                throw;
            }

            return View(product);
        }
        


        private void fetch()
        {
            var categories = CategoryMgr.GetGiftProductCategorys().ToList<GiftProductCategory>();
            IEnumerable<SelectListItem> values =
                from c in categories
                select new SelectListItem
                {
                    Text = c.GiftCategoryName.ToString(),
                    Value = c.GiftProductCategoryId.ToString()
                };

            ViewBag.GiftCategoryItems = values;
        }

        public ActionResult Details(int id)
        {
            GiftProduct productInfo = db.GiftProducts.Find(id);
            if (productInfo == null)
        {
                return HttpNotFound();
            }
            return View(productInfo);
            }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftProduct productInfo = db.GiftProducts.Find(id);
            if (productInfo == null)
            {
                return HttpNotFound();
            }
            return View(productInfo);
        }

        // POST: ProductInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiftProduct productInfo = db.GiftProducts.Find(id);
            db.GiftProducts.Remove(productInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
            }
        }
      