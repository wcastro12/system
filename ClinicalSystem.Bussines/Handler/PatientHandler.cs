using ClinicalSystem.Bussines.Broker;
using SistemaClinico.Entities.Models;
using System;
using System.Collections.Generic;

namespace ClinicalSystem.Bussines.Handler
{
   public class PatientHandler
    {
        private PatientBroker ob = new PatientBroker();

        public bool Add(PatientEntity obje)
        {

            ob.Add(obje);

            return true;
        }
        public bool Change(PatientEntity obje)
        {
            ob.Change(obje);

            return true;
        }
        public PatientEntity Find(int? Id)
        {
            return ob.Find(Id);
        }
        public PatientEntity Remove(PatientEntity obje)
        {
            return ob.Remove(obje);
        }

        public List<PatientEntity> ToList()
        {
            return ob.GetPatient();
        }
    }
}
