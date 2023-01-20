using HarryPotter.Games.Core.DataLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Menu.Commands
{
    public class NouvellePartieMenuCommand : IMenuCommand
    {
        #region Fields
        private List<Force> forces;
        private List<Ennemi> ennemies;
        private Game game = null;
        private readonly Player currentPlayer;
        #endregion

        #region Constructors
        public NouvellePartieMenuCommand(Player player)
        {
            this.currentPlayer = player;
        }
        #endregion

        #region Public methods
        public void Executer()
        {
            this.forces = new List<Force>();
            this.game = new Game(this.currentPlayer);

            this.SauvegarderPartie();
            this.RecupererEtAfficherEnnemis();

            this.game.Init(new Configurations.GameConfig(20, 20));

            
            PreparerListeForces();
            AfficherForceSelectionnee();

            AfficherArmes();

            #region Lancement du jeu
            //player.SeDeplacer();
            //player.SeDeplacer(new Position(1, 1));

            // player.SeDeplacer(new RandomCalculateurPosition());
            //player.SeDeplacer(new StaticCalculateurPosition(1, 2));


            //player.Attaquer(ennemi);

            //ennemi.SeDeplacer();
            //ennemi.Attaquer(player);
            #endregion
        }
        #endregion

        #region Internal methods
        private void SauvegarderPartie()
        {
            var dataLayer = new GameDbDataLayer();
            dataLayer.Ecrire(this.game);
        }

        private void RecupererEtAfficherEnnemis()
        {
            this.ennemies = new EnnemiDBDataLayer().LireList();
        }

        void AfficherArmes()
        {
            float puissanceArme = 10;
            puissanceArme = 15.6f;

            Console.WriteLine(puissanceArme);

            int valeurParDefaultPuissanceArme = 10;
            // affectation sans cast : puissanceArme = valeurParDefaultPuissanceArme;

            Console.WriteLine("Choisissez votre arme pour démarrer le jeu :");

            // int j = 0;

            // j = j + 1; // 0 + 1
            // j = j + 1; // 1 + 1

            // j++; // 2 + 1

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i + 1}. Arme {i + 1}");
                Console.WriteLine("{0}. Arme {0}", i + 1);
            }
        }

        void PreparerListeForces()
        {
            forces.Add(new LumineuseForce());
            forces.Add(new ObscureForce());
            forces.Add(new NeutreForce());
        }

        int AfficherForcesEtRetourneSelection()
        {
            AfficherChoixForces();

            string saisieForce = Console.ReadLine();
            return int.Parse(saisieForce);
        }

        void AfficherChoixForces()
        {
            Console.WriteLine("De quel côté de la force seras-tu ? ");
            //Console.WriteLine("1. Du côté lumineux");
            //Console.WriteLine("2. Du côté obscur");
            //Console.WriteLine("3. Neutre, pas de force pour moi");

            foreach (var force in forces)
            {
                Console.WriteLine(force);
            }
        }

        void AfficherForceSelectionnee()
        {
            int typeForce = AfficherForcesEtRetourneSelection();

            const int forceLumineuse = 1;
            const int forceObscur = 2;
            const int sansForce = 3;

            this.currentPlayer.ForceSelectionnee = forces[typeForce - 1];

            switch (typeForce)
            {
                case forceLumineuse:
                    {
                        Console.WriteLine("Tu as choisi le côté lumineux");
                    }
                    break;

                case forceObscur:
                    {
                        Console.WriteLine("Tu as choisi le côté obscur");
                    }
                    break;

                case sansForce:
                    {
                        Console.WriteLine("Tu n'a pas de choix de force");
                    }
                    break;

                default:
                    {
                        Console.WriteLine("Tu n'a rien choisi comme force");
                    }
                    break;
            }
        }


        
        #endregion

        #region Properties
        public int Index { get => 1; }
        #endregion
    }
}
