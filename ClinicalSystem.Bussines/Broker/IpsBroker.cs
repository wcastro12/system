using ClinicalSystem.Common.Context;
using SistemaClinico.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClinicalSystem.Bussines.Broker
{
   internal class IpsBroker : IDisposable
    {
        private ClinicalSystemServicesContext db = new ClinicalSystemServicesContext();
        private IpsEntity Ips;

        internal List<IpsEntity> GetIps()
        {
            return db.IpsEntities.ToList();
        }

        internal IpsEntity Add(IpsEntity obje)
        {
            IpsEntity Ips = db.IpsEntities.Add(obje);
            db.SaveChanges();
            return Ips;
        }

        internal bool Change(IpsEntity obje)
        {
            db.Entry(obje).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        internal IpsEntity Remove(IpsEntity obje)
        {
            Ips = db.IpsEntities.Remove(obje);
            db.SaveChanges();
            return Ips;
        }

        internal IpsEntity Find(int? Id)
        {
            return db.IpsEntities.Find(Id);
        }

        void IDisposable.Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
