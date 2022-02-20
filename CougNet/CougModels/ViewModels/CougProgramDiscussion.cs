using System;
using System.ComponentModel;

namespace CougModels.ViewModels
{
    public class CougProgramDiscussion
    {
        public int CougProgramId { get; set; }

        public int parentID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CougID { get; set; }
        
        [DefaultValue("Create a new Thread")]
        public string PageTitle { get; set; }
    }
}
