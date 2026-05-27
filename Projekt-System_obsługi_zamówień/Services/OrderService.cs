using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystem.Services
{
    // Klasa zawierająca dodatkową logikę biznesową zamówień
    public class OrderService
    {
        public void PrintOrderSummary(Order order)
        {
            Console.WriteLine("=== ORDER SUMMARY ===");

            order.ShowOrder();
        }

        // TODO:
        // statystyki sprzedaży(liczba zamówien/najpopularniejsze produkty)

        // TODO:
        // raport dzienny zamówień
    }
}