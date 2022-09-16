using Castle.DynamicProxy;
using System;

namespace demoFor2Api31.Services
{
    public class MyIInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Intercept before, Method:{invocation.Method.Name}");

            invocation.Proceed();

            Console.WriteLine($"Intercept after, Method:{invocation.Method.Name}");
        }
    }
}
