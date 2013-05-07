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
                    db.Database.Delete();
                }
                db.Database.Create();
            }
        }
    }
}