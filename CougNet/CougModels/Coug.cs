using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
