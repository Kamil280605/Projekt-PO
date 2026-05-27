namespace RestaurantOrderSystem.Exceptions
{
    // Wyjątek rzucany gdy produkt nie istnieje w menu
    public class MenuItemNotFoundException : Exception
    {
        public MenuItemNotFoundException(string message)
            : base(message)
        {
        }
    }
}