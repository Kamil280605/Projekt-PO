using RestaurantOrderSystem.Exceptions;

namespace RestaurantOrderSystem.Models
{
    // Klasa zarządzająca menu i zamówieniami restauracji
    public class Restaurant
    {
        public List<MenuItem> Menu { get; set; }

        public List<Order> Orders { get; set; }

        public Restaurant()
        {
            Menu = new List<MenuItem>();
            Orders = new List<Order>();
        }

        public void AddMenuItem(MenuItem item)
        {
            Menu.Add(item);
        }

        public void ShowMenu()
        {
            Console.WriteLine("=== MENU ===");

            foreach (var item in Menu)
            {
                Console.WriteLine(item.GetDescription());
            }
        }

        // Tworzenie nowego zamówienia
        public Order CreateOrder()
        {
            Order order = new Order(Orders.Count + 1);

            Orders.Add(order);

            return order;
        }

        // Pobieranie zamówienia po ID
        public Order GetOrderById(int id)
        {
            foreach (var order in Orders)
            {
                if (order.Id == id)
                {
                    return order;
                }
            }

            throw new InvalidOrderException(
                "Order not found.");
        }

        // Wyszukiwanie produktu po nazwie
        public MenuItem FindMenuItem(string name)
        {
            foreach (var item in Menu)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }

            throw new MenuItemNotFoundException(
                "Menu item not found.");
        }

        // TODO:
        // usuwanie zamówień

        // TODO:
        // historia wszystkich zamówień
    }
}