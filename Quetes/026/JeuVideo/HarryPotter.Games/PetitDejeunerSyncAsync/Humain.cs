using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetitDejeunerSyncAsync
{
    internal class Humain
    {
        public async Task<PetitDejeuner> PreparerPetitDejeunerAsync()
        {
#if DEBUG
            Stopwatch stopwatch= Stopwatch.StartNew();
            stopwatch.Start();
#endif

            PetitDejeuner dej = new();

            Task preparerOeufs = this.PreparerOeufsAsync(dej);
            Task preparerTartines = this.PreparerTartinesAsync(dej);

            await Task.WhenAll(preparerOeufs, preparerTartines);

#if DEBUG
            stopwatch.Stop();
            Console.WriteLine("Temps écoulé {0}", stopwatch.Elapsed);
#endif

            return dej;
        }

        private async Task PreparerTartinesAsync(PetitDejeuner dej)
        {
            dej.TartinesGrilles = await (new GrillePain()).GrillerAsync(new[] { new TartinePain(), new TartinePain() });
            await this.BeurrerTartinesAsync(dej);
        }

        private async Task PreparerOeufsAsync(PetitDejeuner dej)
        {
            Poele poele = new();
            await poele.ChaufferAsync();
            dej.OeufsGrilles = await poele.CuireAsync(new[] { new Oeuf(), new Oeuf() });
        }

        public async Task BeurrerTartinesAsync(PetitDejeuner dej)
        {
            Console.WriteLine("Je commence à beurrer");
            await Task.Delay(TimeSpan.FromSeconds(dej.TartinesGrilles.Length * 3));
            Console.WriteLine("J'ai fini de beurrer mes tartines");
        }

    }
}
