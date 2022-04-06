using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium_5
{
    public class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public double price { get; set; }

        // public double price { get; set; }

        public Person(string name, string surname, double price)
        {
            this.name = name;
            this.surname = surname;
            this.price = price;
            //this.price = price;
        }

        public string FullInfo
        {
            get
            {
                return $"{name} {surname} -> {price:0.0}$";
            }
        }
    }
}
