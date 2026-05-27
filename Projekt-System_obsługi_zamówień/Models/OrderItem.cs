namespace RestaurantOrderSystem.Models
{
    // Klasa reprezentująca pojedynczą pozycję zamówienia
    public class OrderItem
    {
        public MenuItem MenuItem { get; set; }

        public int Quantity { get; set; }

        public OrderItem(MenuItem menuItem, int quantity)
        {
            MenuItem = menuItem;
            Quantity = quantity;
        }

        public decimal GetTotalPrice()
        {
            return MenuItem.CalculatePrice() * Quantity;
        }

        // TODO:
        // walidacja quantity > 0
    }
}