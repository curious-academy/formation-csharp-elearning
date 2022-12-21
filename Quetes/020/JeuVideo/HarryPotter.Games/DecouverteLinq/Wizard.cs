using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecouverteLinq
{
    internal sealed class Wizard
    {
        public string Prenom { get; set; } = String.Empty;

        public int PointsDeVie { get; set; } = 100;

        public bool IsDark { get; set; } = false;

        public int BaguetteId { get; set; }

        public BaguetteMagique? MaBaguette { get; set; } = null;

        public void Attaquer(Wizard mage)
        {
            if (mage != this && this.Prenom != mage.Prenom)
            {
                mage.PointsDeVie -= 10;
            }
        }
    }
}
