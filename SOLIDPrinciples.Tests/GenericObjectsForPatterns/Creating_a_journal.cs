using Autofac;
using SOLIDPrinciples.generic;
using SOLIDPrinciples.interfaces;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace SOLIDPrinciples.Tests
{
    public class Creating_a_journal
    {
        private static IContainer Container { get; set; }
        private ILifetimeScope lifetimeScope { get; set; }
        private readonly ITestOutputHelper output;
        public Creating_a_journal(ITestOutputHelper output)
        {
            this.output = output;
            var builder = new ContainerBuilder();
            builder.RegisterType<Journal>().As<IInteractableObject>();
            Container = builder.Build();
            lifetimeScope = Container.BeginLifetimeScope();
        }

        [Fact]
        public void And_add_an_entry()
        {
            var data = lifetimeScope.Resolve<IInteractableObject>();
            data.AddEntry("I cried today", Size.Small, Color.Red);
            Assert.Single(data.Count().ToString());
        } 

        [Fact]
        public void And_remove_an_entry()
        {
            var data = lifetimeScope.Resolve<IInteractableObject>();
            data.AddEntry("I cried today", Size.Small, Color.Red);
            data.RemoveEntry(data[0]);
            Assert.Equal("0", data.Count().ToString());
        }

        [Fact]
        public void And_Check_It_Is_Iterable()
        {
            var data = lifetimeScope.Resolve<IInteractableObject>();
            data.AddEntry("Test Data 1", Size.Small, Color.Red);
            data.AddEntry("Test 2", Size.Medium, Color.Blue);
            data.AddEntry("Test 3", Size.Large, Color.Green);
            foreach(IData element in data)
            {
                output.WriteLine(element.Size().ToString());
                Assert.IsAssignableFrom<IData>(element);
            }
        }
    }
}
