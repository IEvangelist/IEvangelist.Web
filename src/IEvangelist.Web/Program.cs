using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace IEvangelistWeb
{
    public class Program
    {
        public static void Main(string[] args)
            => Startup.BuildWebHost()
                      .Run();
    }
}