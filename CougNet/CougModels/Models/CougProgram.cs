using System;
using System.ComponentModel.DataAnnotations;

namespace CougModels
{
    public class CougProgram
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Requirements { get; set; }

        [Display(Name = "Approval Required?")]
        public bool ApprovalRequired { get; set; }
    }
}
