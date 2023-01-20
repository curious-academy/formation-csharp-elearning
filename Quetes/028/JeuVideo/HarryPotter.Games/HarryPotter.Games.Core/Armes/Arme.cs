using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core.Armes
{
    public abstract class Arme
    {
        #region Properties
        public decimal Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Dommage { get; set; }

        public decimal Handicap { get; set; }
        #endregion

        #region Public methods
        public override string ToString()
        {
            return $"{this.Id}. {this.Name} (Dommage : {this.Dommage} / Handicap : {this.Handicap})";
        }
        #endregion
    }
}
