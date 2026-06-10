using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystem.Pricing
{
    // Strategia obsługująca zestawy promocyjne
    public class ComboPricing : IPricingStrategy
    {
        public decimal Calculate(Order order)
        {
            decimal total = 0;

            int burgers = 0;
            int spicyBurgers = 0;
            int fries = 0;
            int pizzas = 0;
            int colas = 0;
            int americanos = 0;
            int espressos = 0;
            int cappuccinos = 0;
            int iceCreams = 0;
            int applePies = 0;
            int chocolateCakes = 0;

            foreach (var item in order.Items)
            {
                total += item.GetTotalPrice();

                switch (item.MenuItem.Name)
                {
                    case "Burger":
                        burgers += item.Quantity;
                        break;

                    case "Spicy Burger":
                        spicyBurgers += item.Quantity;
                        break;

                    case "Fries":
                        fries += item.Quantity;
                        break;

                    case "Pizza":
                        pizzas += item.Quantity;
                        break;

                    case "Cola":
                        colas += item.Quantity;
                        break;

                    case "Americano":
                        americanos += item.Quantity;
                        break;

                    case "Espresso":
                        espressos += item.Quantity;
                        break;

                    case "Cappuccino":
                        cappuccinos += item.Quantity;
                        break;

                    case "Ice Cream":
                        iceCreams += item.Quantity;
                        break;

                    case "Apple Pie":
                        applePies += item.Quantity;
                        break;

                    case "Chocolate Cake":
                        chocolateCakes += item.Quantity;
                        break;
                }
            }

            // Burger + Fries + Cola = 35 zł
            int burgerComboCount =Math.Min(burgers, Math.Min(fries, colas));
            decimal burgerComboDiscount = (25 + 10 + 13) - 35;
            total -= burgerComboCount * burgerComboDiscount;

            // BurgerSpicy + Fries + Cola = 37 zł
            int spicyBurgerComboCount = Math.Min(spicyBurgers, Math.Min(fries, colas));
            decimal spicyBurgerComboDiscount = (27 + 10 + 13) - 37;
            total -= spicyBurgerComboCount * spicyBurgerComboDiscount;

            // Pizza + Cola = 35 zł
            int pizzaComboCount = Math.Min(pizzas, colas);
            decimal pizzaComboDiscount = (28 + 13) - 35;
            total -= pizzaComboCount * pizzaComboDiscount;

            // Americano + Apple Pie = 20 zł
            int americanoCombo = Math.Min(americanos, applePies);
            decimal americanoDiscount = (12 + 15) - 20;
            total -= americanoCombo * americanoDiscount;
            americanos -= americanoCombo;
            applePies -= americanoCombo;

            // Cappuccino + Chocolate Cake = 24 zł
            int cappuccinoCombo = Math.Min(cappuccinos, chocolateCakes);
            decimal cappuccinoDiscount = (14 + 16) - 24;
            total -= cappuccinoCombo * cappuccinoDiscount;
            cappuccinos -= cappuccinoCombo;
            chocolateCakes -= cappuccinoCombo;

            // Espresso + Ice Cream = 18 zł
            int espressoCombo =Math.Min(espressos, iceCreams);
            decimal espressoDiscount = (8 + 12) - 18;
            total -= espressoCombo * espressoDiscount;
            espressos -= espressoCombo;
            iceCreams -= espressoCombo;

            return total;
        }
    }
}