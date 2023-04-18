//var tache1 = new Task(new Action(Execution));
var tache1 = new Task(Execution);
var tache2 = new Task(Execution);
Console.WriteLine(DateTime.Now);

//tache1.Start();
Task.WaitAll(new Task[] { tache1, tache2 });
Console.WriteLine("Fin des tâches");
Console.WriteLine(DateTime.Now);

Console.ReadLine();

static void Execution()
{
    Thread.Sleep(5000);
    Console.WriteLine("Fin");
}