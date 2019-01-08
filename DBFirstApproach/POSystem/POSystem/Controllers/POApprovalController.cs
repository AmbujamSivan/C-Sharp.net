
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSystem.Models;

namespace POSystem.Controllers
{
    public class POApprovalController : Controller
    {

        private EForms_DevEntities db = new EForms_DevEntities();

        // GET: POApproval
        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ApprovalViewModal AVM = new ApprovalViewModal();
            AVM.PO = getPODetails(id);
            AVM.POItem = getPOItemDetails(id);
            if (AVM.PO == null )
            {
                return HttpNotFound();
            }
            return View(AVM);
        }

      
        public PurchaseOrder getPODetails (int? id)
        {
            
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);           
            return purchaseOrder;
        }

        public PurchaseOrderItem getPOItemDetails(int? id)
        {

            PurchaseOrderItem purchaseOrderItem = db.PurchaseOrderItems.Find(id);
            return purchaseOrderItem;
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