namespace RestaurantOrderSystem.Models
{
    // Klasa bazowa dla wszystkich produktów z menu
    public abstract class MenuItem
    {
        public string Name { get; set; }

        public decimal BasePrice { get; set; }

        public MenuItem(string name, decimal basePrice)
        {
            Name = name;
            BasePrice = basePrice;
        }

        // Podstawowe liczenie ceny
        public virtual decimal CalculatePrice()
        {
            return BasePrice;
        }

        public virtual string GetDescription()
        {
            return $"{Name} - {BasePrice} zł";
        }

        // TODO:
        // dodać kategorię produktu
    }
}