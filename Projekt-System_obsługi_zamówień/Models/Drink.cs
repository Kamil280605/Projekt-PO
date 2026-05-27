namespace RestaurantOrderSystem.Models
{
    public class Drink : MenuItem
    {
        // Klasa reprezentująca napój
        public int Volume { get; set; }

        public Drink(string name, decimal basePrice, int volume)
            : base(name, basePrice)
        {
            Volume = volume;
        }

        public override decimal CalculatePrice()
        {
            return BasePrice + (Volume * 0.01m);
        }

        // TODO:
        // dodać rozmiary napojów (small/medium/large)
    }
}