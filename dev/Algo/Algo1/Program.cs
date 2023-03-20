Console.WriteLine("Deviner un nombre compris entre 1 et 99");
Random alea = new Random();
int nombreADeviner = alea.Next(1, 100);
//Console.WriteLine(nombreADeviner);
// 16:17
int proposition = 0;
int nCoup = 0; bool partieFinie = false;
while (!partieFinie)
{
    nCoup++;
    if (nCoup == 8)
    {
        Console.WriteLine("Perdu");
        partieFinie = true;
    }
    else
    {
        Console.Write("Proposition : ");
        var propositionStr = Console.ReadLine();
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
                partieFinie = true;
            }
        }
        else
        {
            Console.WriteLine("Nombre incorrect");
        }
    }
}
Console.ReadLine();
