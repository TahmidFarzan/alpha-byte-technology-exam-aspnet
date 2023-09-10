using System;
using System.Web;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AlphaByteTechnologyExam.Models
{
    [Table("EMPLOYEE")]
    public class Employee
    {
        private readonly DBContext _dbContext = new DBContext();

        [Key]
        [Column("ID")]
        [Display(Name = "Id")]
        public long Id { get; set; }

        [Required]
        [Column("ID_NUMBER")]
        [Display(Name = "Id Number")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "The ID number must be an 8-digit.")]
        public string IdNumber { get; set; }

        [Required]
        [Column("NAME")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Column("DIV_ID")]
        [Display(Name = "Division")]
        public long DivId { get; set; }

        [Column("DEPT_ID")]
        [Display(Name = "Department")]
        public long DeptId { get; set; }

        [Required]
        [Column("DOB")]
        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Dob { get; set; }

        [Column("FILE_PARH")]
        [Display(Name = "Resume")]
        public string FileParh { get; set; }

        [NotMapped]
        [Display(Name = "Division")]
        public Division Division { 
            get {
                return _dbContext.tDivision.FirstOrDefault(e => e.Id == DivId);
            } 
        }

        [NotMapped]
        [Display(Name = "Department")]
        public Department Department {
            get
            {
                return _dbContext.tDepartment.FirstOrDefault(e => e.Id == DeptId);
            }
        }

        [NotMapped]
        [Display(Name = "Resume")]
        public HttpPostedFileBase ResumeFile { get; set; }

        [NotMapped]
        [Display(Name = "Age")]
        public string Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int years = today.Year - Dob.Year;
                int months = today.Month - Dob.Month;
                int days = today.Day - Dob.Day;

                if (days < 0)
                {
                    months--;
                    days += DateTime.DaysInMonth(today.Year, today.Month);
                }

                if (months < 0)
                {
                    years--;
                    months += 12;
                }

                return $"{years} years {months} months {days} days";
            }
        }
    }
}