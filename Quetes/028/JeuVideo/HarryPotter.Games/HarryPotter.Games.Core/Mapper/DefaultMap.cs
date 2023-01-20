using HarryPotter.Games.Core.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Mapper
{
    public class DefaultMap : IMap
    {
        #region Fields
        private readonly (Action<string> affichage, Func<string> lireSaisie) accessES;
        private readonly Action<string> affichageCaractere;
        #endregion

        #region Properties
        protected EntreeSortie EntreeSortie { get; init; }
        #endregion

        #region Constructors
        public DefaultMap(EntreeSortie entreeSortie)
        {
            this.EntreeSortie = entreeSortie;
            this.accessES = this.EntreeSortie.RecupererEntreeSortie();
            this.affichageCaractere = this.EntreeSortie.RecupererAffichageUnCaractere();
        }
        #endregion

        #region Public methods
        public void Afficher(GrilleDeJeu grille)
        {
            for (int i = 0; i < grille.NbLignes; i++)
            {
                for (int j = 0; j < grille.NbColonnes; j++)
                {
                    var query = from cell in grille
                                where cell.ABonneCoordonnees(i, j)
                                select cell;

                    var cellule = query.First();

                    string contenant = "_";
                    if (cellule.AAuMoinsNPersonnages(1))
                    {
                        contenant = "0";
                    }

                    this.affichageCaractere($"| {contenant} | ");
                }
                this.accessES.affichage("\n");
            }
        }
        #endregion
    }
}
