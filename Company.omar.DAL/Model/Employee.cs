using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Company.omar.DAL.Model
{
    public class Employee : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]


        public string Name { get; set; }
        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65")]
        [Required(ErrorMessage ="Age Is Required")]
        public int? Age { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        public decimal Salary { get; set; }
        
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        
        public DateTime HiringDate { get; set; }
        public DateTime CreateAt { get; set; }
        [DisplayName("Department") ]
        public int? DepartmentId { get; set; }
       
        public Department? Department { get; set; }
        



    }
}
