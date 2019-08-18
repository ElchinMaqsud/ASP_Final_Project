using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Final.Models
{
    public class News
    {
        public int Id { get; set; }
        [Required,StringLength(50)]
        public string Title { get; set; }

        [Required,StringLength(400)]
        public string Info { get; set; }
        public string PhotoUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
