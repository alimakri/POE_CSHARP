using C_AbstractFactory;

var client = new Customer();
var clientVIP = new Customer { Orders = new int[50] };

IVIPShoppingFactory GetFactory(Customer c)
{
    if (c.Orders.Length > 30) return new VIPShoppingFactory();
    return new StandardShoppingFactory();
}

IVIPShoppingFactory factory1 = GetFactory(client);
IVIPShoppingFactory factory2 = GetFactory(clientVIP);

var shoppingCart1 = new ShoppingCart(factory1); 
var shoppingCart2 = new ShoppingCart(factory2);

Console.WriteLine("shoppingCart1");
shoppingCart1.PasserCommande(); 

Console.WriteLine("shoppingCart2");
shoppingCart2.PasserCommande();