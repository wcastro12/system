using ClinicalSystem.Bussines.Broker;
using SistemaClinico.Entities.Models;
using System;
using System.Collections.Generic;

namespace ClinicalSystem.Bussines.Handler
{
   public class ReasonChangesHandler
    {
        private ReasonChangesBroker ob = new ReasonChangesBroker();

        public bool Add(ReasonChangesEntity obje)
        {

            ob.Add(obje);

            return true;
        }
        public bool Change(ReasonChangesEntity obje)
        {
            ob.Change(obje);

            return true;
        }
        public ReasonChangesEntity Find(int? Id)
        {
            return ob.Find(Id);
        }
        public ReasonChangesEntity Remove(ReasonChangesEntity obje)
        {
            return ob.Remove(obje);
        }

        public List<ReasonChangesEntity> ToList()
        {
            return ob.GetReasonChanges();
        }
    }
}
