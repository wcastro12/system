using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClinico.Entities.Models
{

    [DataContract]
    public class ReasonChangesEntity
    {
        [DataMember]
        [Key]
        public int ReasonChangesID { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public DateTime DateChanges { get; set; }

        [DataMember]
        public int OrderID { get; set; }
        public virtual OrderEntity Order { get; set; }
    }
}
