using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystem.Pricing
{
    // Strategia odpowiedzialna za naliczanie rabatu
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

        // TODO:
        // dodać różne typy promocji (czasowe np.: happy hours 10% zniżki po 18:00)
    }
}