using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CougModels
{
    public class Discussion
    {
        [Key]
        public int Id { get; internal set; }

        public CougProgram CougProgram { get; set; }

        [DefaultValue(0)]
        public int parentID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Coug Coug { get; set; }

        [NotMapped]
        public List<Discussion> Replies { get; set; }
    }
}
