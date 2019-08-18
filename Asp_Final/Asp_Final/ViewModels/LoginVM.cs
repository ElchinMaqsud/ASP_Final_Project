using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Final.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password), StringLength(255)]
        public string Password { get; set; }
    }
}
