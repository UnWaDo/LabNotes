using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LabNotes
{
    public class Reaction
    {
        public int ReactionId { get; set; }
        public string Title { get; set; }
        public List<CompoundReaction> CompoundReactions { get; set; }
    }
}