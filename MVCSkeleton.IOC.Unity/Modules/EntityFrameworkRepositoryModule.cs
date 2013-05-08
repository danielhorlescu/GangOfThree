using System;
using System.Runtime.Remoting.Messaging;
using System.Web;
using MVCSkeleton.Application.Repository;
using MVCSkeleton.Application.Session;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework;
using MVCSkeleton.Infrastructure.Persistance.EntityFramework.Repositories;
using Microsoft.Practices.Unity;

namespace MVCSkeleton.IOC.Unity.Modules
{
    public class EntityFrameworkRepositoryModule
    {
        public void Initialize(IUnityContainer container)
        {
            InitializeSessionAdapterBinding(container);
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
        }

        protected virtual void InitializeSessionAdapterBinding(IUnityContainer container)
        {
            container.RegisterType<ISessionAdapter, EntityFrameworkSessionAdapter>(new PerHttpRequestOrCallContextLifetime());
        }

        private class PerHttpRequestOrCallContextLifetime : LifetimeManager
        {
            // This is very important part and the reason why I believe mentioned
            // PerCallContext implementation is wrong.
            private readonly string _key = Guid.NewGuid().ToString();

            public override object GetValue()
            {
                return HttpContext.Current == null ? CallContext.GetData(_key) : HttpContext.Current.Items[_key];
            }

            public override void SetValue(object newValue)
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Items[_key] = newValue;
                }
                else
                {
                    CallContext.SetData(_key, newValue);
                }
            }

            public override void RemoveValue()
            {
                var obj = GetValue();
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Items.Remove(obj);
                }
                else
                {
                    CallContext.FreeNamedDataSlot(_key);
                }
            }
        }
    }
}