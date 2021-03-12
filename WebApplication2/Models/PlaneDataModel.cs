using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class PlaneDataModel
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public int PassangerCount { get; set; }

    }
}
