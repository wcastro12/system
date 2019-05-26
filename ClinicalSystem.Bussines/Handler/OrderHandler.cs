using ClinicalSystem.Bussines.Broker;
using SistemaClinico.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalSystem.Bussines.Handler
{
   public class OrderHandler
    {
        private OrderBroker ob = new OrderBroker();
        private ReasonChangesBroker rcb = new ReasonChangesBroker();
        public bool Add(OrderEntity obje)
        {
            obje.Date = DateTime.Now;

            ob.Add(obje);
      
            return true;
        }
        public bool Change(OrderEntity obje)
        {
            OrderEntity ordertemp = ob.Find(obje.OrderID);
            ordertemp.State = obje.State;
            ordertemp.ReasonChange = obje.ReasonChange;
            rcb.Add(new ReasonChangesEntity() { OrderID = ordertemp.OrderID, Description = ordertemp.ReasonChange,DateChanges=DateTime.Now });
            ob.Change(ordertemp);
            
            return true;
        }
        public OrderEntity Find(int? Id)
        {
            return ob.Find(Id) ;
        }
        public OrderEntity Remove(OrderEntity obje)
        {
            return ob.Remove(obje);
        }

        public List<OrderEntity> ToList()
        {
            return ob.GetOrder();
        }
    }
}
