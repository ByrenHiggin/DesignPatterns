using Autofac;
using SOLIDPrinciples.interfaces;
using System;

namespace SOLIDPrinciples.interfaces
{
    public interface IPrinciple
    {
        void Run();
    }
}

namespace SOLIDPrinciples.generic
{
    public class Principle : Module, IPrinciple
    {
        public virtual void Run()
        {
            throw new NotImplementedException();
        }
    }
}
