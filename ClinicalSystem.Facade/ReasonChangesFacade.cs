using SistemaClinico.Entities.Models;
using System.Collections.Generic;
using ClinicalSystem.Bussines.Handler;

namespace ClinicalSystem.Facade
{
   public class ReasonChangesFacade : IFacade< ReasonChangesEntity>
    {
        private  ReasonChangesHandler oh = new  ReasonChangesHandler();
        public bool Add( ReasonChangesEntity obje)
        {
            return oh.Add(obje);
        }

        public bool Change( ReasonChangesEntity obje)
        {
            return oh.Change(obje);
        }

        public  ReasonChangesEntity Find(int? Id)
        {
            return oh.Find(Id);
        }

        public  ReasonChangesEntity Remove( ReasonChangesEntity obje)
        {
            return oh.Remove(obje);
        }

        public List< ReasonChangesEntity> ToList()
        {
            return oh.ToList();
        }
    }
}
