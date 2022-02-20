using System;
using System.ComponentModel.DataAnnotations;

namespace CougModels.Models
{
    internal class Broadcast
    {
        internal Broadcast()
        {
            this.TimeStamp = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Author")]
        public Coug Who { get; set; }

        [Required]
        public CougProgram WhereTo { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Display(Name = "Sent Date")]
        public DateTime TimeStamp { get; set; }
    }
}
