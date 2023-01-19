using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecouverteEvenements
{
    internal class Worker
    {
        private Afficher afficher;
        public event Action<Tache> TacheFinie;

        public Worker(Afficher afficher)
        {
            this.afficher = afficher;
        }

        public void Travailler(Tache tache, Action<Tache> tacheEstFinie)
        {
            this.afficher($"{this.Prenom}, je travaille sur la tâche {tache.Titre}");

            tacheEstFinie?.Invoke(tache);
        }

        public void ExecuterTache(Tache tache)
        {
            this.afficher($"{this.Prenom}, je travaille sur la tâche {tache.Titre}");

            this.TacheFinie?.Invoke(tache);
        }



        public string Prenom { get; set; }
    }
}
