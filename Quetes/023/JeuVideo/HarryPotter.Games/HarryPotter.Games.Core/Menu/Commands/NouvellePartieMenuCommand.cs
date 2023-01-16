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
        private string connectionString = "Server=DESKTOP-1446PBQ;Database=HarryPotter.Udemy.Database;Trusted_Connection=True;";

        private List<Force> forces;
        private List<Ennemi> ennemies;
        private Player player;
        private Game game = null;
        #endregion

        #region Public methods
        public void Executer()
        {
            this.forces = new List<Force>();
            this.player = new Player("harry potter", Console.WriteLine);
            player.Email = "harry@potter.fr";
            this.game = new Game(this.player);

            this.SauvegarderPartie();

            this.RecupererEtAfficherEnnemis();

            this.game.Init(new Configurations.GameConfig(20, 20));

            Ennemi enemi = new Ennemi("voldemort", Console.WriteLine);
            enemi.Attaquer(this.player);
            enemi.Attaquer(this.player);

            int agePlayer = this.RecupereAgeValide();
            Console.WriteLine(agePlayer);

            DateOnly dateNaissance = RecupererEtAfficherDateNaissance();
            player.DateDeNaissance = dateNaissance;


            Console.WriteLine($"Le player a la date {player.DateDeNaissance}");

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
            var dataLayer = new GameDbDataLayer(this.connectionString);
            dataLayer.Ecrire(this.game);
        }

        private void RecupererEtAfficherEnnemis()
        {
            this.ennemies = new EnnemiDBDataLayer(this.connectionString).LireList();
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


        DateOnly RecupererEtAfficherDateNaissance()
        {
            Console.WriteLine("Quelle est ta date de naissance ?");
            string dateSaisie = Console.ReadLine();

            DateTime dateEtHeureNaissance = DateTime.Parse(dateSaisie);

            DateOnly dateNaissance = DateOnly.FromDateTime(dateEtHeureNaissance); // DateOnly.Parse(dateSaisie);

            Console.WriteLine("Tu as saisi " + dateNaissance);
            Console.WriteLine("Tu as saisi " + dateNaissance.ToString());

            return dateNaissance;
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

            player.ForceSelectionnee = forces[typeForce - 1];

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


        int RecupereAgeValide()
        {
            int agePlayer = DemandeEtRecupereAgeValid();

            AfficherInfoAuSujetAge(agePlayer);

            return agePlayer;
        }

        void AfficherInfoAuSujetAge(int agePlayer = 0)
        {
            if (agePlayer > 0)
            {
                Console.WriteLine("Yes, vous pouvez continuer la saisie !");

                if (agePlayer < 18)
                {
                    Console.WriteLine("Attention tu n'es pas majeur-e ...");
                }
                else if (agePlayer < 40)
                {
                    Console.WriteLine("Ca va tu n'es pas trop vieux ... !");
                }
                else
                {
                    Console.WriteLine("A priori, tu as au moins 40 ou plus ;)");
                }
            }
        }



        string RecupereSaisieAgeNonVide()
        {
            bool ageSaisiPasValide = true;
            string ageSaisie = "";
            do
            {
                Console.WriteLine("Ton âge s'il te plaît ?");
                ageSaisie = Console.ReadLine();

                ageSaisiPasValide = string.IsNullOrWhiteSpace(ageSaisie);

            } while (ageSaisiPasValide);

            return ageSaisie;
        }



        int DemandeEtRecupereAgeValid()
        {
            int ageLocalPlayer = -1;
            bool estAgeValid = false;

            while (!estAgeValid)
            {
                string ageSaisie = RecupereSaisieAgeNonVide();

                int.TryParse(ageSaisie, out ageLocalPlayer);

                //try
                //{
                //    agePlayer = int.Parse(ageSaisie); // int.MaxValue;
                //                                      // agePlayer = agePlayer + 10;
                //}
                //catch (FormatException ex)
                //{
                //    agePlayer = 0;
                //    throw new AgeNonValideException();
                //}
                //finally
                //{
                //    Console.WriteLine("Et oui c'est pas bien saisi");

                int ageMinimum = 12;

                int comparaison = ageLocalPlayer.CompareTo(ageMinimum);
                Console.WriteLine(comparaison);

                estAgeValid = comparaison >= 0;
            }
            //catch (FormatException ex) 
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}



            return ageLocalPlayer;
        }
        #endregion

        #region Properties
        public int Index { get => 1; }
        #endregion
    }
}
