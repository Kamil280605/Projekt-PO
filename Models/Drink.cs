namespace RestaurantOrderSystem.Models
{
    // Klasa reprezentująca napój
    public class Drink : MenuItem
    {
        // Objętość napoju w ml
        public int Volume { get; set; }

        public Drink(
            string name,
            decimal basePrice,
            string description,
            int volume)
            : base(name, basePrice, description)
        {
            Volume = volume;
        }

        // Cena napoju zależy od objętości
        public override decimal CalculatePrice()
        {
            return BasePrice + (Volume * 0.01m);
        }

        public override string GetDescription()
        {
            return $"{Name} {Volume}ml - {CalculatePrice()} zł";
        }
    }
}