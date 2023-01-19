using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitDejeunerSyncAsync
{
    internal class GrillePain
    {
        public async Task<TartinePain[]> GrillerAsync(TartinePain[] tartines)
        {
            Console.WriteLine("Début grille");

            await Task.Delay(TimeSpan.FromSeconds(tartines.Length + 5));

            Console.WriteLine("Fin de la cuisson");

            return tartines;
        }

    }
}
