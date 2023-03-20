Console.WriteLine("Deviner un nombre compris entre 1 et 99");
Random alea = new Random();
int nombreADeviner = alea.Next(1, 100);
//Console.WriteLine(nombreADeviner);

int proposition = 0;
int nCoup = 0;
while (proposition != nombreADeviner)
{
    Console.Write("Proposition : ");
    var propositionStr = Console.ReadLine();
    nCoup++;
    if (int.TryParse(propositionStr, out proposition))
    {
        if (proposition < nombreADeviner)
        {
            Console.WriteLine("Trop petit");
        }
        else if (proposition > nombreADeviner)
        {
            Console.WriteLine("Trop grand");
        }
        else
        {
            Console.WriteLine("Gagné");
        }
    }
    else
    {
        Console.WriteLine("Nombre incorrect");
    }
}
Console.ReadLine();
