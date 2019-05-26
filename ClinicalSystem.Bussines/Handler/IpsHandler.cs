using System;
using System.Collections.Generic;
using ClinicalSystem.Bussines.Broker;
using SistemaClinico.Entities.Models;

namespace ClinicalSystem.Bussines.Handler
{
    public class IpsHandler
    {
        private IpsBroker ob = new IpsBroker();

        public bool Add(IpsEntity obje)
        {

            ob.Add(obje);

            return true;
        }
        public bool Change(IpsEntity obje)
        {
            ob.Change(obje);

            return true;
        }
        public IpsEntity Find(int? Id)
        {
            return ob.Find(Id);
        }
        public IpsEntity Remove(IpsEntity obje)
        {
            return ob.Remove(obje);
        }

        public List<IpsEntity> ToList()
        {
            return ob.GetIps();
        }
    }
}
