namespace Laboratorium_5
{
    public class Order
    {
        public double kitPrice { get; set; }
        public int kitAmount { get; set; }

        public double helmetPrice { get; set; }
        public double gogglesPrice { get; set; }
        public double skiPolesPrice { get; set; }

        public Order(double kitPrice, int kitAmount, double helmetPrice, double gogglesPrice, double skiPolesPrice)
        {
            this.kitAmount = kitAmount;
            this.kitPrice = kitPrice;
            this.helmetPrice = helmetPrice;
            this.gogglesPrice = gogglesPrice;
            this.skiPolesPrice = skiPolesPrice;
        }

        public double getFinalPrice
        {
            get
            {
                return kitAmount * (kitPrice + helmetPrice + gogglesPrice + skiPolesPrice);
            }
        }
    }
}
