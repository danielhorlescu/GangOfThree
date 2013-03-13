using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace MVCSkeleton.Tests.IOC
{
     [TestClass]
    public class IOCTests
    {
         public class A : IA
         {
             
         }

         public interface IA
         {
         }

         [TestMethod]
         public void Test_SingleInstance_For_HybridHttpOrThreadLocalScoped()
         {
             ObjectFactory.Initialize(x => x.For<IA>().HybridHttpOrThreadLocalScoped().Use<A>());
             var firstInstance = ObjectFactory.GetInstance<IA>();
             var secondInstance = ObjectFactory.GetInstance<IA>();

             Assert.AreEqual(firstInstance, secondInstance);
         }

         [TestMethod]
         public void Test_SingleInstance_Per_Thread_For_HybridHttpOrThreadLocalScoped()
         {
             ObjectFactory.Initialize(x => x.For<IA>().HybridHttpOrThreadLocalScoped().Use<A>());
             var firstInstance = ObjectFactory.GetInstance<IA>();

             Task t = Task.Factory.StartNew(() => CreateNewInstanceOnSeparateThread(firstInstance, Thread.CurrentThread.ManagedThreadId));
         }

         private void CreateNewInstanceOnSeparateThread(IA firstInstance, int managedThreadId)
         {
             var secondInstance = ObjectFactory.GetInstance<IA>();
             Assert.AreNotEqual(firstInstance, secondInstance);
             Assert.AreNotEqual(managedThreadId, Thread.CurrentThread.ManagedThreadId);
         }
    }

    
}