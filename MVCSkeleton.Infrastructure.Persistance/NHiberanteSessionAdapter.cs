using System;
using System.Configuration;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MVCSkeleton.Application.Session;
using NHibernate;
using NHibernate.Context;

namespace MVCSkeleton.Infrastructure.Persistance
{
    public class NHiberanteSessionAdapter : ISessionAdapter
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
                             ConnectionString(
                                 ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString
                             ).ShowSql())
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
            ISession session = CurrentSessionContext.Unbind(sessionFactory);
            if(session == null)
            {
                return;
            }
            try
            {
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }

        public void Rollback()
        {
            if (sessionFactory == null)
            {
                return;
            }
            ISession session = CurrentSessionContext.Unbind(sessionFactory);
            if (session == null)
            {
                return;
            }
            try
            {
                session.Transaction.Rollback();
            }
            catch (Exception)
            {
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }
    }
}