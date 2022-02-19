using System;
using System.ComponentModel.DataAnnotations;

namespace CougModels
{
    public class CougCourse
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        //possibly create faculty for this
    }
}
