using HarryPotter.Games.Core.Menu.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Menu
{
    /// <summary>
    /// Menu de sélection du jeu
    /// </summary>
    public class Menu
    {
        #region Fields
        private readonly Player currentPlayer;
        private readonly List<ItemMenu> items = new List<ItemMenu>();
        private readonly List<IMenuCommand> commands = new List<IMenuCommand>();
        #endregion

        #region Constructors
        public Menu(Player player)
        {
            this.currentPlayer = player;
            this.commands.Add(new NouvellePartieMenuCommand(this.currentPlayer));
            this.commands.Add(new CreationProfilPlayerMenuCommand(this.currentPlayer));
            this.commands.Add(new AProposMenuCommand());
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Ajoute un item dans le menu
        /// </summary>
        /// <param name="newOne"></param>
        public void Add(ItemMenu newOne)
        {
            items.Add(newOne);
        }

        public ItemMenu Add(int id, string libelle)
        {
            // this.items.Add(new ItemMenu(id, libelle));
            ItemMenu item = new(id, libelle);
            items.Add(item);

            return item;
        }

        /// <summary>
        ///  Affiche l'ensemble des items du menu
        /// </summary>
        // public void Afficher(AfficherInformation afficher)
        public void Afficher(Action<object> afficher)
        {
            foreach (var item in items)
            {
                // Afficher un Item sur la sortie de l'exécutable (on ne sait pas lequel)
                // Console.WriteLine(item);
                afficher(item);
            }
        }

        /// <summary>
        /// Permet de proposer le choix sur le menu et de mettre à jour la propriété ChoixEnCours
        /// </summary>
        /// <param name="afficher"></param>
        /// <param name="recupereSaisie"></param>
        public void SaisirChoix(Action<object> afficher, Func<string?> recupereSaisie)
        {
            afficher("Quel est votre choix ?");
            string saisie = recupereSaisie();

            int menuIndex = int.Parse(saisie);

            ChoixEnCours = items.Where(item => item.Id == menuIndex).SingleOrDefault();

            IMenuCommand? commandAExecuter = null;

            commandAExecuter = this.commands.Where(commandEncours => commandEncours.Index == menuIndex)
                                            .SingleOrDefault();
            commandAExecuter?.Executer();
        }
        #endregion

        #region Properties
        public ItemMenu? ChoixEnCours { get; set; }

        public List<ItemMenu> Items { get => items; }
        #endregion
    }
}
