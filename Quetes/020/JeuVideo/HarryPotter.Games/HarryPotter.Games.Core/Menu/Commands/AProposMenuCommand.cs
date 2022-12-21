using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Menu.Commands
{
    public class AProposMenuCommand : IMenuCommand
    {
        #region Public methods
        public void Executer()
        {
            this.AffichageCredits();
        }
        #endregion

        #region Internal methods
        void AffichageCredits()
        {
            Console.WriteLine("**********");
            Console.WriteLine("Evan BOISSONNOT and Co");
            Console.WriteLine("2022-next");
            Console.WriteLine("**********");
        }
        #endregion

        #region Properties
        public int Index { get => 3; }
        #endregion
    }
}
