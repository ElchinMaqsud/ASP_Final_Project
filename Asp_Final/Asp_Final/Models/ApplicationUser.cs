using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Final.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required, StringLength(100)]
        public string Firstname { get; set; }

        [StringLength(100)]
        public string Lastname { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegisterDate { get; set; }

        public  virtual ICollection<Automobile> automobiles { get; set; }
    }
}
