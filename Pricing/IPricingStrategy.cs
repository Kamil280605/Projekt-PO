using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystem.Pricing
{
    // Interfejs odpowiedzialny za strategie liczenia ceny
    public interface IPricingStrategy
    {
        decimal Calculate(Order order);
    }
}