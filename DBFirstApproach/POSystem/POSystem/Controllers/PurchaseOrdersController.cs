using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POSystem.Models;

namespace POSystem.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        private EForms_DevEntities db = new EForms_DevEntities();

        // GET: PurchaseOrders
        public ActionResult Index(String id, String PoStatus)
        {
            var statusLst = new List<String>();

            var statusQry = from status in db.PurchaseOrders
                            orderby status.CurrentRequestStatus
                            select status.CurrentRequestStatus;
            statusLst.AddRange(statusQry.Distinct());
            ViewBag.ReqStatus = new SelectList(statusLst);

            String searchValue = id;
            var po = from p in db.PurchaseOrders                     
                     select p;


          //  po = po.Where(d => d.DateRequested > DateTime.Today.AddDays(-365));

            //for requester search
          if (!String.IsNullOrEmpty(searchValue))
            {
                po = po.Where(s => s.EmployeeName.Contains(searchValue));
                // orderby p.DateRequested ascending, p.DateNeeded ascending
               
            }
            //for status search
            if (!string.IsNullOrEmpty(PoStatus))
            {
                po = po.Where(x => x.CurrentRequestStatus == PoStatus);
            }
            

            return View(po);
        }

        // GET: PurchaseOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseOrder_PK,CountyName,DateRequested,DateNeeded,Program,BudgetNumber,VendorName,VendorPhone,VendorAddress,VendorCity,VendorState,VendorZip,EmployeeName,RequesterNetworkID,SuperID,DirectorID,RequesterApprovalDt,SupervisorApprovalDt,ApprovedBy,DirectorApprovalDt,CurrentRequestStatus,SuperExplain,GeneralComments,ObligationNumber,WorkOrder_FK,Cost_FK,APProcessedDt,APProcessedBy,APComments,AlsoNotify,Instructions")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrders.Add(purchaseOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseOrder_PK,CountyName,DateRequested,DateNeeded,Program,BudgetNumber,VendorName,VendorPhone,VendorAddress,VendorCity,VendorState,VendorZip,EmployeeName,RequesterNetworkID,SuperID,DirectorID,RequesterApprovalDt,SupervisorApprovalDt,ApprovedBy,DirectorApprovalDt,CurrentRequestStatus,SuperExplain,GeneralComments,ObligationNumber,WorkOrder_FK,Cost_FK,APProcessedDt,APProcessedBy,APComments,AlsoNotify,Instructions")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            db.PurchaseOrders.Remove(purchaseOrder);
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
