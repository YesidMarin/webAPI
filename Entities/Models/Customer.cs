using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entities.Models
{
    [Table("Customer")]
    public class Customer : IEntity
    {
        [Key]
        [Column("primaryId")]
        public Guid Id { get; set; }

        [Column("cityId")]
        [JsonRequired]
        public Guid GuidCity { get; set; }

        [Column("customerName")]
        [StringLength(25, ErrorMessage = "Max range of 25")]
        public string Name { get; set; }

        [Column("lastName")]
        [StringLength(25, ErrorMessage = "Max range of 25")]
        public string LastName { get; set; }

        [Column("numberId")]
        [StringLength(12, ErrorMessage = "Max range of 12")]
        public string Identification { get; set; }

        [Column("telephone")]
        [StringLength(12, ErrorMessage = "Max range of 12")]
        public string Telephone { get; set; }

        [Column("address")]
        [StringLength(30, ErrorMessage = "Max range of 30")]
        public string Address { get; set; }

        [Column("email")]
        [StringLength(30, ErrorMessage = "Max range of 30")]
        public string Email { get; set; }
    }

}
