using System;
using System.ComponentModel.DataAnnotations;

namespace SproutExam.Data.Models
{
    public class Employee
    {
        [Display(Name = "Name")]
        [MaxLength(20)]
        [Required]
        public string name { get; set; }


        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "dd-MM-yy")]
        [Required(ErrorMessage = "Birth date is required")]
        public DateTime birth_date { get; set; }

        [Display(Name = "TIN")]
        [MaxLength(20)]
        [Required]
        public string tin { get; set; }


        [Display(Name = "Employee Type")]
        [Required(ErrorMessage = "Employee type is required")]
        public EmployeeTypeEnum employee_type { get; set; }

        [Display(Name = "Work Days")]
        public decimal days_worked { get; set; }

        [Display(Name = "Absences")]
        public decimal days_absent { get; set; }

        [Display(Name = "Salary")]
        public decimal salary { get; set; }

        public Employee()
        {
            this.days_absent = 0;
            this.days_worked = 0;
        }
    }
}
