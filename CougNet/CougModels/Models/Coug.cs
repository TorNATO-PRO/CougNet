using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CougModels
{
    public class Coug
    {
        [Key]
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public Gender Gender { get; set; }

        public CougYear Year { get; set; }

        public CougCourse Major { get; set; }

        public string AppId { get; set; }

        [Display(Name = "Name")]
        [NotMapped]
        public string Name { get { return Firstname + " " + Lastname; } }
    }
}
