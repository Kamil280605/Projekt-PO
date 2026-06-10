namespace RestaurantOrderSystem.Exceptions
{
    public class InvalidOrderException : Exception
    {
        // Wyjątek rzucany gdy zamówienie nie istnieje
        public InvalidOrderException(string message)
            : base(message)
        {
        }
    }
}