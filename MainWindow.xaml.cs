using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using LabNotes.Migrations;

namespace LabNotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChemContext context = new ChemContext(); 

        public MainWindow()
        {
            InitializeComponent();
        }

         private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                System.Windows.Data.CollectionViewSource compoundsViewSource =
                    ((System.Windows.Data.CollectionViewSource)(this.FindResource("compoundsViewSource")));
                context.Compounds.ToList();
                compoundsViewSource.Source = context.Compounds.Local.ToObservableCollection();
            }

        void addCompound(object sender, RoutedEventArgs e)
        {
            var brutto = compoundBruttoTextBox.Text;
            var name = compoundNameTextBox.Text.ToLower();
            if ((brutto == "") || (name.Count() < 3))
            {
                MessageBox.Show("Bad input, please make sure that all fields are filled and that name is longer than 3 symbols.", "Error!");
                return;
            }
            if (context.Compounds.Where(c => c.IUPACName == name).Count() != 0)
            {
                MessageBox.Show("The compound was already added.", "Error!");
                return;
            }

            context.Add(new Compound{
                Brutto = brutto,
                IUPACName = name
            });
            context.SaveChanges();
            MessageBox.Show("Compound added successfully.", "Confirmation");
        }
        void deleteCompound(object sender, RoutedEventArgs e)
        {
            var selected_compound = compoundsDataGrid.SelectedCells[0].Item;
            context.Remove(selected_compound);
            context.SaveChanges();
            MessageBox.Show("Compound deleted successfully.", "Confirmation");
        }

        void migrateElements(object sender, RoutedEventArgs e)
        {
            DbMigrator.MigrateElements();
        }

        void getCompoundMolarMass(object sender, RoutedEventArgs e)
        {
            var selected_compound = (Compound)compoundsDataGrid.SelectedCells[0].Item;
            MessageBox.Show(String.Format("M = {0:F2} g/mol", selected_compound.GetMolarMass()), "Molar Mass");
        }
    }
}
