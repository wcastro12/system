using ClinicalSystem.Common.Context;
using SistemaClinico.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClinicalSystem.Bussines.Broker
{
    internal class ReasonChangesBroker : IDisposable
    {
        private ClinicalSystemServicesContext db = new ClinicalSystemServicesContext();
        private ReasonChangesEntity ReasonChanges;

        internal List<ReasonChangesEntity> GetReasonChanges()
        {
            return db.ReasonChangesEntities.ToList();
        }

        internal ReasonChangesEntity Add(ReasonChangesEntity obje)
        {
            ReasonChangesEntity ReasonChanges = db.ReasonChangesEntities.Add(obje);
            db.SaveChanges();
            return ReasonChanges;
        }

        internal bool Change(ReasonChangesEntity obje)
        {
            db.Entry(obje).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        internal ReasonChangesEntity Remove(ReasonChangesEntity obje)
        {
            ReasonChanges = db.ReasonChangesEntities.Remove(obje);
            db.SaveChanges();
            return ReasonChanges;
        }

        internal ReasonChangesEntity Find(int? Id)
        {
            return db.ReasonChangesEntities.Find(Id);
        }

        void IDisposable.Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
