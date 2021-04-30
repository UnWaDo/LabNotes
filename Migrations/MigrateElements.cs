using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Windows;
using System;

namespace LabNotes.Migrations
{
    public class DbMigrator
    {
        public static void MigrateElements()
        {
            var context = new ChemContext();
            var path = "Elements.csv";
            if (!File.Exists(path)) {
                MessageBox.Show("Error reading Elements.csv file. Does it exist?", "Error!");
                return;
            }
            int addedElements = 0;
            int modifiedElements = 0;
            using (StreamReader file = File.OpenText(path))
            {
                string line;
                while((line = file.ReadLine()) != null)
                {
                    string[] substrings = line.Split(";");
                    int atomNumber = int.Parse(substrings[0]);
                    string name = substrings[1].ToLower();
                    string symbol = substrings[2];
                    double molarMass = double.Parse(substrings[3]);

                    Element el = context.Elements.Find(atomNumber);
                    if (el != null) {
                        if (el.Name != name || el.Symbol != symbol || el.MolarMass != molarMass) {
                            el.Name = name;
                            el.Symbol = symbol;
                            el.MolarMass = molarMass;
                            context.Elements.Update(el);
                            modifiedElements++;
                        }
                        continue;
                    }

                    context.Elements.Add(new Element {
                        ElementId = atomNumber,
                        AtomNumber = atomNumber,
                        Name = name,
                        Symbol = symbol,
                        MolarMass = molarMass
                    });
                    addedElements++;
                }
                if (addedElements != 0 || modifiedElements != 0) context.SaveChanges();
            }
            MessageBox.Show(
                String.Format("A total of {0} elements were successfully added and {1} modified.", addedElements, modifiedElements),
                 "Success!"
            );
        }
    }
}
