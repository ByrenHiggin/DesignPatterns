using Autofac;
using DesignPatterns.generic;
using DesignPatterns.interfaces;
using static System.Console;

namespace DesignPatterns.SingleResponsibility
{
    public class SOLID_SingleResponsibility_Principle : Principle
    {
        private readonly ILifetimeScope _lifetimeScope;
        public SOLID_SingleResponsibility_Principle(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            Run();
        }

        public void Run()
        {
            var data = _lifetimeScope.Resolve<IInteractableObject>();
            var datastore = _lifetimeScope.Resolve<IPersistence>();
            data.AddEntry("I cried today", Size.Medium, Color.Red);
            data.AddEntry("I ate a bug", Size.Small, Color.Blue);
            data.AddEntry("I added autofac", Size.Large, Color.Green);
            datastore.SaveToFile(data, "SingleResponsibility.data");
            datastore.OpenFromFile("SingleResponsibility.data");
            WriteLine(data);
        }

    }
}
