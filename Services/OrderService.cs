using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystem.Services
{
    // Klasa zawierająca dodatkowe operacje związane z zamówieniami
    public class OrderService
    {
        // Wyświetla szczegółowe podsumowanie zamówienia
        public void PrintOrderSummary(Order order)
        {
            Console.WriteLine();
            Console.WriteLine("===== ORDER SUMMARY =====");

            order.ShowOrder();

            Console.WriteLine();
        }

        // Wyświetla tylko zakończone zamówienia
        public void ShowCompletedOrders(List<Order> orders)
        {
            Console.WriteLine("===== COMPLETED ORDERS =====");

            foreach (var order in orders)
            {
                if (order.Status == OrderStatus.Completed)
                {
                    Console.WriteLine(
                        $"Order #{order.Id} - {order.CalculateTotal()} zł");
                }
            }
        }

        // Wyświetla liczbę wszystkich zamówień
        public void ShowOrderStatistics(List<Order> orders)
        {
            int totalOrders = 0;
            int completedOrders = 0;

            foreach (var order in orders)
            {
                if (order.Status == OrderStatus.Cancelled)
                {
                    continue;
                }

                totalOrders++;

                if (order.Status == OrderStatus.Completed)
                {
                    completedOrders++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("===== STATISTICS =====");

            Console.WriteLine(
                $"Total orders: {totalOrders}");

            Console.WriteLine(
                $"Completed orders: {completedOrders}");
        }
    }
}