using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Configurations
{
    public class EntreeSortie
    {
        public (Action<string> affichage, Func<string> lireSaisie) RecupererEntreeSortie()
        {
            return (Console.WriteLine, Console.ReadLine);
        }
        
        public Action<string> RecupererAffichageUnCaractere()
        {
            return Console.Write;
        }


        //public (int Calcul, bool Succes) Renvoyer()
        //{
        //    return (1, false);
        //}

        //public void UtiliserTuple()
        //{
        //    // Tuple<int, bool> result
        //    var result = this.Renvoyer();
        //    result.Calcul = 3;
        //}
    }
}
