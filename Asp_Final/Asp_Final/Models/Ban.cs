using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Final.Models
{
    public class Ban
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Automobile> automobiles { get; set; }
    }
}
