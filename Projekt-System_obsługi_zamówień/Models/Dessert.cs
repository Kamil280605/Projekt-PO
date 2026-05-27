namespace RestaurantOrderSystem.Models
{
    public class Dessert : MenuItem
    {
        // Klasa reprezentująca deser
        public bool IsCold { get; set; }

        public Dessert(string name, decimal basePrice, bool isCold)
            : base(name, basePrice)
        {
            IsCold = isCold;
        }

        public override decimal CalculatePrice()
        {
            return BasePrice;
        }

        // TODO:
        // obsługa dodatków do deserów (polewy/owoce/bita śmietana)
    }
}