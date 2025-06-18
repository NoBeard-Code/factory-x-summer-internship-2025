using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Entities.Abstraction
{
    public abstract class EntityBase
    {
        [Key]
        public string Id { get; set; }
    }
}
