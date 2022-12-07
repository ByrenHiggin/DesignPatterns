using Autofac;
using SOLIDPrinciples.interfaces;
using SOLIDPrinciples.OpenClosed;
using SOLIDPrinciples.SingleResponsibility;
using System;
using System.Collections.Generic;
using System.Reflection;
using static System.Console;
using IContainer = Autofac.IContainer;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper();
        }
    }

    public class Bootstrapper
    {
        private static IContainer Container { get; set; }
        private ILifetimeScope Scope { get; set; }
        private static IInteractableObject InteractableObject { get; set; }

        public Bootstrapper()
        {
            CreateBuilder();
            var Menu = Scope.Resolve<Menu>();
        }

        void CreateBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Menu>().AsSelf().InstancePerLifetimeScope();
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
            builder.RegisterType<SOLID_SingleResponsibility_Principle>().AsSelf();
            builder.RegisterType<SOLID_OpenClosed_Principle>().AsSelf();
            Container = builder.Build();

            Scope = Container.BeginLifetimeScope();
        }
    }

    public class Menu
    {
        private readonly ILifetimeScope _lifetimeScope;

        public static List<MenuOption> MenuOptions = new List<MenuOption>();
        public Menu(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            CreateDelegates();
            OpenMenu();
            WaitForInput();
        }
        void OpenMenu()
        {
            WriteLine("Please choose a module to run");
            foreach (var MenuOption in MenuOptions)
            {
                WriteLine($"{MenuOption.OptionChar} - {MenuOption.Description}");
            }
            WriteLine("x = Exit Program");
        }

        void CreateDelegates()
        {
            MenuOptions.Add(new MenuOption { OptionChar = 'a', Action = PerformSolid, Description = "Run the SOLID principles" });
        }

        void WaitForInput()
        {
            bool EXIT_TOKEN = true;
            do
            {
                var InputKey = Console.ReadKey().KeyChar;
                foreach (MenuOption option in MenuOptions)
                {
                    if (option.OptionChar == InputKey)
                    {
                        option.Action.Invoke();
                        EXIT_TOKEN = false;
                    }
                    else if (InputKey == 'x')
                    {
                        EXIT_TOKEN = false;
                        Console.WriteLine("Option not selected");
                    }
                }

            } while (EXIT_TOKEN);
        }

        void PerformSolid()
        {
            var SingleResponsibility = _lifetimeScope.Resolve<SOLIDPrinciples.SingleResponsibility.SOLID_SingleResponsibility_Principle>();
            var OpenClosed = _lifetimeScope.Resolve<SOLIDPrinciples.OpenClosed.SOLID_OpenClosed_Principle>();
        }
    }

    public class MenuOption
    {
        public char OptionChar;
        public Action Action;
        public string Description;
    }
}
