
using System.Net;
using System.Web.Mvc;

using SistemaClinico.Entities.Models;
using ClinicalSystem.Facade;

namespace ClinicalSystem.Services.Controllers
{
    public class IpsController : Controller
    {
        private IpsFacade db = new IpsFacade();

        // GET: Ips
        public ActionResult Index()
        {
            return View(db.ToList());
        }

        // GET: Ips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IpsEntity ipsEntity = db.Find(id);
            if (ipsEntity == null)
            {
                return HttpNotFound();
            }
            return View(ipsEntity);
        }

        // GET: Ips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IpsID,Name")] IpsEntity ipsEntity)
        {
            if (ModelState.IsValid)
            {
                db.Add(ipsEntity);
         
                return RedirectToAction("Index");
            }

            return View(ipsEntity);
        }

        // GET: Ips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IpsEntity ipsEntity = db.Find(id);
            if (ipsEntity == null)
            {
                return HttpNotFound();
            }
            return View(ipsEntity);
        }

        // POST: Ips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IpsID,Name")] IpsEntity ipsEntity)
        {
            if (ModelState.IsValid)
            {
                db.Change(ipsEntity);
                return RedirectToAction("Index");
            }
            return View(ipsEntity);
        }

        // GET: Ips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IpsEntity ipsEntity = db.Find(id);
            if (ipsEntity == null)
            {
                return HttpNotFound();
            }
            return View(ipsEntity);
        }

        // POST: Ips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IpsEntity ipsEntity = db.Find(id);
            db.Remove(ipsEntity);
         
            return RedirectToAction("Index");
        }


    }
}
