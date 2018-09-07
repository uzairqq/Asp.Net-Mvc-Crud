using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCrud.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [StringLength(200)]
        [DisplayName("Email Id")]
        public string EmailId { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
    }
}