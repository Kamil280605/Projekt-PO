using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystem.Pricing
{
    // Strategia odpowiedzialna za naliczanie rabatu procentowego
    public class DiscountPricing : IPricingStrategy
    {
        public decimal DiscountPercent { get; set; }

        public DiscountPricing(decimal discountPercent)
        {
            DiscountPercent = discountPercent;
        }

        public decimal Calculate(Order order)
        {
            decimal total = 0;

            foreach (var item in order.Items)
            {
                total += item.GetTotalPrice();
            }

            return total - (total * DiscountPercent / 100);
        }
    }
}