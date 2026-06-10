namespace RestaurantOrderSystem.Exceptions
{
    // Wyjątek rzucany przy niepoprawnej ilości produktu
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException(string message)
            : base(message)
        {
        }
    }
}