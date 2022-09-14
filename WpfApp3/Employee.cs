using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Payrate { get; set; }
        public bool ApplyTaxFreeThrehold { get; set; }

        public override string ToString() //we modify the ToString method, otherwise listbox will show only an object definition
                                          //but now it will show what we want
        {
            return $"ID: {Id} - {FirstName} {LastName}";
        }
    }
}
