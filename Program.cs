using RestaurantOrderSystem.Models;
using RestaurantOrderSystem.Pricing;
using RestaurantOrderSystem.Services;

namespace RestaurantOrderSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restaurant restaurant = new Restaurant();

            // Produkty w menu
            Drink cola = new Drink("Cola", 8, "Cold drink", 500);
            Drink orangeJuice = new Drink("Orange Juice", 10, "Fresh orange juice", 400);
            Drink water = new Drink("Water", 5, "Still mineral water", 500);
            Drink americano = new Drink("Americano", 9, "Classic americano", 300);
            Drink espresso = new Drink("Espresso", 7, "Strong espresso", 100);
            Drink cappuccino = new Drink("Cappuccino", 11, "Coffee with milk foam", 300);
            Meal burger = new Meal("Burger", 25, "Classic beef burger", false);
            Meal spicyBurger = new Meal("Spicy Burger", 25, "Spicy beef burger", true);
            Meal fries = new Meal("Fries", 10, "Crispy fries", false);
            Meal pizza = new Meal("Pizza", 28, "Pepperoni", false);
            Dessert iceCream = new Dessert("Ice Cream", 12, "Vanilla ice cream", true);
            Dessert applePie = new Dessert("Apple Pie", 15, "Warm apple pie", false);
            Dessert chocolateCake = new Dessert("Lava Cake", 16, "Warm chocolate cake", false);

            restaurant.AddMenuItem(cola);
            restaurant.AddMenuItem(orangeJuice);
            restaurant.AddMenuItem(water);
            restaurant.AddMenuItem(americano);
            restaurant.AddMenuItem(espresso);
            restaurant.AddMenuItem(cappuccino);

            restaurant.AddMenuItem(burger);
            restaurant.AddMenuItem(spicyBurger);
            restaurant.AddMenuItem(fries);
            restaurant.AddMenuItem(pizza);

            restaurant.AddMenuItem(iceCream);
            restaurant.AddMenuItem(applePie);
            restaurant.AddMenuItem(chocolateCake);

            OrderService orderService =new OrderService();

            PaymentService paymentService =new PaymentService();

            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("===== RESTAURANT SYSTEM =====");
                Console.WriteLine("1. Show menu");
                Console.WriteLine("2. Create order");
                Console.WriteLine("3. Show orders");
                Console.WriteLine("4. Change order status");
                Console.WriteLine("5. Apply discount");
                Console.WriteLine("6. Pay order");
                Console.WriteLine("7. Show statistics");
                Console.WriteLine("8. Exit");
                Console.WriteLine("9. Test exceptions");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            restaurant.ShowMenu();
                            break;

                        case "2":
                            CreateOrder(restaurant);
                            break;

                        case "3":
                            restaurant.ShowAllOrders();
                            break;

                        case "4":
                            ChangeStatus(restaurant);
                            break;

                        case "5":
                            ApplyDiscount(restaurant);
                            break;

                        case "6":
                            PayOrder(restaurant,paymentService);
                            break;

                        case "7":
                            orderService.ShowOrderStatistics(restaurant.Orders);
                            break;

                        case "8":
                            running = false;
                            break;

                        case "9":
                            TestExceptions(restaurant);
                            break;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Error: {ex.Message}");
                }
            }
        }

        static void CreateOrder(Restaurant restaurant)
        {
            Order order = restaurant.CreateOrder();

            bool addingProducts = true;

            while (addingProducts)
            {
                restaurant.ShowMenu();

                Console.WriteLine();
                Console.Write("Product number: ");

                if (!int.TryParse(Console.ReadLine(),out int productNumber))
                {
                    Console.WriteLine("Invalid product number.");

                    return;
                }

                if (productNumber < 1 || productNumber > restaurant.Menu.Count)
                {
                    Console.WriteLine("Product does not exist.");

                    return;
                }

                Console.Write("Quantity: ");

                int quantity =int.Parse(Console.ReadLine());

                MenuItem selectedItem =restaurant.Menu[productNumber - 1];
                order.AddItem(new OrderItem(selectedItem, quantity));
                Console.WriteLine("Add another product? (y/n)");

                string answer =Console.ReadLine();

                if (answer.ToLower() != "y")
                {
                    addingProducts = false;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Order #{order.Id} created.");

            order.ShowOrder();
        }

        static void ChangeStatus(Restaurant restaurant)
        {
            Console.Write("Order ID: ");

            int id =int.Parse(Console.ReadLine());

            Order order =
                restaurant.GetOrderById(id);

            Console.WriteLine(
                "1.Pending 2.Preparing 3.Ready 4.Completed 5.Cancelled");

            int status =int.Parse(Console.ReadLine());
            order.ChangeStatus((OrderStatus)(status - 1));
            Console.WriteLine("Status updated.");
        }

        static void ApplyDiscount(Restaurant restaurant)
        {
            Console.Write("Order ID: ");

            int id =int.Parse(Console.ReadLine());

            Order order =restaurant.GetOrderById(id);

            Console.Write("Discount %: ");

            decimal discount = decimal.Parse(Console.ReadLine());

            order.PricingStrategy = new DiscountPricing(discount);

            Console.WriteLine($"New total: {order.CalculateTotal()} zł");
        }
        static void PayOrder(
    Restaurant restaurant,
    PaymentService paymentService)
        {
            Console.Write("Order ID: ");

            int id =
                int.Parse(Console.ReadLine());

            Order order =
                restaurant.GetOrderById(id);

            if (order.IsPaid)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Order has already been paid.");

                return;
            }

            Console.WriteLine();
            Console.WriteLine(
                $"Amount to pay: {order.CalculateTotal()} zł");

            Console.WriteLine();
            Console.WriteLine("1. Cash");
            Console.WriteLine("2. Card");

            string paymentMethod =
                Console.ReadLine();

            bool paymentSuccess = false;

            if (paymentMethod == "1")
            {
                Console.Write(
                    "Customer paid: ");

                decimal paidAmount =
                    decimal.Parse(Console.ReadLine());

                paymentSuccess =
                    paymentService.PayCash(
                        order.CalculateTotal(),
                        paidAmount);
            }
            else
            {
                paymentSuccess =
                    paymentService.PayCard(
                        order.CalculateTotal());
            }

            if (paymentSuccess)
            {
                order.IsPaid = true;

                order.ChangeStatus(
                    OrderStatus.Completed);

                paymentService.PrintReceipt(
                    order.CalculateTotal());

                Console.WriteLine();
                Console.WriteLine(
                    "Order completed.");
            }
        }
        static void TestExceptions(Restaurant restaurant)
        {
            Console.WriteLine();
            Console.WriteLine(
                "===== EXCEPTION TESTS =====");

            // InvalidQuantityException
            try
            {
                Meal burger = new Meal("Burger", 25, "Beef burger",true);
                OrderItem item = new OrderItem(burger, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Quantity error: {ex.Message}");
            }

            // InvalidOrderException
            try
            {
                restaurant.GetOrderById(999);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Order error: {ex.Message}");
            }

            // MenuItemNotFoundException
            try
            {
                restaurant.FindMenuItem("Hot Dog");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Menu item error: {ex.Message}");
            }

            // InvalidStatusException
            try
            {
                Order order = restaurant.CreateOrder();

                order.ChangeStatus(OrderStatus.Completed);

                order.ChangeStatus(OrderStatus.Preparing);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Status error: {ex.Message}");
            }
        }
    }
}