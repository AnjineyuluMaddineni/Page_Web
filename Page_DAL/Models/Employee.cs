using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int ?Age { get; set; }
        public string Address {  get; set; }    
        public decimal Salary {  get; set; }
        public bool IsActive {  get; set; }  
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageName {  get; set; }
        public DateTime HireData {  get; set; }
        public DateTime Created {  get; set; }=DateTime.Now;

        [ForeignKey("department")]
        public int? departmentId { get; set; }

        [InverseProperty("employees")]
        public Department department { get; set; }
    }
}
