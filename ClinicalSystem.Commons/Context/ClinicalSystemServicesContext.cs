using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClinicalSystem.Common.Context
{
    public class ClinicalSystemServicesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ClinicalSystemServicesContext() : base("name=ClinicalSystemServicesContext")
        {
        }

        public System.Data.Entity.DbSet<SistemaClinico.Entities.Models.PatientEntity> PatientEntities { get; set; }

        public System.Data.Entity.DbSet<SistemaClinico.Entities.Models.IpsEntity> IpsEntities { get; set; }

        public System.Data.Entity.DbSet<SistemaClinico.Entities.Models.OrderEntity> OrderEntities { get; set; }

        public System.Data.Entity.DbSet<SistemaClinico.Entities.Models.ReasonChangesEntity> ReasonChangesEntities { get; set; }


    }
}
