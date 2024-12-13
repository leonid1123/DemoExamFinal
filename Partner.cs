using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamFinal
{
    internal class Partner
    {
        public int id {  get; private set; }
        public string name { get; private set; }
        public string country { get; private set; }
        public int discount {  get; private set; }

        public Partner(int _id, string _name, string _country)
        {
            id = _id;
            name = _name;
            country = _country;
            discount = 0;
        }

        public void SetDiscount(int _totalSales)
        {
            if (_totalSales > 100)
            {
                discount = 15;
            }
            else if (_totalSales > 50)
            {
                discount = 10;
            }
            else if (_totalSales > 10)
            {
                discount = 5;
            }
            else { 
                discount = 0;
            }
        }
    }
}
