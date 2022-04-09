namespace Laboratorium_5
{
    public class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public double finalPrice { get; set; }

        public Person(string name, string surname, double finalPrice)
        {
            this.name = name;
            this.surname = surname;
            this.finalPrice = finalPrice;
        }

        public string FullInfo
        {
            get
            {
                return $"{name} {surname} -> {finalPrice:0.0}$";
            }
        }
    }
}
