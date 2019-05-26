using ClinicalSystem.Common.Context;
using SistemaClinico.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace ClinicalSystem.Bussines.Broker
{
    internal class PatientBroker : IDisposable
    {
        private ClinicalSystemServicesContext db = new ClinicalSystemServicesContext();
        private PatientEntity Patient;

        internal List<PatientEntity> GetPatient()
        {
            return db.PatientEntities.ToList();
        }

        internal PatientEntity Add(PatientEntity obje)
        {
            PatientEntity Patient = db.PatientEntities.Add(obje);
            db.SaveChanges();
            return Patient;
        }

        internal bool Change(PatientEntity obje)
        {
            db.Entry(obje).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        internal PatientEntity Remove(PatientEntity obje)
        {
            Patient = db.PatientEntities.Remove(obje);
            db.SaveChanges();
            return Patient;
        }

        internal PatientEntity Find(int? Id)
        {
            return db.PatientEntities.Find(Id);
        }

        void IDisposable.Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
