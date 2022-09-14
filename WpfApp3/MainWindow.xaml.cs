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
using UI;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TaxRate> _scale1;
        private List<TaxRate> _scale2;
        public MainWindow()
        {
            InitializeComponent();
            lBoxEmployees.ItemsSource = EmployeeImporter.ImportEmployees();
             _scale1 = TaxRateImporter.ImportTaxRates("taxrate-nothreshold");
             _scale2 = TaxRateImporter.ImportTaxRates("taxrate-withthreshold");

        }

        private void btnCalculatePay_Click(object sender, RoutedEventArgs e)
        {
            if(lBoxEmployees.SelectedItem == null) //it gives the details of selected item
            {
                MessageBox.Show("Please select an employee");
            }
            else
            {
                var employee = (Employee)lBoxEmployees.SelectedItem;
                double hoursWorked = double.Parse(txtBoxHoursWorked.Text);
                double grossPay = employee.Payrate * hoursWorked;
                // MessageBox.Show($"Gross Pay is ${grossPay}");
                var scale = employee.ApplyTaxFreeThrehold ? _scale2 : _scale1; //ternary operator - if it is true assign the first one to scale,
                                                                               //if it is false assign the second one to scale
                foreach(var rate in scale)
                {
                    if(grossPay >= rate.Lower && grossPay < rate.Upper)
                    {
                        int tax = Convert.ToInt32(((grossPay + 0.99) * rate.A) - rate.B);
                    }
                }
            }
            // check https://www.ato.gov.au/Calculators-and-tools/Host/?anchor=TWC&anchor=TWC/questions#TWC/questions
        }
    }
}
