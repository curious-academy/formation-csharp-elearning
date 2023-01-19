using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitDejeunerSyncAsync
{
    internal class Poele
    {
        public async Task ChaufferAsync()
        {
            Console.WriteLine("La poele commence à chauffer");
            await Task.Delay(TimeSpan.FromSeconds(10));
            Console.WriteLine("La poele est chaude");
        }

        public async Task<Oeuf[]> CuireAsync(Oeuf[] oeufs)
        {
            await Task.Delay(TimeSpan.FromSeconds(5 * oeufs.Length));

            return oeufs;
        }

    }
}
