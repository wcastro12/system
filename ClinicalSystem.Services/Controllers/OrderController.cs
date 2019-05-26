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
    public class OrderController : Controller
    {
        private OrderFacade db = new OrderFacade();
        private PatientFacade pf = new PatientFacade();
        // GET: Order
        public ActionResult Index()
        {

            return View(db.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEntity orderEntity = db.Find(id);
            if (orderEntity == null)
            {
                return HttpNotFound();
            }
            return View(orderEntity);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.PatientID = new SelectList(pf.ToList(), "PatientID", "Name");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,OrderType,Description,Priority,State,Posology,Date,PatientID")] OrderEntity orderEntity)
        {
            if (ModelState.IsValid)
            {
                db.Add(orderEntity);
         
                return RedirectToAction("Index");
            }

            ViewBag.PatientID = new SelectList(pf.ToList(), "PatientID", "Name", orderEntity.PatientID);
            return View(orderEntity);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEntity orderEntity = db.Find(id);
            if (orderEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientID = new SelectList(pf.ToList(), "PatientID", "Name", orderEntity.PatientID);
            return View(orderEntity);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderType,Description,Priority,State,Posology,Date,PatientID")] OrderEntity orderEntity)
        {
            if (ModelState.IsValid)
            {
                db.Change(orderEntity);;
                return RedirectToAction("Index");
            }
            ViewBag.PatientID = new SelectList(pf.ToList(), "PatientID", "Name", orderEntity.PatientID);
            return View(orderEntity);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderEntity orderEntity = db.Find(id);
            if (orderEntity == null)
            {
                return HttpNotFound();
            }
            return View(orderEntity);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderEntity orderEntity = db.Find(id);
            db.Remove(orderEntity);
      
            return RedirectToAction("Index");
        }


    }
}
