namespace RestaurantOrderSystem.Services
{
    // Klasa odpowiedzialna za obsługę płatności
    public class PaymentService
    {
        // Płatność gotówką z wydaniem reszty
        public bool PayCash(decimal amount, decimal paidAmount)
        {
            if (paidAmount < amount)
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"Not enough money. Missing: {amount - paidAmount} zł");

                return false;
            }

            decimal change = paidAmount - amount;

            Console.WriteLine();
            Console.WriteLine($"Order amount: {amount} zł");
            Console.WriteLine($"Paid: {paidAmount} zł");
            Console.WriteLine($"Change: {change} zł");

            return true;
        }

        // Płatność kartą
        public bool PayCard(decimal amount)
        {
            Console.WriteLine();
            Console.WriteLine(
                $"Card payment accepted: {amount} zł");

            return true;
        }

        // Generowanie rachunku
        public void PrintReceipt(decimal amount)
        {
            Console.WriteLine();
            Console.WriteLine("===== RECEIPT =====");

            Console.WriteLine(
                $"Amount paid: {amount} zł");

            Console.WriteLine(
                $"Date: {DateTime.Now}");

            Console.WriteLine("===================");
        }
    }
}