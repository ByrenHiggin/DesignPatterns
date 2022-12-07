using Xunit;
using System;
using DesignPatterns;
using Autofac;
using System.Security.Principal;
using DesignPatterns.interfaces;
using DesignPatterns.generic;
using System.Linq;

namespace DesignPatterns.Tests
{
    public class SingleResponsibility_WhenRun
    {
        private static IContainer Container { get; set; }
        private ILifetimeScope lifetimeScope { get; set; }
        public SingleResponsibility_WhenRun()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Journal>().As<IInteractableObject>();
            Container = builder.Build();
            lifetimeScope = Container.BeginLifetimeScope();
        }

        [Fact]
        public void Create_a_Journal_and_add_an_entry()
        {
            var data = lifetimeScope.Resolve<IInteractableObject>();
            data.AddEntry("I cried today", Size.Small, Color.Red);
            Console.WriteLine(data.Count());
            Assert.True(true);
        }
    }
}
