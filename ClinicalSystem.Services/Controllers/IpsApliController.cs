using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ClinicalSystem.Common.Context;
using SistemaClinico.Entities.Models;

namespace ClinicalSystem.Services.Controllers
{
    public class IpsApliController : ApiController
    {
        private ClinicalSystemServicesContext db = new ClinicalSystemServicesContext();

        // GET: api/IpsApli
        public IQueryable<IpsEntity> GetIpsEntities()
        {
            return db.IpsEntities;
        }

        // GET: api/IpsApli/5
        [ResponseType(typeof(IpsEntity))]
        public IHttpActionResult GetIpsEntity(int id)
        {
            IpsEntity ipsEntity = db.IpsEntities.Find(id);
            if (ipsEntity == null)
            {
                return NotFound();
            }

            return Ok(ipsEntity);
        }

        // PUT: api/IpsApli/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIpsEntity(int id, IpsEntity ipsEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ipsEntity.IpsID)
            {
                return BadRequest();
            }

            db.Entry(ipsEntity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IpsEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/IpsApli
        [ResponseType(typeof(IpsEntity))]
        public IHttpActionResult PostIpsEntity(IpsEntity ipsEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IpsEntities.Add(ipsEntity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ipsEntity.IpsID }, ipsEntity);
        }

        // DELETE: api/IpsApli/5
        [ResponseType(typeof(IpsEntity))]
        public IHttpActionResult DeleteIpsEntity(int id)
        {
            IpsEntity ipsEntity = db.IpsEntities.Find(id);
            if (ipsEntity == null)
            {
                return NotFound();
            }

            db.IpsEntities.Remove(ipsEntity);
            db.SaveChanges();

            return Ok(ipsEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IpsEntityExists(int id)
        {
            return db.IpsEntities.Count(e => e.IpsID == id) > 0;
        }
    }
}