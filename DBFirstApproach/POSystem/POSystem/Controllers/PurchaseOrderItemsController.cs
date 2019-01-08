using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using POSystem.Models;

namespace POSystem.Controllers
{
    public class PurchaseOrderItemsController : Controller
    {
        private EForms_DevEntities db = new EForms_DevEntities();

        // GET: PurchaseOrderItems
        public ActionResult Index()
        {
            return View(db.PurchaseOrderItems.ToList());
        }

        // GET: PurchaseOrderItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderItem purchaseOrderItem = db.PurchaseOrderItems.Find(id);
            if (purchaseOrderItem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrderItem);
        }

        // GET: PurchaseOrderItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseOrderItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PORequestItem_PK,PurchaseOrder_FK,ItemDescription,ItemQuantity,ItemPrice,ItemExtPrice")] PurchaseOrderItem purchaseOrderItem)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrderItems.Add(purchaseOrderItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaseOrderItem);
        }

        // GET: PurchaseOrderItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderItem purchaseOrderItem = db.PurchaseOrderItems.Find(id);
            if (purchaseOrderItem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrderItem);
        }

        // POST: PurchaseOrderItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PORequestItem_PK,PurchaseOrder_FK,ItemDescription,ItemQuantity,ItemPrice,ItemExtPrice")] PurchaseOrderItem purchaseOrderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseOrderItem);
        }

        // GET: PurchaseOrderItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderItem purchaseOrderItem = db.PurchaseOrderItems.Find(id);
            if (purchaseOrderItem == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrderItem);
        }

        // POST: PurchaseOrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrderItem purchaseOrderItem = db.PurchaseOrderItems.Find(id);
            db.PurchaseOrderItems.Remove(purchaseOrderItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
