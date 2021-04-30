using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System;
using System.Linq;

namespace LabNotes
{
    public class Compound
    {
        public int CompoundId { get; set; }
        public string Brutto { get; set; }
        public string IUPACName { get; set; }
        public List<CompoundReaction> CompoundReactions { get; set; }

        public Dictionary<Element, int> GetElements()
        {
            var context = new ChemContext();
            var result = new Dictionary<Element, int>();
            string pattern = @"[A-Z][a-z]*\d*";
            MatchCollection matches = Regex.Matches(this.Brutto, pattern);
            foreach (Match match in matches) {
                Match element = Regex.Match(match.Value, @"[A-Z][a-z]*");
                Element el = context.Elements.Where(e => e.Symbol == element.Value).First();

                int amount;
                int amountStartIndex = element.Index + element.Value.Count();
                if (amountStartIndex == match.Value.Count()) amount = 1;
                else amount = int.Parse(match.Value.Substring(amountStartIndex));
                result.Add(el, amount);
            }
            return result;
        }

        public double GetMolarMass()
        {
            double MolarMass = 0;

            foreach ((Element e, int am) in this.GetElements()) MolarMass += am * e.MolarMass;

            return MolarMass;
        }
    }
}