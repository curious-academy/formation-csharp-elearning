using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Menu.Commands
{
    internal class CreationProfilPlayerMenuCommand : IMenuCommand
    {
        #region Properties
        public int Index => 0;
        #endregion

        #region Fields
        private readonly Player currentPlayer;
        #endregion

        #region Constructors
        public CreationProfilPlayerMenuCommand(Player player)
        {
            this.currentPlayer = player;
        }
        #endregion

        #region Public methods
        public void Executer()
        {
            int agePlayer = this.RecupereAgeValide();
            Console.WriteLine(agePlayer);

            DateOnly dateNaissance = RecupererEtAfficherDateNaissance();
            this.currentPlayer.DateDeNaissance = dateNaissance;

            Console.WriteLine($"Le player a la date {this.currentPlayer.DateDeNaissance}");
        }
        #endregion

        #region Internal methods
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
    }
}
