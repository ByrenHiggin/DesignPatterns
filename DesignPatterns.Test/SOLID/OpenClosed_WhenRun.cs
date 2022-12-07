using Xunit;
using System;
using System.Reflection;
using Autofac;
using DesignPatterns.OpenClosed;
using System.Security.Principal;
using DesignPatterns.generic;
using DesignPatterns.interfaces;

namespace DesignPatterns.Tests
{
    public class OpenClosed_WhenRun : TestBase
    {
        private static IContainer Container { get; set; }
        public OpenClosed_WhenRun() : base()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Journal>().As<IInteractableObject>();
            builder.RegisterAssemblyModules();
            Container = builder.Build();
        }

        [Fact]
        public void Create_Products()
        {

        }
    }
}
