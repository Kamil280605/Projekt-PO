using RestaurantOrderSystem.Exceptions;

namespace RestaurantOrderSystem.Models
{
    // Reprezentuje pojedynczą pozycję zamówienia
    public class OrderItem
    {
        // Produkt z menu
        public MenuItem MenuItem { get; set; }

        // Ilość produktu
        public int Quantity { get; set; }

        public OrderItem(MenuItem menuItem, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InvalidQuantityException(
                    "Quantity must be greater than 0.");
            }

            MenuItem = menuItem;
            Quantity = quantity;
        }

        // Oblicza całkowitą cenę pozycji
        public decimal GetTotalPrice()
        {
            return MenuItem.CalculatePrice() * Quantity;
        }

        // Zmiana ilości produktu
        public void ChangeQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new InvalidQuantityException(
                    "Quantity must be greater than 0.");
            }

            Quantity = quantity;
        }
    }
}