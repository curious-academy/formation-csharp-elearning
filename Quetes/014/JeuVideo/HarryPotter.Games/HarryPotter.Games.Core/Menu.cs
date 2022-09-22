using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core
{
    /// <summary>
    /// Menu de sélection du jeu
    /// </summary>
    public class Menu
    {
        private readonly List<ItemMenu> items = new List<ItemMenu>();

        /// <summary>
        /// Ajoute un item dans le menu
        /// </summary>
        /// <param name="newOne"></param>
        public void Add(ItemMenu newOne)
        {
            this.items.Add(newOne); 
        }

        public ItemMenu Add(int id, string libelle)
        {
            // this.items.Add(new ItemMenu(id, libelle));
            ItemMenu item = new(id, libelle);
            this.items.Add(item);

            return item;
        }

        /// <summary>
        ///  Affiche l'ensemble des items du menu
        /// </summary>
        public void Afficher()
        {
            foreach (var item in this.items)
            {
                // Console.WriteLine($"{item.Id}. {item.Libelle}");
                // Console.WriteLine(item.ToString());
                Console.WriteLine(item);
            }
        }
    }
}
