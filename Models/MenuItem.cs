namespace RestaurantOrderSystem.Models
{
    // Klasa bazowa dla wszystkich produktów z menu
    public abstract class MenuItem
    {
        // Nazwa produktu
        public string Name { get; set; }

        // Podstawowa cena produktu
        public decimal BasePrice { get; set; }

        // Opis produktu
        public string Description { get; set; }

        protected MenuItem(
            string name,
            decimal basePrice,
            string description)
        {
            Name = name;
            BasePrice = basePrice;
            Description = description;
        }

        // Podstawowe obliczanie ceny produktu
        public virtual decimal CalculatePrice()
        {
            return BasePrice;
        }

        // Zwraca opis produktu
        public virtual string GetDescription()
        {
            return $"{Name} - {CalculatePrice()} zł";
        }
    }
}