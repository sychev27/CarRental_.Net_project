using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;

namespace CarRental.DTOs
{
    public class CarDTO
    {
        [Key]
        public Guid Id { get; set; }
        public CarType CarType { get; set; }
        public CarColor CarColor { get; set; }
        public int CarID { get; set; }
    }
}
