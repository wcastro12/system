
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
    public class IpsEntity
    {
        [Key]
        [DataMember]
        public int IpsID { get; set; }

        [DataMember]
        public string Name { get; set; }

        public virtual ICollection<PatientEntity> Patients { get; set; }

   
    }
}
