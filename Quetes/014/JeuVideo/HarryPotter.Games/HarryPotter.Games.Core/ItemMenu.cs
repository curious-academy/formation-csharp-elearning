using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core
{
    public class ItemMenu
    {
        #region Constructors
        public ItemMenu(int id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }
        #endregion

        #region Public methods
        public override string ToString()
        {
            return $"{this.Id}. {this.Libelle}";
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Libelle { get; set; } = string.Empty;
        #endregion
    }
}
