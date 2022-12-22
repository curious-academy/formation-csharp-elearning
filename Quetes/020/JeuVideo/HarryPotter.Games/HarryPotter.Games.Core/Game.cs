using HarryPotter.Games.Core.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core
{
    /// <summary>
    /// Représente une partie de jeu
    /// </summary>
    public class Game
    {
        #region Constructors
        public Game(Player player)
        {
            this.CurrentPlayer = player;
            this.Grille = new GrilleDeJeu();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Initialize le jeu avec les paramètres en entrée de méthode
        /// </summary>
        /// <param name="config"></param>
        public void Init(GameConfig config)
        {
            this.InitGrille(config.NbLignes, config.NbColonnes);
        }

        public static bool AvoirPersonnesSurCellule(Cellule cellule)
        {
            return cellule.AAuMoinsUnPersonnage();
            // return this.AvoirPersonnesSurCellule(cellule.X, cellule.Y);
        }

        public bool AvoirPersonnesSurCellule(int x, int y)
        {
            var query = from cellule in this.Grille
                        where
                            cellule.ABonneCoordonnees(x, y) &&
                            cellule.AAuMoinsUnPersonnage()
                        select cellule;

            return query.Any();
        }

        public IList<Cellule> GetCellulesVides()
        {
            return this.GetCellulesVidesEnumerator().ToList();
        }

        public IEnumerable<Cellule> GetCellulesVidesEnumerator()
        {
            return this.Grille.Where(cellule => !cellule.AAuMoinsUnPersonnage());
        }

        public bool VerifiePersonnagePresent(Character character)
        {
            return this.DonnerCoordonneesPersonnageEnumerator(character).Any();
        }

        public Cellule? DonnerCellulePour(Character character)
        {
            return this.DonnerCoordonneesPersonnageEnumerator(character).SingleOrDefault();
        }

        public IEnumerable<Cellule> VerifieSiCombatEnumerator()
        {
            var query = from cell in this.Grille
                        where
                            cell.DetientPersonnage(this.CurrentPlayer) &&
                            cell.AAuMoinsNPersonnages(2)
                        select cell;

            return query;
        }

        public Cellule? VerifieSiCombat()
        {
            return this.VerifieSiCombatEnumerator().SingleOrDefault();
        }

        public IEnumerable<Cellule> DonnerCoordonneesPersonnageEnumerator(Character character)
        {
            var query = from cell in this.Grille
                        where cell.DetientPersonnage(character)
                        select cell;

            return query;
        }

        public IEnumerable<Cellule> DonnerCellulesAvecAuMoinsUnPersonnageEnumerator()
        {
            var query = from cellule in this.Grille
                        where
                            cellule.AAuMoinsUnPersonnage()
                        select cellule;

            return query;
        }

        public List<Cellule> DonnerCellulesAvecAuMoinsUnPersonnage()
        {
            return this.DonnerCellulesAvecAuMoinsUnPersonnageEnumerator().ToList();
        }
        #endregion

        #region Internal methods
        private void InitGrille(int nbLignes, int nbColonnes)
        {
            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; j < nbColonnes; j++)
                {
                    Cellule cell = new(i, j);
                    this.Grille.Add(cell);
                }
            }
        }
        #endregion

        #region Properties
        public Player CurrentPlayer { get; init; }

        private GrilleDeJeu Grille { get; init; }
        #endregion
    }
}
