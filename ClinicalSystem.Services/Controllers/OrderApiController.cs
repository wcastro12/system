using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ClinicalSystem.Common.Context;
using SistemaClinico.Entities.Models;
using ClinicalSystem.Facade;
namespace ClinicalSystem.Services.Controllers
{
    public class OrderApiController : ApiController
    {
        private OrderFacade db = new OrderFacade();

        // GET: api/OrderApi
        public List<OrderEntity> GetOrderEntities()
        {
            List<OrderEntity> listtemp= db.ToList();
            return listtemp;
        }

        // GET: api/OrderApi/5
        [ResponseType(typeof(OrderEntity))]
        public IHttpActionResult GetOrderEntity(int id)
        {
            OrderEntity orderEntity = db.Find(id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            return Ok(orderEntity);
        }

        // PUT: api/OrderApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderEntity( OrderEntity orderEntity)
        {


         

            db.Change(orderEntity);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrderApi
        [ResponseType(typeof(OrderEntity))]
        public IHttpActionResult PostOrderEntity(OrderEntity orderEntity)
        {
       

            bool respont=  db.Add(orderEntity);

            if (respont)
            {
                return CreatedAtRoute("DefaultApi", new { id = orderEntity.OrderID }, orderEntity);
    
            }
            else
            {
                return BadRequest(ModelState);
            }

            
        }

    }
}