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
    public class PatientController : Controller
    {
        private PatientFacade db = new PatientFacade();
        private IpsFacade of = new IpsFacade();

        // GET: Patient
        public ActionResult Index()
        {
          
            return View(db.ToList());
        }

        // GET: Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientEntity patientEntity = db.Find(id);
            if (patientEntity == null)
            {
                return HttpNotFound();
            }
            return View(patientEntity);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            ViewBag.IpsID = new SelectList(of.ToList(), "IpsID", "Name");
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,Name,LastName,Document,History,IpsID")] PatientEntity patientEntity)
        {
            if (ModelState.IsValid)
            {
                db.Add(patientEntity);
            
                return RedirectToAction("Index");
            }

            ViewBag.IpsID = new SelectList(of.ToList(), "IpsID", "Name", patientEntity.IpsID);
            return View(patientEntity);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientEntity patientEntity = db.Find(id);
            if (patientEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.IpsID = new SelectList(of.ToList(), "IpsID", "Name", patientEntity.IpsID);
            return View(patientEntity);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,Name,LastName,Document,History,IpsID")] PatientEntity patientEntity)
        {
            if (ModelState.IsValid)
            {
                db.Change(patientEntity);
                return RedirectToAction("Index");
            }
            ViewBag.IpsID = new SelectList(of.ToList(), "IpsID", "Name", patientEntity.IpsID);
            return View(patientEntity);
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientEntity patientEntity = db.Find(id);
            if (patientEntity == null)
            {
                return HttpNotFound();
            }
            return View(patientEntity);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientEntity patientEntity = db.Find(id);
            db.Remove(patientEntity);

            return RedirectToAction("Index");
        }

    }
}
