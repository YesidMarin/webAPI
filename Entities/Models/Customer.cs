using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [Column("CustomerId")]
        public Guid GuidCustomer { get; set; }

        [Column("CustomerCityId")]
        [Required(ErrorMessage = "City is required")]
        public Guid GuidCity { get; set; }

        [Column("CustomerName")]
        [Required(ErrorMessage = "Customer name is required")]
        public string Name { get; set; }

        [Column("CustomerLastName")]
        [Required(ErrorMessage = "Customer lastname is required")]
        public string LastName { get; set; }

        [Column("CustomerIdNumber")]
        [Required(ErrorMessage = "Identification is unique and required")]
        public int Identification { get; set; }

        [Column("CustomerTelephone")]
        public int Telephone { get; set; }

        [Column("CustomerAddress")]
        public string Address { get; set; }

        [Column("CustomerEmail")]
        public string Email { get; set; }
    }
}
