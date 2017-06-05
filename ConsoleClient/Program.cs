
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileWatcherDAL.ContextFactory;
using FileWatcherDAL.Models;
using FileWatcherModel;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWatcherContextFactory fileWatcherContext = new FileWatcherContextFactory();
            using (var db= fileWatcherContext.ContextObject)
            {
                // добавление элементов
                db.ClientSet.Add(new Client() { ClientName = "Tom" });
                db.ManagerSet.Add(new Manager() { ManagerName = "John" });
                db.SaveChanges();
                // получение элементов
                var users = db.ClientSet;
                foreach (Client u in users)
                    Console.WriteLine("{0}.{1} ", u.Id, u.ClientName);
            }
            Console.Read();
        }
    }
}
