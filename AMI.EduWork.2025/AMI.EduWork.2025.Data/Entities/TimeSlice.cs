using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMI.EduWork._2025.Data.Entities
{
    public class TimeSlice
    {
        [Required]
        [Key]
        public string Id { get; set; }
        [Required]
        [ForeignKey("WorkDay")]
        public string WorkDayId { get; set; }
        public WorkDay WorkDay { get; set; }
        [AllowNull]
        [ForeignKey("Project")]
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        [Required]
        public byte TypeOfSlice {  get; set; }

    }
}
