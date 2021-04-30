using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LabNotes
{
    public class CompoundReaction
    {
        public int CompoundReactionId { get; set; }
        public Compound Compound { get; set; }
        public int Amount { get; set; } // declared to be in moles
        public int Equivalents { get; set; }
        public bool IsLimiting { get; set; }
        public Reaction Reaction { get; set; }
    }
}