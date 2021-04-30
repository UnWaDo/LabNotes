using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LabNotes
{
    public class Element
    {
        public int ElementId { get; set; }
        public int AtomNumber { get; set; } // number of protons
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double MolarMass { get; set; } // in g/mol, nature isotope abudance
    }
}