using ClinicalSystem.Common.Context;
using SistemaClinico.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalSystem.Bussines.Broker
{
    internal class OrderBroker : IDisposable
    {
        private ClinicalSystemServicesContext db = new ClinicalSystemServicesContext();
        private OrderEntity Order;

        internal List<OrderEntity> GetOrder()
        {
            //this.RefreshAll();
            return db.OrderEntities.ToList();
        }
        //public void RefreshAll()
        //{
        //    foreach (var entity in db.ChangeTracker.Entries())
        //    {
        //        entity.Reload();
        //    }
        //}

        internal OrderEntity Add(OrderEntity obje)
        {
            OrderEntity Order = db.OrderEntities.Add(obje);
            db.SaveChanges();
            db.Entry(obje).Reload();
            //this.RefreshAll();
            return Order;
        }

        internal bool Change(OrderEntity obje)
        {
            db.Entry(obje).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        internal OrderEntity Remove(OrderEntity obje)
        {
            Order = db.OrderEntities.Remove(obje);
            db.SaveChanges();
            return Order;
        }

        internal OrderEntity Find(int? Id)
        {
            return db.OrderEntities.Find(Id);
        }

        void IDisposable.Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
