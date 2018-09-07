using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace MvcCrud.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Required (AllowEmptyStrings = false,ErrorMessage = "Please Provide First Name")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required (AllowEmptyStrings = false,ErrorMessage = "Please Provide Last Name")]
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