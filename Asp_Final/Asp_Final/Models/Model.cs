using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Final.Models
{
    public class Model
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int MarkId { get; set; }
        public virtual Mark Mark { get; set; }

        public virtual ICollection<Automobile> Automobiles { get; set; }
    }
}
