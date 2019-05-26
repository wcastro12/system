using SistemaClinico.Entities.Models;
using System.Collections.Generic;
using ClinicalSystem.Bussines.Handler;

namespace ClinicalSystem.Facade
{
    public class OrderFacade : IFacade<OrderEntity>
    {
        private OrderHandler oh = new OrderHandler();
        public bool Add(OrderEntity obje)
        {
            return oh.Add(obje);
        }

        public bool Change(OrderEntity obje)
        {
            return oh.Change(obje);
        }

        public OrderEntity Find(int? Id)
        {
            return oh.Find(Id);
        }

        public OrderEntity Remove(OrderEntity obje)
        {
            return oh.Remove(obje);
        }

        public List<OrderEntity> ToList()
        {
            return oh.ToList();
        }
    }
}
