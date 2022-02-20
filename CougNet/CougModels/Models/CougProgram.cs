using System;
using System.ComponentModel.DataAnnotations;

namespace CougModels
{
    public class CougProgram
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Approval Required?")]
        public bool ApprovalRequired { get; set; }
    }
}
