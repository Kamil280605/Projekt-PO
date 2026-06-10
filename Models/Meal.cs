namespace RestaurantOrderSystem.Models
{
    // Klasa reprezentująca danie główne
    public class Meal : MenuItem
    {
        // Informacja czy danie jest ostre
        public bool IsSpicy { get; set; }

        public Meal(
            string name,
            decimal basePrice,
            string description,
            bool isSpicy)
            : base(name, basePrice, description)
        {
            IsSpicy = isSpicy;
        }

        // Ostre dania są droższe o 2 zł
        public override decimal CalculatePrice()
        {
            if (IsSpicy)
            {
                return BasePrice + 2;
            }

            return BasePrice;
        }

        public override string GetDescription()
        {
            string spicyInfo =
                IsSpicy ? "Spicy" : "Regular";

            return $"{Name} - {CalculatePrice()} zł ({spicyInfo})";
        }
    }
}