using Autofac;
using DesignPatterns.interfaces;
using System;

namespace DesignPatterns.interfaces
{
    public interface IPrinciple
    {
        void Run();
    }
}

namespace DesignPatterns.generic
{
    public class Principle : Module, IPrinciple
    {
        public virtual void Run()
        {
            throw new NotImplementedException();
        }
    }
}
