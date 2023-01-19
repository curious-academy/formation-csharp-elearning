using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecouverteEvenements
{
    /// <summary>
    /// Contrat de méthode qui permet d'exécuter une méthode pour afficher une information
    /// </summary>
    /// <param name="message"></param>
    public delegate void Afficher(string message);
}
