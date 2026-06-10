namespace RestaurantOrderSystem.Models
{
    // Klasa reprezentująca deser
    public class Dessert : MenuItem
    {
        // Informacja czy deser jest zimny
        public bool IsCold { get; set; }

        public Dessert(
            string name,
            decimal basePrice,
            string description,
            bool isCold)
            : base(name, basePrice, description)
        {
            IsCold = isCold;
        }

        // Desery mają standardową cenę
        public override decimal CalculatePrice()
        {
            return BasePrice;
        }

        public override string GetDescription()
        {
            string type =
                IsCold ? "Cold" : "Warm";

            return $"{Name} - {CalculatePrice()} zł ({type})";
        }
    }
}