using System;
using System.ComponentModel.DataAnnotations;

namespace CougModels
{
    public class CougProgramRegistration
    {
        [Key]
        public int Id { get; set; }

        public Coug Coug { get; set; }

        public CougProgram CougProgram { get; set; }

        public bool Approved { get; set; }
    }
}
