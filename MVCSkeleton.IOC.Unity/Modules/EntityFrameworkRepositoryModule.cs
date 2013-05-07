using System;
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
            container.RegisterType<IMenuItemRepository, MenuItemRepository>();
        }

        protected virtual void InitializeSessionAdapterBinding(IUnityContainer container)
        {
            container.RegisterType<ISessionAdapter, EntityFrameworkSessionAdapter>(new PerHttpRequestLifetime());
        }

        private class PerHttpRequestLifetime : LifetimeManager
        {
            // This is very important part and the reason why I believe mentioned
            // PerCallContext implementation is wrong.
            private readonly Guid _key = Guid.NewGuid();

            public override object GetValue()
            {
                return HttpContext.Current.Items[_key];
            }

            public override void SetValue(object newValue)
            {
                HttpContext.Current.Items[_key] = newValue;
            }

            public override void RemoveValue()
            {
                var obj = GetValue();
                HttpContext.Current.Items.Remove(obj);
            }
        }
    }
}