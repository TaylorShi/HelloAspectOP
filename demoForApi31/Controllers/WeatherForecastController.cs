using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using demoForApi31.Models;
using demoForApi31.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace demoForApi31.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public int Get()
        //{
        //    Console.WriteLine("***\r\n Begin program - no logging\r\n");
        //    IRepository<Customer> customerRepository = new Repository<Customer>();
        //    var customer = new Customer
        //    {
        //        Id = 1,
        //        Name = "Customer 1",
        //        Address = "Address 1"
        //    };
        //    customerRepository.Add(customer);
        //    customerRepository.Update(customer);
        //    customerRepository.Delete(customer);
        //    Console.WriteLine("\r\nEnd program - no logging\r\n***");

        //    return 1;
        //}

        //[HttpGet]
        //public int Get()
        //{
        //    Console.WriteLine("***\r\n Begin program - logging with decorator\r\n");
        //    // IRepository<Customer> customerRepository =
        //    //   new Repository<Customer>();
        //    IRepository<Customer> customerRepository = new LoggerRepository<Customer>(new Repository<Customer>());
        //    var customer = new Customer
        //    {
        //        Id = 1,
        //        Name = "Customer 1",
        //        Address = "Address 1"
        //    };
        //    customerRepository.Add(customer);
        //    customerRepository.Update(customer);
        //    customerRepository.Delete(customer);
        //    Console.WriteLine("\r\nEnd program - logging with decorator\r\n***");

        //    return 1;
        //}

        //[HttpGet]
        //public int Get()
        //{
        //    Console.WriteLine("***\r\n Begin program - logging with dynamic proxy\r\n");
        //    // IRepository<Customer> customerRepository =
        //    //   new Repository<Customer>();
        //    // IRepository<Customer> customerRepository =
        //    //   new LoggerRepository<Customer>(new Repository<Customer>());
        //    IRepository<Customer> customerRepository =
        //      RepositoryFactory.Create<Customer>();
        //    var customer = new Customer
        //    {
        //        Id = 1,
        //        Name = "Customer 1",
        //        Address = "Address 1"
        //    };

        //    customerRepository.Add(customer);
        //    customerRepository.Update(customer);
        //    customerRepository.Delete(customer);
        //    Console.WriteLine("\r\nEnd program - logging with dynamic proxy\r\n***");
        //    return 1;
        //}

        [HttpGet]
        public int Get()
        {
            Console.WriteLine("***\r\n Begin program - logging and authentication\r\n");
            Console.WriteLine("\r\nRunning as admin");
            Thread.CurrentPrincipal =
              new GenericPrincipal(new GenericIdentity("Administrator"),
              new[] { "ADMIN" });
            IRepository<Customer> customerRepository =
              RepositoryFactory.Create<Customer>();
            var customer = new Customer
            {
                Id = 1,
                Name = "Customer 1",
                Address = "Address 1"
            };
            customerRepository.Add(customer);
            customerRepository.Update(customer);
            customerRepository.Delete(customer);
            Console.WriteLine("\r\nRunning as user");
            Thread.CurrentPrincipal =
              new GenericPrincipal(new GenericIdentity("NormalUser"),
              new string[] { });
            customerRepository.Add(customer);
            customerRepository.Update(customer);
            customerRepository.Delete(customer);
            Console.WriteLine("\r\nEnd program - logging and authentication\r\n***");
            return 1;
        }
    }
}
