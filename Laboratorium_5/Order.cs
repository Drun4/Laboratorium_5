using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium_5
{
    public class Order
    {
        public double kitPrice { get; set; }
        public int kitAmount { get; set; }

        public double helmetPrice { get; set; }
        public double gogglesPrice { get; set; }
        public double skipolesPrice { get; set; }

        public Order(double kitPrice, int kitAmount)
        {
            this.kitAmount = kitAmount;
            this.kitPrice = kitPrice;
        }

        public double getFinalPrice
        {
            get
            {
                return kitAmount * (kitPrice + helmetPrice + gogglesPrice + skipolesPrice);
            }
        }
    }
}
