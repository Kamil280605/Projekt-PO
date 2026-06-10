namespace RestaurantOrderSystem.Exceptions
{
    // Wyjątek rzucany przy niepoprawnej zmianie statusu
    public class InvalidStatusException : Exception
    {
        public InvalidStatusException(string message)
            : base(message)
        {
        }
    }
}