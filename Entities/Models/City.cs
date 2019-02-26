using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "City name is required")]
        [StringLength(25, ErrorMessage = "City name can't be longer than 25 characters")]
        public string CityName { get; set; }
    }
}
