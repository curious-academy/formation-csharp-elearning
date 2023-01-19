using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecouverteEFCore
{
    // [Table("Arme")]
    internal class Arme
    {
        #region Properties
        public decimal Id { get; set; }

        public string Libelle { get; set; } = string.Empty;

        public decimal Dommages { get; set; } = 10;

        public string Pouvoir { get; set; } = string.Empty; 
        #endregion
    }
}
