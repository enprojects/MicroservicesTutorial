using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppBuild = System.Func<string, int>;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;
namespace AppFuncTest
{

    public abstract class Animal {

        public abstract void MakeSound();
        public abstract void MakeSound(Dog d);
        public abstract void MakeSound(Cat d);
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Brrrrr");
        }

        public override void MakeSound(Dog d)
        {
            Console.WriteLine("dog love dog");
        }

        public override void MakeSound(Cat d)
        {
            Console.WriteLine( "cat hate dog (dog class)" );
        }
    }


    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Ammmmm");
        }

        public override void MakeSound(Dog d)
        {
            Console.WriteLine("cat hate dog (cat class)");
        }

        public override void MakeSound(Cat d)
        {
            Console.WriteLine("cat love cat");
        }

        public void IamCat() { }
    }


    class Program
    {

        public interface ILayer
        {
        }


        public class Builder
        {
            private List<AppBuild> Handlers;

            public Builder()
            {
                Handlers = new List<AppBuild>();
            }

            private int Sum = 0;

            public Builder Use(AppBuild build)
            {
                Handlers.Add(build);
                return this;
            }


            public Builder Tes(Func<AppBuild, AppBuild> f)
            {
                // Handlers.Add(build);
                return this;
            }

            public void Exceute(string str)
            {
                foreach (var item in Handlers)
                {
                    Sum += item(str);

                }
            }

        }

        public class Layer1 : ILayer
        {


            public Layer1()
            {

            }


            public int Task1(string str)
            {
                return str.Length;

            }

        }

        public class Layer2 : ILayer
        {


            public Layer2()
            {

            }


            public int Task2(string str)
            {
                return str.Length;

            }

        }



        public static AppBuild LayerImp1()
        {
            return new Layer1().Task1;


        }

        public static AppBuild LayerImp2()
        {
            return new Layer2().Task2;


        }

        private static AppFunc BasicAuthenticationMiddleware(AppFunc next)
        {
            return null;
        }
        /*---------------------------------*/


        public class Foo
        {
            public int Fibonacci(int n)
            {
                return n > 1 ? Fibonacci(n - 1) + Fibonacci(n - 2) : n;
            }
        }

        public static Func<Т, TResult> Memoize<Т, TResult>(Func<Т, TResult> f) where Т : IEquatable<Т>
        {
            Dictionary<Т, TResult> map = new Dictionary<Т, TResult>();
            return a =>
            {
                TResult local;
                if (!TryGetValue<Т, TResult>(map, a, out local))
                {
                    local = f(a);
                    map.Add(a, local);
                }
                return local;
            };

        }


        private static bool TryGetValue<Т, TResult>(Dictionary<Т, TResult> map, Т key, out TResult value) where Т : IEquatable<Т>
        {
            EqualityComparer<Т> comparer = EqualityComparer<Т>.Default;
            foreach (KeyValuePair<Т, TResult> pair in map)
            {
                if (comparer.Equals(pair.Key, key))
                {
                    value = pair.Value;
                    return true;
                }
            }
            value = default(TResult);
            return false;
        }

        static void Main(string[] args)
        {
            var foo = new Foo();
            // Transform the original function and render it with memory
            var memoizedFibonacci = Memoize<int, int>(foo.Fibonacci);

            // memoizedFibonacci is a transformation of the original function that can be used from now on:
            // Note that only the first call will hit the original function
            Console.WriteLine(memoizedFibonacci(3));
            Console.WriteLine(memoizedFibonacci(3));



            Console.WriteLine("Hello World!");

            Func<string, int> gg = new Func<string, int>(LayerImp1());

            Builder builder = new Builder();
            builder.Use(LayerImp1());
            builder.Use(LayerImp2());

            builder.Exceute("hellow");

            Animal dog = new Dog();
            Animal cat = new Cat();
           

        }
    }
}
