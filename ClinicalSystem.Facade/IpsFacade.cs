using SistemaClinico.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicalSystem.Bussines.Handler;

namespace ClinicalSystem.Facade
{
   public class IpsFacade : IFacade<IpsEntity>
    {
        private IpsHandler oh = new IpsHandler();
        public bool Add(IpsEntity obje)
        {
            return oh.Add(obje);
        }

        public bool Change(IpsEntity obje)
        {
            return oh.Change(obje);
        }

        public IpsEntity Find(int? Id)
        {
            return oh.Find(Id);
        }

        public IpsEntity Remove(IpsEntity obje)
        {
            return oh.Remove(obje);
        }

        public List<IpsEntity> ToList()
        {
            return oh.ToList();
        }
    }
}
