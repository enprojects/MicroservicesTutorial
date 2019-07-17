using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{

    public interface IMethodImplement<T> where T : class
    {

        void Do(T t);
    }

    public class Pesron
    {
        public string Name { get; set; }
    }

    public class MethodImplement : IMethodImplement<Pesron>

    {
        public void Do(Pesron t)
        {
            Console.WriteLine($"My prop name {t.GetType().GetProperties().First().Name}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(MethodImplement);
           var  Gtypes = new List<Type>();

            foreach (Type it in t.GetInterfaces())
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == typeof(IMethodImplement<>))
                    Gtypes.AddRange(it.GetGenericArguments());
            }
        }
    }
}
