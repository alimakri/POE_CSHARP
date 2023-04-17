using I_Adapter;

var adapter = new PersonneAdapter(new ExternalPersonneApiService());

var p = adapter.GetPersonne();
Console.WriteLine(p.LastName);
Console.WriteLine(p.FirstName);
