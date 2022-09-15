using System;

namespace demoFor2Api31.Services
{
    public interface IMyService
    {
        void ShowCode();
    }

    public class MyService : IMyService
    {
        public void ShowCode()
        {
            Console.WriteLine($"MyService.ShowCode:{this.GetHashCode()}");
        }
    }

    public class MyServiceV2 : IMyService
    {
        public MyNameService NameService { get; set; }

        public void ShowCode()
        {
            Console.WriteLine($"MyServiceV2.ShowCode:{this.GetHashCode()}, NameService是否为空：{NameService == null}");
        }
    }

    public class MyNameService
    {

    }
}
