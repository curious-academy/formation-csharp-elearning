using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core
{
    /// <summary>
    /// Représente une cellule de jeu
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="characters"></param>
    public class Cellule
    {
        #region Constructors
        public Cellule(int x, int y, List<Character>? characters = null) 
        { 
            this.X= x; 
            this.Y = y; 
            this.Characters = characters;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Return true si pas null et si Nb elements > 0
        /// </summary>
        /// <returns></returns>
        public bool AAuMoinsUnPersonnage()
        {
            return this.AAuMoinsNPersonnages();
        }

        public bool AAuMoinsNPersonnages(int minimum = 0)
        {
            return this.Characters != null && this.Characters.Count > minimum;
        }

        public bool DetientPersonnage(Character character)
        {
            bool detenir = false;

            if (this.AAuMoinsUnPersonnage())
            {
                detenir = this.Characters.Any(item => item.Equals(character));
            }

            return detenir;
        }

        public bool ABonneCoordonnees(int x, int y)
        {
            return this.X == x && this.Y == y;
        }

        public static bool operator ==(Cellule cell1, Cellule cell2)
        {
            return cell1.X == cell2.X && cell1.Y == cell2.Y;
        }

        public static bool operator !=(Cellule cell1, Cellule cell2)
        {
            return cell1.X != cell2.X || cell1.Y != cell2.Y;
        }
        #endregion

        #region Properties
        public int X { get; init; }
        public int Y { get; init; }
        public List<Character>? Characters { get; init; }
        #endregion
    }

    // public record Cellule(int X, int Y, List<Character>? Characters = null);


}
