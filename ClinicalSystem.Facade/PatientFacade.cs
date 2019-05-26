using SistemaClinico.Entities.Models;
using System.Collections.Generic;
using ClinicalSystem.Bussines.Handler;

namespace ClinicalSystem.Facade
{
    public class PatientFacade : IFacade<PatientEntity>
    {
        private PatientHandler oh = new PatientHandler();
        public bool Add(PatientEntity obje)
        {
            return oh.Add(obje);
        }

        public bool Change(PatientEntity obje)
        {
            return oh.Change(obje);
        }

        public PatientEntity Find(int? Id)
        {
            return oh.Find(Id);
        }

        public PatientEntity Remove(PatientEntity obje)
        {
            return oh.Remove(obje);
        }

        public List<PatientEntity> ToList()
        {
            return oh.ToList();
        }
    }
}
