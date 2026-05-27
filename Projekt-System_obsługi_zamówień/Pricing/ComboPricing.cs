using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystem.Pricing
{
    // Strategia przygotowana pod zestawy promocyjne
    public class ComboPricing : IPricingStrategy
    {
        public decimal ComboPrice { get; set; }

        public ComboPricing(decimal comboPrice)
        {
            ComboPrice = comboPrice;
        }

        public decimal Calculate(Order order)
        {
            // TODO:
            // implementacja zestawów typu:
            // Burger + Cola = 30 zł

            return ComboPrice;
        }
    }
}