//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;


//using TestFunc = System.Func<string, int>;

//using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

//namespace Actio.Common
//{

//    class BasicAuthenticationHandler
//    {
//        AppFunc next;

//        public BasicAuthenticationHandler(AppFunc next)
//        {
//            this.next = next;
//        }

//        public async Task InvokeAsync(IDictionary<string, object> context)
//        {
//            if (((IDictionary<string, string[]>)context["owin.RequestHeaders"]).ContainsKey("Authorization"))
//            {
//                await next.Invoke(context);
//            }
//            else
//            {
//                ((IDictionary<string, string[]>)context["owin.ResponseHeaders"])["WWW-Authenticate"] =
//                    new string[] { "Basic realm=\"http://localhost\"" };

//                context["owin.ResponseStatusCode"] = 401;
//            }
//        }
//    }

//    public class Test {

//        private static AppFunc BasicAuthenticationMiddleware(AppFunc next)
//        {
//            return new BasicAuthenticationHandler(next).InvokeAsync;
//        }


//        public static void Excute()
//        {
//            var func = ReturnFunc();

//            var dd = excute("", func);
//        }

//        public static int excute(string str, TestFunc func)
//        {

//            return func(str);
//        }

//        private static TestFunc ReturnFunc()
//        {
//            return SomeMethod;

//        }


//        private static  int SomeMethod(string str) {
//            return str.Length;
//        }
//    }



//}
