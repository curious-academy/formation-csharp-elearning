using HarryPotter.Games.Core.Configurations;
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
        private readonly EntreeSortie entreeSortie;
        private (Action<string> affichage, Func<string> lireSaisie) accessEntreeSortie;
        #endregion

        #region Constructors
        public CreationProfilPlayerMenuCommand(Player player, EntreeSortie entreeSortie)
        {
            this.accessEntreeSortie = entreeSortie.RecupererEntreeSortie();
            this.currentPlayer = player;
        }
        #endregion

        #region Public methods
        public void Executer()
        {
            int agePlayer = this.RecupereAgeValide();
            this.accessEntreeSortie.affichage(agePlayer.ToString());

            DateOnly dateNaissance = RecupererEtAfficherDateNaissance();
            this.currentPlayer.DateDeNaissance = dateNaissance;

            this.accessEntreeSortie.affichage($"Le player a la date {this.currentPlayer.DateDeNaissance}");
        }
        #endregion

        #region Internal methods
        DateOnly RecupererEtAfficherDateNaissance()
        {
            this.accessEntreeSortie.affichage("Quelle est ta date de naissance ?");
            string dateSaisie = this.accessEntreeSortie.lireSaisie();

            DateTime dateEtHeureNaissance = DateTime.Parse(dateSaisie);

            DateOnly dateNaissance = DateOnly.FromDateTime(dateEtHeureNaissance); // DateOnly.Parse(dateSaisie);

            this.accessEntreeSortie.affichage("Tu as saisi " + dateNaissance);
            this.accessEntreeSortie.affichage("Tu as saisi " + dateNaissance.ToString());

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
                this.accessEntreeSortie.affichage("Yes, vous pouvez continuer la saisie !");

                if (agePlayer < 18)
                {
                    this.accessEntreeSortie.affichage("Attention tu n'es pas majeur-e ...");
                }
                else if (agePlayer < 40)
                {
                    this.accessEntreeSortie.affichage("Ca va tu n'es pas trop vieux ... !");
                }
                else
                {
                    this.accessEntreeSortie.affichage("A priori, tu as au moins 40 ou plus ;)");
                }
            }
        }

        string RecupereSaisieAgeNonVide()
        {
            bool ageSaisiPasValide = true;
            string ageSaisie = "";
            do
            {
                this.accessEntreeSortie.affichage("Ton âge s'il te plaît ?");
                ageSaisie = this.accessEntreeSortie.lireSaisie();

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
                //    this.accessEntreeSortie.affichage("Et oui c'est pas bien saisi");

                int ageMinimum = 12;

                int comparaison = ageLocalPlayer.CompareTo(ageMinimum);
                this.accessEntreeSortie.affichage(comparaison.ToString());

                estAgeValid = comparaison >= 0;
            }
            //catch (FormatException ex) 
            //{
            //    this.accessEntreeSortie.affichage(ex.Message);
            //    throw;
            //}



            return ageLocalPlayer;
        }
        #endregion
    }
}
