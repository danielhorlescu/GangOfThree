using System;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework;

namespace MVCSkeleton.DatabaseCreator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new MVCSkeletonDataContext())
            {
                if (db.Database.Exists())
                {
                    Console.WriteLine("Existing database found.");
                    db.Database.Delete();
                    Console.WriteLine("Database deleted.");
                }
                db.Database.Create();
            }

            Console.WriteLine("Database created.");
            Console.ReadLine();
        }
    }
}