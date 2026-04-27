using System;
using System.Collections.Generic;

namespace Review
{
    class Employee : IComparable<Employee>
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string city { get; set; }

      
        public int CompareTo(Employee other)
        {
            int cityCompare = this.city.CompareTo(other.city);

            if (cityCompare == 0)
                return this.Name.CompareTo(other.Name);

            return cityCompare;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, List<Employee>> dict = new Dictionary<char, List<Employee>>();

            List<Employee> ListEmp = new List<Employee>()
            {
                new Employee { Name="Aakash", Number="9988776600", city="Bangalore" },
                new Employee { Name="Abhilasha", Number="9876501100", city="Bangalore" },
                new Employee { Name="Sahil", Number="9123456701", city="Belgium" },
                new Employee { Name="Aditya", Number="9000001112", city="Mumbai" },
                new Employee { Name="Aman", Number="9234567890", city="Mumbai" },
                new Employee { Name="Ananya", Number="9456123789", city="Pune" }
            };

            foreach (var emp in ListEmp)
            {
                char key = emp.city[0];

                if (!dict.ContainsKey(key))
                    dict[key] = new List<Employee>();

                dict[key].Add(emp);
            }

            foreach (var item in dict)
            {
                item.Value.Sort(); 
            }
            List<char> keys = new List<char>(dict.Keys);
            keys.Sort();

            
            foreach (var key in keys)
            {

                foreach (var emp in dict[key])
                {
                    Console.WriteLine($"{emp.Name},{emp.Number},{emp.city}");
                }


            }
        }
    }
}