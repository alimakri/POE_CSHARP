using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_BehaviorDecorator
{
    public interface INewsLetterSender
    {
        bool SendNewsLetter(string content);
    }
    public class AzureNewsLetterSender : INewsLetterSender
    {
        public bool SendNewsLetter(string content)
        {
            Console.WriteLine("Mails envoyés avec succès depuis Azure" + content);
            return true;
        }
    }
    public class NewsLetterSenderDecorator : INewsLetterSender
    {
        private readonly INewsLetterSender Sender;
        public NewsLetterSenderDecorator(INewsLetterSender sender)
        {
            Sender = sender;
        }
        public virtual bool SendNewsLetter(string content)
        {
            return Sender.SendNewsLetter(content);
        }
    }
    public class NewsLetterSenderDatabaseDecorator : NewsLetterSenderDecorator
    {
        public NewsLetterSenderDatabaseDecorator(INewsLetterSender sender) : base(sender)
        {
        }
        public override bool SendNewsLetter(string content)
        {
            Console.WriteLine("Sauvegarde en BDD du contenu : {0}", content);
            return base.SendNewsLetter(content);
        }
    }
    public class NewsLetterSenderStatsDecorator : NewsLetterSenderDecorator
    {
        public static int NbNewsLetterSent = 0;
        public NewsLetterSenderStatsDecorator(INewsLetterSender sender) : base(sender)
        {
        }
        public override bool SendNewsLetter(string content)
        {
            NbNewsLetterSent++;
            return base.SendNewsLetter(content);
        }
    }
}
