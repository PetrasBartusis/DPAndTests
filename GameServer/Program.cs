using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using GameServer.Strategy;

namespace GameServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Player p = new Player("Jonas", 15, 5, 3, 1, 0, 0);
            p.addItem(new Item(1, "hp potion"));
            p.addItem(new Item(2, "buff potion"));
            p.addItem(new Item(3, "damage potion"));
            Console.WriteLine("Player used hp potion");
            p.damagePlayer(8);
            string e = p.ToString();
            p.useItem("hp potion");
            e = p.ToString();
            Console.WriteLine("Player used buff potion");
            p.useItem("buff potion");
            e = p.ToString();
            Console.WriteLine("Player used damage potion");
            p.useItem("damage potion");
            e = p.ToString();
            //CreateWebHostBuilder(args).Build().Run();*/
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
