using ExercicioComposicao.Entities;
using ExercicioComposicao.Entities.Enums;
using System.Globalization;
using System.Transactions;

namespace ExercicioComposicao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            Order order = new Order(client, DateTime.Now, status);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product price: ");
                double prodPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int prodQty = int.Parse(Console.ReadLine());
                
                Product prod = new Product(prodName, prodPrice);
                OrderItem orderItem = new OrderItem(prod, prodQty, prodPrice);
                order.AddItem(orderItem);
            }
            Console.WriteLine();
            Console.WriteLine(order);

        }
    }
}
