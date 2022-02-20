using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CougModels.Models
{
    internal class Discussion
    {
        [Key]
        public int Id { get; internal set; }

        internal Discussion(IEnumerable<Broadcast> broadcast)
        {
            this.Broadcasts = broadcast;
        }

        public IEnumerable<Broadcast> Broadcasts { get; internal set; }

        public CougProgram Program { get; internal set; }
    }
}
