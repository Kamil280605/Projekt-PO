using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystem.Pricing
{
    // Standardowe liczenie ceny zamówienia
    public class StandardPricing : IPricingStrategy
    {
        public decimal Calculate(Order order)
        {
            decimal total = 0;

            foreach (var item in order.Items)
            {
                total += item.GetTotalPrice();
            }

            return total;
        }
    }
}