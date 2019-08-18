using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Final.Models
{
    public class Automobile
    {
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string Name { get; set; }

        public string PhotoUrl { get; set; }
        
        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime GraduationYear { get; set; }

        [Required]
        public int EnginePower { get; set; }

        [Required]
        public decimal EngineVolume { get; set; }

        [Required]
        public int Mileage{ get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int ModelId { get; set; }
        public virtual Model Model { get; set; }

        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        public int BanId { get; set; }
        public virtual Ban Ban { get; set; }

        public int FuelId { get; set; }
        public virtual Fuel Fuel { get; set; }

        public int SpeedBoxId { get; set; }
        public virtual SpeedBox SpeedBox { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public bool IsNew { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        
        public virtual ICollection<CarImages> CarImages { get; set; }

        [NotMapped]
        public ICollection<IFormFile> AllCarImages { get; set; }

    }
}
