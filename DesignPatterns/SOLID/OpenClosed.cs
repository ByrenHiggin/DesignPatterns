using Autofac;
using DesignPatterns.generic;
using DesignPatterns.interfaces;
using System.Collections.Generic;

namespace DesignPatterns.OpenClosed
{

    public class ProductFilter
    {
        public IEnumerable<IData> FilterBySize(IEnumerable<IData> products, Size SizeToFilterBy)
        {
            foreach (var p in products)
            {
                if(p.Size() == SizeToFilterBy)
                {
                    yield return p;
                }
            }
        }
        public IEnumerable<IData> FilterByColor(IEnumerable<IData> products, Color ColorToFilterBy)
        {
            foreach (var p in products)
            {
                if (p.Color() == ColorToFilterBy)
                {
                    yield return p;
                }
            }
        }
    }

    public class SOLID_OpenClosed_Principle : Principle
    {
        private readonly ILifetimeScope _lifetimeScope;
        public SOLID_OpenClosed_Principle(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            Run();
        }

        public void Run()
        {
            //var apple = new Product("apple", Size.Small, Color.Green);
            //var tree = new Product("house", Size.Large, Color.Blue);
            //var house = new Product("Tree", Size.Medium, Color.Green);

            //Product[] products = {apple, tree, house};

            //var pf = new ProductFilter();
            //WriteLine("Green Products (Old):");
            //foreach(var p in pf.FilterByColor(products,Color.Green))
            //{
            //    WriteLine($"{p.Name} is {p.Color}");
            //}
            
        }
    }
}
