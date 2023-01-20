using HarryPotter.Games.Core.Armes;
using HarryPotter.Games.Core.Configurations;
using HarryPotter.Games.Core.DataLayers;
using HarryPotter.Games.Core.Forces;
using HarryPotter.Games.Core.Mapper;
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
        private List<Arme> armes = new();
        private List<Ennemi> ennemies;
        private Game game = null;
        private readonly Player currentPlayer;
        private readonly IMap map;
        private (Action<string> affichage, Func<string> lireSaisie) accessEntreeSortie;
        #endregion

        #region Constructors
        public NouvellePartieMenuCommand(Player player, EntreeSortie entreeSortie, IMap map)
        {
            this.map = map;
            this.accessEntreeSortie = entreeSortie.RecupererEntreeSortie();
            this.currentPlayer = player;
        }
        #endregion

        #region Public methods
        public void Executer()
        {
            this.forces = new List<Force>();
            this.game = new Game(this.currentPlayer, this.map);

            this.SauvegarderPartie();
            this.RecupererEtAfficherEnnemis();

            this.game.Init(new Configurations.GameConfig(20, 20));
            
            PreparerListeForces();
            AfficherForceSelectionnee();

            AfficherArmes();

            #region Lancement du jeu
            this.game.Start();
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
            this.armes.Clear();
            this.armes.Add(new BaguetteArme() {  Id = 1, Name = "Archnaf", Dommage = 50, Handicap = 0.5m});
            this.armes.Add(new BaguetteEnBoisArme() { Id = 2, Name = "Voldaril", Dommage = 100, Handicap = 10m });

            this.accessEntreeSortie.affichage("CHOIX ARME");
            foreach (var item in this.armes)
            {
                this.accessEntreeSortie.affichage(item.ToString());
            }        
            this.accessEntreeSortie.affichage("Choisis ton arme pour démarrer le jeu :");

            var resultChoixArme = this.accessEntreeSortie.lireSaisie();
            var query = from arme in this.armes
                        where arme.Id == int.Parse(resultChoixArme)
                        select arme;

            this.currentPlayer.Arme = query.SingleOrDefault();
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
            this.accessEntreeSortie.affichage("De quel côté de la force seras-tu ? ");
            //this.accessEntreeSortie.affichage("1. Du côté lumineux");
            //this.accessEntreeSortie.affichage("2. Du côté obscur");
            //this.accessEntreeSortie.affichage("3. Neutre, pas de force pour moi");

            foreach (var force in forces)
            {
                this.accessEntreeSortie.affichage(force.ToString());
            }
        }

        void AfficherForceSelectionnee()
        {
            int typeForce = AfficherForcesEtRetourneSelection();

            this.currentPlayer.ForceSelectionnee = forces[typeForce - 1];

            string messageAAfficher = this.GetMessageAfficherAutourSelectionForce((TypeForce) typeForce);
            this.accessEntreeSortie.affichage(messageAAfficher);
        }

        private string GetMessageAfficherAutourSelectionForce(TypeForce typeForce) => typeForce switch
        {
            TypeForce.Lumineuse => "Tu as choisi le côté lumineux",
            TypeForce.Obscur => "Tu as choisi le côté obscur",
            TypeForce.None => "Tu n'a pas de choix de force",
            _ => "Tu n'a rien choisi comme force"
        };        
        #endregion

        #region Properties
        public int Index { get => 1; }
        #endregion
    }
}
