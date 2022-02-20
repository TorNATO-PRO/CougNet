using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Display(Name = "Currently active?")]
        public bool IsActive { get; set; }

        [Display(Name = "Publicly available?")]
        public bool IsPublic { get; set; }

        public string CreatedBy { get; set; }

        [NotMapped]
        public bool IsOwner { get; set; }
    }
}
