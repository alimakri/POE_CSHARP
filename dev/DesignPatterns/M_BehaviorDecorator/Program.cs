using M_BehaviorDecorator;

var azure = new AzureNewsLetterSender();
var db = new NewsLetterSenderDatabaseDecorator(azure);
var stats = new NewsLetterSenderStatsDecorator(db);

stats.SendNewsLetter("News Letter 1");
stats.SendNewsLetter("News Letter 2");

Console.WriteLine("Nb news letter envoyé: {0}", NewsLetterSenderStatsDecorator.NbNewsLetterSent);