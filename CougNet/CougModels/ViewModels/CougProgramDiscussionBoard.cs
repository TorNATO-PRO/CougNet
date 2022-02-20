using System;
using System.Collections.Generic;

namespace CougModels.ViewModels
{
    public class CougProgramDiscussionBoard
    {
        public CougProgram CougProgram { get; set; }

        public List<Discussion> Discussions { get; set; }
    }
}
