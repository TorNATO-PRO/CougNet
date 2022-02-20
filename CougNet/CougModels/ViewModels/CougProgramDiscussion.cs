using System;
namespace CougModels.ViewModels
{
    public class CougProgramDiscussion
    {
        public int CougProgramId { get; internal set; }

        public int parentID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CougID { get; set; }

    }
}
