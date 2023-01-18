using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecouverteEFCore
{
    // [Table("Ennemi")]
    internal class Ennemy
    {
        //[Key]
        //[Column("Prenom")]
        public string Surname { get; set; }

        public Arme Arme { get; set; }

        public int PointsDeVie { get; set; }
    }
}
