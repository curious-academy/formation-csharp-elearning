

using DecouverteEvenements;



Tache tache = new()
{
     Id= 1,
     Duree = 2,
     Titre = "Coder une fonction de calcul"
};

void AfficherTacheFinie(Tache tache)
{
    Console.WriteLine(string.Format("Travail finie pour la tache : {0}", tache.Titre));
}

Boss boss = new Boss();
Worker travailleur = new(Console.WriteLine);
Worker travailleurSecond = new Worker(Console.WriteLine);

//travailleur.Travailler(tache, AfficherTacheFinie);

travailleur.TacheFinie += AfficherTacheFinie;
travailleur.TacheFinie += travailleurSecond.ExecuterTache;

travailleur.TacheFinie += boss.NoterFinDeTache;
travailleurSecond.TacheFinie += boss.NoterFinDeTache;

// travailleur.TacheFinie += AfficherTacheFinie;
// travailleur.TacheFinie -= AfficherTacheFinie;

travailleur.ExecuterTache(tache);

travailleur.TacheFinie -= AfficherTacheFinie;
travailleur.TacheFinie -= travailleurSecond.ExecuterTache;

travailleur.TacheFinie -= boss.NoterFinDeTache;
travailleurSecond.TacheFinie -= boss.NoterFinDeTache;
// travailleur.TacheFinie -= AfficherTacheFinie;
