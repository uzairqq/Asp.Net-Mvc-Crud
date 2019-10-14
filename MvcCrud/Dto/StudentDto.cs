using System;

namespace MvcCrud
{
    public class StudentDto : BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public int MobileNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public int EmergencyContact { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string StateOrProvince { get; set; }

        public int PostalCode { get; set; }
    }
}