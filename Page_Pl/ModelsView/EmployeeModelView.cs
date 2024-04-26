using Page_DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace Page_Pl.ModelsView
{
    public class EmployeeModelView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Can Not Be Empty")]
        [MaxLength(50, ErrorMessage = "Name Can Not Be More Than 50")]
        [MinLength(5, ErrorMessage = "Name Can Not Be Less Than 5")]
        public string Name { get; set; }

        [Range(22, 40, ErrorMessage = "Age Must Be To Range From 22 To 40")]
        public int? Age { get; set; }

        [RegularExpression("^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$"
            , ErrorMessage = "Address Must Be Like 123-Street-City-Country")]
        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public IFormFile Image { get; set; }
        public string ImageName {  get; set; }
         
        public DateTime HireData { get; set; }
        [ForeignKey("department")]
        public int? departmentId { get; set; }

        [InverseProperty("employees")]
        public Department department { get; set; }
    }
}
