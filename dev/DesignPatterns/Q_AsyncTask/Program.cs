Console.WriteLine(DateTime.Now);

Task<string> s = Execution3();
Console.WriteLine(DateTime.Now);

Console.ReadLine();
//string Execution1()
//{
//    Console.WriteLine("Début exécution");
//    Thread.Sleep(5000);
//    Console.WriteLine("Fin exécution");

//}
//async Task<string> Execution2()
//{
//    Console.WriteLine("Début exécution");
//    await Task.Delay(TimeSpan.FromSeconds(5));
//    Console.WriteLine("Fin exécution");
//    return "Ok";
//}
async Task<string> Execution3()
{
    Console.WriteLine("Début exécution");
    await Wait3();
    Console.WriteLine("Fin exécution");
    return "Ok";
}

async Task Wait3()
{
    await Task.Delay(TimeSpan.FromSeconds(5));
    Console.WriteLine("5 secondes d'attente.");
}