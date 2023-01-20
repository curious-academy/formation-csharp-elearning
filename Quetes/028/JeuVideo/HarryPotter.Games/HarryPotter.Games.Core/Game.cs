using HarryPotter.Games.Core.Configurations;
using HarryPotter.Games.Core.Mapper;
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
        #region Fields
        private IMap map;
        #endregion

        #region Constructors
        public Game(Player player, IMap map)
        {
            this.map = map;
            this.CurrentPlayer = player;
            this.CurrentPlayer.EstMort += this.FinDePartie;

            this.Grille = new GrilleDeJeu();
        }
        #endregion

        #region Public methods
        public void FinDePartie(Character character)
        {
            if (this.CurrentPlayer == character)
            {
                Console.WriteLine($"Le player {this.CurrentPlayer.Prenom} est mort :'( GAME OVER");
                this.CurrentPlayer.EstMort -= this.FinDePartie; // A voir si on le fait là ou plus tard ...
            }
        }

        /// <summary>
        /// Initialize le jeu avec les paramètres en entrée de méthode
        /// </summary>
        /// <param name="config"></param>
        public void Init(GameConfig config)
        {
            this.InitGrille(config.NbLignes, config.NbColonnes);

            this.Grille.Placer(this.CurrentPlayer, 0, 0);
        }

        /// <summary>
        /// Démarre le jeu et les déplacements du joueur / de la joueuse
        /// </summary>
        public void Start()
        {
            while (this.CurrentPlayer.PointsDeVie > 0)
            {
                this.map.Afficher(this.Grille);

                Console.WriteLine("Que voulez-vous faire ?");
                this.AfficherChoixDeplacements();
                var celluleCourante = this.DeplacerJoueur(Console.ReadLine());

                var celluleAvecCombat = this.VerifieSiCombat();
                if (celluleAvecCombat != null)
                {
                    this.DeathMath(celluleAvecCombat.Characters.First(item => item != this.CurrentPlayer));
                }
            }
        }

        private void DeplacerEnnemis()
        {
            // Todo : à finir
        }

        private void DeathMath(Character ennemi)
        {
            while(this.CurrentPlayer.PointsDeVie > 0 || ennemi.PointsDeVie > 0)
            {
                this.CurrentPlayer.Attaquer(ennemi);
                ennemi.Attaquer(this.CurrentPlayer);
            }
        }

        private Cellule DeplacerJoueur(string choix)
        {
            (int x, int y) coordonnees = (0, 0);

            switch (choix)
            {
                case "Q":
                    {
                        coordonnees.x = 0;
                        coordonnees.y = -1;
                    }
                    break;
                case "D":
                    {
                        coordonnees.x = 0;
                        coordonnees.y = 1;
                    }
                    break;
                case "Z":
                    {
                        coordonnees.x = -1;
                        coordonnees.y = 0;
                    }
                    break;
                case "S": 
                    {
                        coordonnees.x = 1;
                        coordonnees.y = 0;
                    } break;
                default:
                    break;
            }

            var query = this.DonnerCoordonneesPersonnageEnumerator(this.CurrentPlayer);
            var cellule = query.Single();

            cellule.SupprimerPersonnage(this.CurrentPlayer);

            int x = cellule.X + coordonnees.x;
            int y = cellule.Y + coordonnees.y;

            this.Grille.Placer(this.CurrentPlayer, x, y);

            return cellule;
        }

        private void AfficherChoixDeplacements()
        {
            Console.WriteLine("-> Z : En haut");
            Console.WriteLine("-> S : En bas");
            Console.WriteLine("-> Q : A gauche");
            Console.WriteLine("-> D : A droite");
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
        private void Save()
        {

        }

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
            this.Grille.NbLignes = nbLignes;
            this.Grille.NbColonnes = nbColonnes;
        }
        #endregion

        #region Properties
        public Player CurrentPlayer { get; init; }

        private GrilleDeJeu Grille { get; init; }
        #endregion
    }
}
