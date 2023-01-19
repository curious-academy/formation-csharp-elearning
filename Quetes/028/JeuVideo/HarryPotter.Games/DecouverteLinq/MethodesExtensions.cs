using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecouverteLinq.Extensions
{
    internal static class MethodesExtensions
    {
        public static void Defendre(this Wizard wizard, Wizard attaquant)
        {
            System.Console.WriteLine("Je me défends");
        }
    }
}
