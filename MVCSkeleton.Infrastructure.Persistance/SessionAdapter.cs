using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MVCSkeleton.Application.Session;
using NHibernate;
using NHibernate.Context;

namespace MVCSkeleton.Infrastructure.Persistance
{
    public class SessionAdapter : ISessionAdapter
    {
        private ISessionFactory sessionFactory;

        private ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    InitializeSessionFactory();
                }
                return sessionFactory;
            }
        }

        private void InitializeSessionFactory()
        {
            sessionFactory = Fluently.Configure().
                Database(MsSqlConfiguration.MsSql2008.
                             ConnectionString(@"Server=.;Database=MVCSkeleton;Trusted_Connection=True;").ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())).ExposeConfiguration(
                    cfg =>
                        {
                            //new SchemaExport(cfg).Create(true, false);
                            cfg.SetProperty("current_session_context_class",
                                            "thread_static");
                        }
                ).BuildSessionFactory();
        }

        private ITransaction CurrentTransaction
        {
            get { return CurrentSession.Transaction; }
        }

        internal ISession CurrentSession
        {
            get
            {
                if (!CurrentSessionContext.HasBind(SessionFactory))
                {
                    ISession session = SessionFactory.OpenSession();
                    session.BeginTransaction();
                    CurrentSessionContext.Bind(session);
                }
                return SessionFactory.GetCurrentSession();
            }
        }

        public void Commit()
        {
            if (sessionFactory == null)
            {
                return;
            }
            CurrentTransaction.Commit();
            CurrentSession.Close();
            CurrentSessionContext.Unbind(sessionFactory);
        }

        public void Rollback()
        {
            if (sessionFactory == null)
            {
                return;
            }
            CurrentSession.Flush();
            CurrentSessionContext.Unbind(sessionFactory);
        }
    }
}