using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicalSystem.Common.Context;
using SistemaClinico.Entities.Models;
using ClinicalSystem.Facade;

namespace ClinicalSystem.Services.Controllers
{
    public class ReasonController : Controller
    {
        private ReasonChangesFacade db = new ReasonChangesFacade();
        private OrderFacade of = new OrderFacade();

        // GET: Reason
        public ActionResult Index()
        {
       
            return View(db.ToList());
        }

        // GET: Reason/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReasonChangesEntity reasonChangesEntity = db.Find(id);
            if (reasonChangesEntity == null)
            {
                return HttpNotFound();
            }
            return View(reasonChangesEntity);
        }

        // GET: Reason/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(of.ToList(), "OrderID", "Description");
            return View();
        }

        // POST: Reason/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReasonChangesID,Description,Status,DateChanges,OrderID")] ReasonChangesEntity reasonChangesEntity)
        {
            if (ModelState.IsValid)
            {
                db.Add(reasonChangesEntity);
        
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(of.ToList(), "OrderID", "Description", reasonChangesEntity.OrderID);
            return View(reasonChangesEntity);
        }

        // GET: Reason/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReasonChangesEntity reasonChangesEntity = db.Find(id);
            if (reasonChangesEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(of.ToList(), "OrderID", "Description", reasonChangesEntity.OrderID);
            return View(reasonChangesEntity);
        }

        // POST: Reason/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReasonChangesID,Description,Status,DateChanges,OrderID")] ReasonChangesEntity reasonChangesEntity)
        {
            if (ModelState.IsValid)
            {
                db.Change(reasonChangesEntity);
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(of.ToList(), "OrderID", "Description", reasonChangesEntity.OrderID);
            return View(reasonChangesEntity);
        }

        // GET: Reason/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReasonChangesEntity reasonChangesEntity = db.Find(id);
            if (reasonChangesEntity == null)
            {
                return HttpNotFound();
            }
            return View(reasonChangesEntity);
        }

        // POST: Reason/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReasonChangesEntity reasonChangesEntity = db.Find(id);
            db.Remove(reasonChangesEntity);

            return RedirectToAction("Index");
        }


    }
}
