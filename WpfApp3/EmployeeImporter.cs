using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class EmployeeImporter
    {
        public static List<Employee> ImportEmployees() //Create a list of employee objects, reading the csv, split it, write each one to an array,
                                                       //Assing each one to an object property,add that object to a list, return the list
        {
            var employees = new List<Employee>();
            string path = @"..\..\..\import\employee.csv";
            using(var reader = new StreamReader(path))
            {
                for(string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    string[] properties = line.Split(',');

                    var employee = new Employee
                    {
                        Id = int.Parse(properties[0]),
                        FirstName = properties[1],
                        LastName = properties[2],
                        Payrate = double.Parse(properties[3]),
                        ApplyTaxFreeThrehold = properties[4] == "Y"
                    };
                    employees.Add(employee);
                }
            }

            return employees;
        }
    }
}
