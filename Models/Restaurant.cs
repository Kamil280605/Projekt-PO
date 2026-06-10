using RestaurantOrderSystem.Exceptions;

namespace RestaurantOrderSystem.Models
{
    // Klasa zarządzająca restauracją, menu oraz zamówieniami
    public class Restaurant
    {
        // Lista produktów dostępnych w menu
        public List<MenuItem> Menu { get; set; }

        // Lista wszystkich zamówień
        public List<Order> Orders { get; set; }

        public Restaurant()
        {
            Menu = new List<MenuItem>();
            Orders = new List<Order>();
        }

        // Dodaje produkt do menu
        public void AddMenuItem(MenuItem item)
        {
            Menu.Add(item);
        }

        // Wyświetla całe menu
        public void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== MENU =====");

            Console.WriteLine();
            Console.WriteLine("----- DRINKS -----");

            int index = 1;

            foreach (var item in Menu)
            {
                if (item is Drink)
                {
                    Console.WriteLine($"{index}. {item.GetDescription()}");
                }

                index++;
            }

            Console.WriteLine();
            Console.WriteLine("----- MEALS -----");

            index = 1;

            foreach (var item in Menu)
            {
                if (item is Meal)
                {
                    Console.WriteLine($"{index}. {item.GetDescription()}");
                }

                index++;
            }

            Console.WriteLine();
            Console.WriteLine("----- DESSERTS -----");

            index = 1;

            foreach (var item in Menu)
            {
                if (item is Dessert)
                {
                    Console.WriteLine($"{index}. {item.GetDescription()}");
                }

                index++;
            }

            Console.WriteLine();
            Console.WriteLine("----- COMBOS -----");
            Console.WriteLine("Burger + Fries + Cola = 35 zł");
            Console.WriteLine("Spicy Burger + Fries + Cola = 37 zł");
            Console.WriteLine("Pizza + Cola = 35 zł");
            Console.WriteLine("Americano + Apple Pie = 20 zł");
            Console.WriteLine("Cappuccino + Chocolate Cake = 24 zł");
            Console.WriteLine("Espresso + Ice Cream = 18 zł");
        }

        // Tworzy nowe zamówienie
        public Order CreateOrder()
        {
            Order order = new Order(Orders.Count + 1);

            Orders.Add(order);

            return order;
        }

        // Wyszukuje zamówienie po ID
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

        // Wyszukuje produkt po nazwie
        public MenuItem FindMenuItem(string name)
        {
            foreach (var item in Menu)
            {
                if (item.Name.Equals(
                    name,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }

            throw new MenuItemNotFoundException(
                "Menu item not found.");
        }

        // Wyświetla wszystkie zamówienia
        public void ShowAllOrders()
        {
            Console.WriteLine("===== ORDERS =====");

            foreach (var order in Orders)
            {
                Console.WriteLine(
                    $"Order #{order.Id} - {order.Status}");
            }
        }

        // Usuwa zamówienie
        public void RemoveOrder(int id)
        {
            Order order = GetOrderById(id);

            Orders.Remove(order);
        }
    }
}