using System;
using System.ComponentModel.DataAnnotations;

namespace CougModels.ViewModels
{
    public class CougViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        [Display(Name = "Year")]
        public int CougYearId { get; set; }

        [Display(Name = "Major")]
        public int MajorId { get; set; }

        public string AppId { get; set; }

        [Display(Name = "Name")]
        public string Name { get { return Firstname + " " + Lastname; } }
    }
}
