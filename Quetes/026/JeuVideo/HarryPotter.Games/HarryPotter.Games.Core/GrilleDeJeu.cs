using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Games.Core
{
    /// <summary>
    /// Grille contenant une liste de cellules
    /// </summary>
    public class GrilleDeJeu : IList<Cellule>
    {
        #region Fields
        private List<Cellule> cellules = new List<Cellule>();
        #endregion

        #region Public methods
        public void Add(Cellule item)
        {           

            this.cellules.Add(item);
        }

        public void Clear()
        {
            this.cellules.Clear();
        }

        public bool Contains(Cellule item)
        {
            return this.cellules.Contains(item);
        }

        public void CopyTo(Cellule[] array, int arrayIndex)
        {
            this.cellules.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Cellule> GetEnumerator()
        {
            return this.cellules.GetEnumerator();
        }

        public int IndexOf(Cellule item)
        {
            return this.cellules.IndexOf(item);
        }

        public void Insert(int index, Cellule item)
        {
            this.cellules[index] = item;
        }

        public bool Remove(Cellule item)
        {
            return this.cellules.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this.cellules.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.cellules.GetEnumerator();
        }
        #endregion

        #region Properties
        public Cellule this[int index] { get => this.cellules[index]; set => this.cellules[index] = value; }

        public int Count => this.cellules.Count;

        public bool IsReadOnly => false;
        #endregion
    }
}
