using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClinico.Entities.Models
{

    public class PatientEntity
    {
        [DataMember]
        [Key]
        public int PatientID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Document { get; set; }

        [DataMember]
        public String History { get; set; }

        public int IpsID { get; set; }
        public virtual IpsEntity Ips { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
