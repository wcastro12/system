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
    public class OrderEntity
    {
        [DataMember]
        [Key]
        public int OrderID { get; set; }

        [DataMember]
        public OrderType OrderType { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Priority Priority { get; set; }

        [DataMember]
        public State State { get; set; }

        [DataMember]
        public string Posology { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int PatientID { get; set; }

        [DataMember]
        public string ReasonChange { get; set; }
        

        [DataMember]
        public virtual PatientEntity Patient { get; set; }

        public virtual ICollection<ReasonChangesEntity> ReasonChanges { get; set; }

    }
}
