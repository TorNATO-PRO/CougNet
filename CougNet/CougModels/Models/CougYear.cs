using System;
using System.ComponentModel.DataAnnotations;

namespace CougModels
{
    public class CougYear
    {
        [Key]
        public int Id { get; set; }

        public string Year { get; set; }
    }
}
