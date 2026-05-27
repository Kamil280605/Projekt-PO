namespace RestaurantOrderSystem.Models
{
    public class Meal : MenuItem
    {
        // Klasa reprezentująca danie główne
        public bool IsSpicy { get; set; }

        public Meal(string name, decimal basePrice, bool isSpicy)
            : base(name, basePrice)
        {
            IsSpicy = isSpicy;
        }

        public override decimal CalculatePrice()
        {
            if (IsSpicy)
            {
                return BasePrice + 2;
            }

            return BasePrice;
        }

        // TODO:
        // dodać składniki i alergeny posiłku
    }
}