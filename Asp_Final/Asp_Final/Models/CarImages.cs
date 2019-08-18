using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Final.Models
{
    public class CarImages
    {
        public int Id { get; set; }
        
        public string CarPhotoUrl { get; set; }

        [NotMapped]
        public IFormFile CarPhoto { get; set; }
        public int AutomobileId { get; set; }
        public virtual Automobile Automobile { get; set; }
        
    }
}
