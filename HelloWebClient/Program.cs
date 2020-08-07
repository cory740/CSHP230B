using System;
using System.Net.Http;

namespace HelloWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:58835/api/");

            var result = client.GetAsync("contacts").Result;

            var json = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine(json);
            Console.ReadLine();
        }
    }
}
