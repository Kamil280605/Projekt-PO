namespace RestaurantOrderSystem.Models
{
    // Enum określający status zamówienia
    public enum OrderStatus
    {
        Pending,
        Preparing,
        Ready,
        Completed,
        Cancelled
    }
}