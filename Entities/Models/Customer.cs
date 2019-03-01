using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entities.Models
{
    [Table("Customer")]
    public class Customer : IEntity
    {
        [Key]
        [Column("CustomerId")]
        public Guid Id { get; set; }

        [Column("CustomerCityId")]
        [JsonRequiredAttribute()]
        public Guid GuidCity { get; set; }

        [Column("CustomerName")]
        [StringLength(25, ErrorMessage = "Max range of 25")]
        [JsonRequiredAttribute()]
        public string Name { get; set; }

        [Column("CustomerLastName")]
        [StringLength(25, ErrorMessage = "Max range of 25")]
        [JsonRequiredAttribute()]
        public string LastName { get; set; }

        [Column("CustomerIdNumber")]
        public int Identification { get; set; }

        [Column("CustomerTelephone")]
        public int Telephone { get; set; }

        [Column("CustomerAddress")]
        [StringLength(30, ErrorMessage = "Max range of 30")]
        public string Address { get; set; }

        [Column("CustomerEmail")]
        [StringLength(30, ErrorMessage = "Max range of 30")]
        public string Email { get; set; }
    }
}
