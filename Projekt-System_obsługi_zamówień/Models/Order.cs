using RestaurantOrderSystem.Exceptions;
using RestaurantOrderSystem.Pricing;

namespace RestaurantOrderSystem.Models
{
    // Klasa reprezentująca zamówienie klienta
    public class Order
    {
        public int Id { get; set; }

        public List<OrderItem> Items { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public IPricingStrategy PricingStrategy { get; set; }

        public Order(int id)
        {
            Id = id;
            Items = new List<OrderItem>();
            Status = OrderStatus.Pending;
            CreatedAt = DateTime.Now;

            PricingStrategy = new StandardPricing();
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        // Obliczanie końcowej ceny
        public decimal CalculateTotal()
        {
            return PricingStrategy.Calculate(this);
        }

        // Zmiana statusu zamówienia
        public void ChangeStatus(OrderStatus newStatus)
        {
            // TODO:
            // dodać pełną walidację przejść statusów

            if (Status == OrderStatus.Completed)
            {
                throw new InvalidStatusException(
                    "Completed order cannot be changed.");
            }

            Status = newStatus;
        }

        // Wyświetlanie zamówienia
        public void ShowOrder()
        {
            Console.WriteLine($"Order ID: {Id}");
            Console.WriteLine($"Status: {Status}");

            foreach (var item in Items)
            {
                Console.WriteLine(
                    $"{item.MenuItem.Name} x{item.Quantity}");
            }

            Console.WriteLine(
                $"Total: {CalculateTotal()} zł");
        }

        // TODO:
        // zapis zamówienia do pliku
    }
}