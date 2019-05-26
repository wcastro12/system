
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

using SistemaClinico.Entities.Models;

using ClinicalSystem.Facade;

namespace ClinicalSystem.Services.Controllers
{
    public class PatientAPIController : ApiController
    {
        private PatientFacade db = new PatientFacade();
        private IpsFacade of = new IpsFacade();

        // GET: api/PatientAPI
        public List<PatientEntity> GetPatientEntities()
        {
            return db.ToList();
        }

        // GET: api/PatientAPI/5
        [ResponseType(typeof(PatientEntity))]
        public IHttpActionResult GetPatientEntity(int id)
        {
            PatientEntity patientEntity = db.Find(id);
            if (patientEntity == null)
            {
                return NotFound();
            }

            return Ok(patientEntity);
        }

        // PUT: api/PatientAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatientEntity(int id, PatientEntity patientEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patientEntity.PatientID)
            {
                return BadRequest();
            }

          

            try
            {
                db.Change(patientEntity);
            }
            catch (DbUpdateConcurrencyException)
            {

                    return NotFound();

            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PatientAPI
        [ResponseType(typeof(PatientEntity))]
        public IHttpActionResult PostPatientEntity(PatientEntity patientEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Add(patientEntity);
         

            return CreatedAtRoute("DefaultApi", new { id = patientEntity.PatientID }, patientEntity);
        }

        // DELETE: api/PatientAPI/5
        [ResponseType(typeof(PatientEntity))]
        public IHttpActionResult DeletePatientEntity(int id)
        {
            PatientEntity patientEntity = db.Find(id);
            if (patientEntity == null)
            {
                return NotFound();
            }

            db.Remove(patientEntity);
    

            return Ok(patientEntity);
        }

    }
}