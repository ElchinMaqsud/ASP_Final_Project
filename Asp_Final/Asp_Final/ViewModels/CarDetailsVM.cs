using Asp_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Final.ViewModels
{
    public class CarDetailsVM
    {
        public Automobile automobile { get; set; }
        public  IEnumerable<CarImages> carImages { get; set; }
    }
}
