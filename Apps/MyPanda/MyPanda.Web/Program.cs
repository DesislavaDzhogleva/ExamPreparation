using SIS.MvcFramework;
using System;

namespace MyPanda.Web
{
    class Program
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
