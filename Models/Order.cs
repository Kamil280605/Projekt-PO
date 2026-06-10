using RestaurantOrderSystem.Exceptions;
using RestaurantOrderSystem.Pricing;

namespace RestaurantOrderSystem.Models
{
    // Klasa reprezentująca zamówienie klienta
    public class Order
    {
        // Identyfikator zamówienia
        public int Id { get; set; }

        // Lista pozycji w zamówieniu
        public List<OrderItem> Items { get; set; }

        // Aktualny status zamówienia
        public OrderStatus Status { get; set; }

        // Data utworzenia zamówienia
        public DateTime CreatedAt { get; set; }

        // Strategia liczenia ceny
        public IPricingStrategy PricingStrategy { get; set; }

        // Informacja czy zamówienie zostało opłacone
        public bool IsPaid { get; set; }

        public Order(int id)
        {
            Id = id;
            Items = new List<OrderItem>();
            Status = OrderStatus.Pending;
            CreatedAt = DateTime.Now;

            PricingStrategy = new StandardPricing();

            IsPaid = false;
        }

        // Dodaje pozycję do zamówienia
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        // Usuwa pozycję z zamówienia
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        // Oblicza końcową wartość zamówienia
        public decimal CalculateTotal()
        {
            decimal standardTotal =
                new StandardPricing().Calculate(this);

            decimal comboTotal =
                new ComboPricing().Calculate(this);

            return Math.Min(standardTotal, comboTotal);
        }

        // Zmienia status zamówienia
        public void ChangeStatus(OrderStatus newStatus)
        {
            if (Status == OrderStatus.Completed)
            {
                throw new InvalidStatusException(
                    "Completed order cannot be modified.");
            }

            if (Status == OrderStatus.Cancelled)
            {
                throw new InvalidStatusException(
                    "Cancelled order cannot be modified.");
            }

            Status = newStatus;
        }

        // Wyświetla szczegóły zamówienia
        public void ShowOrder()
        {
            Console.WriteLine($"Order ID: {Id}");
            Console.WriteLine($"Created: {CreatedAt}");
            Console.WriteLine($"Status: {Status}");

            Console.WriteLine("--------------------");

            foreach (var item in Items)
            {
                Console.WriteLine($"{item.MenuItem.Name} x{item.Quantity} = {item.GetTotalPrice()} zł");
            }

            Console.WriteLine("--------------------");
            Console.WriteLine($"Total: {CalculateTotal()} zł");
        }
    }
}