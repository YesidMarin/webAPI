using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Cities")]
    public class City
    {
        [Key]
        [Column("CityId")]
        public Guid Id { get; set; }

        [Column("CityName")]
        [Required(ErrorMessage = "City name is required")]
        [StringLength(25, ErrorMessage = "City name can't be longer than 25 characters")]
        public string Name { get; set; }
    }

    public class Cities
    {
        public IEnumerable<City> ListCities { get; set; }
    }

}
