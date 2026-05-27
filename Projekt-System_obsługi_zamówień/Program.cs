using RestaurantOrderSystem.Models;
using RestaurantOrderSystem.Pricing;
using RestaurantOrderSystem.Services;

namespace RestaurantOrderSystem
{
    // Główna klasa uruchamiająca aplikację
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Restaurant restaurant = new Restaurant();

                // Tworzenie produktów
                Drink cola = new Drink("Cola", 8, 500);
                Meal burger = new Meal("Burger", 25, true);
                Dessert iceCream = new Dessert("Ice Cream", 12, true);

                // Dodawanie produktów do menu
                restaurant.AddMenuItem(cola);
                restaurant.AddMenuItem(burger);
                restaurant.AddMenuItem(iceCream);

                // Wyświetlenie menu
                restaurant.ShowMenu();

                Console.WriteLine();

                // Tworzenie zamówienia
                Order order = restaurant.CreateOrder();

                // Dodawanie produktów do zamówienia
                order.AddItem(
                    new OrderItem(cola, 2));

                order.AddItem(
                    new OrderItem(burger, 1));

                Console.WriteLine("=== STANDARD PRICE ===");

                order.ShowOrder();

                Console.WriteLine();

                // Zastosowanie rabatu
                order.PricingStrategy = new DiscountPricing(10);

                Console.WriteLine("=== DISCOUNT PRICE ===");

                Console.WriteLine(order.CalculateTotal() + " zł");

                Console.WriteLine();

                // Zmiana statusu
                order.ChangeStatus(OrderStatus.Preparing);

                Console.WriteLine($"Current status: {order.Status}");

                Console.WriteLine();

                // Wywołanie serwisu
                OrderService orderService = new OrderService();

                orderService.PrintOrderSummary(order);

                // TODO:
                // menu wyboru dla użytkownika (1. Show menu 2.Create order 3.Show orders 4.Exit)

                // TODO:
                // logowanie użytkowników(np. menadzer/kelner/kuchnia)

                // TODO:
                // system promocji(automatyczne naliczanie promocji)
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}