Random alea = new Random();
string nom = "";
int proposition = 0;
int nombreADeviner;
int nCoup = 0;
bool partieFinie;
string[] scores = new string[10];
int index = 0;

// Pour tester ----------
scores[0] = "André|5";
scores[1] = "Monique|4";
index = 2;
// ----------------------

while (true)
{
    Console.Write("Votre nom : ");
    nom = Console.ReadLine();

    Console.WriteLine("{0}, deviner un nombre compris entre 1 et 99", nom);
    nombreADeviner = alea.Next(1, 100);
    //Console.WriteLine(nombreADeviner);
    nCoup = 0; partieFinie = false;
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
            Console.Write("Proposition {0} : ", nCoup);
            var propositionStr = Console.ReadLine();
            if (int.TryParse(propositionStr, out proposition))
            {
                if (proposition < nombreADeviner) 
                    Console.WriteLine("Trop petit");
                else if (proposition > nombreADeviner) 
                    Console.WriteLine("Trop grand");
                else
                {
                    Console.WriteLine("Gagné");
                    partieFinie = true;
                    scores[index] = nom + "|" + nCoup;
                    index++;
                    if (index == scores.Length) index = 0;
                    for (int i = 0; i < scores.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(scores[i]);
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else
                Console.WriteLine("Saisie incorrecte");
        }
    }
    Console.ReadLine();
}
