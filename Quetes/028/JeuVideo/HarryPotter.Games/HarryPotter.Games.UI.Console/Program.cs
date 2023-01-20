// See https://aka.ms/new-console-template for more information
using HarryPotter.Games.Core.DataLayers;
using HarryPotter.Games.Core.Interfaces.DataLayers;
using HarryPotter.Games.Core.Menu;
using HarryPotter.Games.UI.Console;
using System.Data.SqlClient;


#region A titre d'exemples

#region List génériques


List<Player> list;
#endregion

#region Polymorphisme
//Character ennemiB = new Ennemi("B");

Character playerA = new Player(Console.WriteLine);

//ennemiB.SeDeplacer();
//playerA.SeDeplacer();

//playerA.Attaquer(ennemiB);
//ennemiB.Attaquer(playerA);

#endregion

#region Init
//IDataLayer<Menu> dataLayer = new SerializationDataLayer<Menu>(@"F:\Tmps\Sauvegardes\Test\Formation online\sauvegarde.xml");
//try
//{
//    var menuTest = new Menu(null);
//    menuTest.Add(new ItemMenu(1, "Test menu 1"));
//    menuTest.Add(new ItemMenu(2, "Test menu 2"));

//    dataLayer.Ecrire(menuTest);

//    var @object = dataLayer.Lire(typeof(Menu));   
//}
//catch (FileNotFoundException ex)
//{
//    Console.WriteLine("Fichier non présent");
//}

//List<Force> forces2 = new List<Force>()
//{
//    new LumineuseForce(),
//    new LumineuseForce()
//};

// Exemple d'utilisation avec la serialisation XML
// IDataLayer<List<Force>> dataLayer2 = new SerializationDataLayer<List<Force>>(@"F:\Tmps\Sauvegardes\Test\Formation online\forces.xml");

// Exemple d'utilisation avec la serialisation Json
//IDataLayer<List<Force>> dataLayer2 = new JsonDataLayer<List<Force>>(@"F:\Tmps\Sauvegardes\Test\Formation online\forces.json");
//dataLayer2.Ecrire(forces2);

#endregion
#endregion


//string surname = null;

//surname.ToLower();


string titre = "Harry Potter game";
titre = "Un jeu épique !";

string sousTitre = "Harry Potter";

string temporaire = titre;
titre = sousTitre;
sousTitre = temporaire;


// Ca nous sert à ecrire dans le ouput
// 27/02/2022: Debug.WriteLine("==> Je teste" + titre);

// Des informations d'explications plus claires !

string titreEnMajuscule = titre.ToUpper();
Console.WriteLine(titreEnMajuscule);

Console.WriteLine(sousTitre.Substring(0, sousTitre.Length - 2));

// Console.WriteLine(sousTitre.Replace(" !", ""));

#region Variables globales
Player currentPlayer = new Player(Console.WriteLine);
Menu menu = new(currentPlayer);

menu.Add(0, "Créer profil du joueur / de la joueuse");
menu.Add(1, "Nouvelle partie");
menu.Add(2, "Charger partie");
menu.Add(new ItemMenu(3, "Crédits"));
menu.Add(new (4, "Quitter"));
#endregion


#region Framework du projet
void AfficherItemMenu(string itemMenu, int indexMenu = 1)
{
    string format = "{0}. {1}";

    string resultatFormattage = string.Format(format, indexMenu, itemMenu.Substring(0, 1).ToUpper() + itemMenu.Substring(1).ToLower());
    Console.WriteLine(resultatFormattage);
}

int[,] PrepareGrilleDuJeu()
{
    //int positionJoueur = 1;

    int[] positions = new int[10];

    //var position = positions[5];
    //Console.WriteLine(position);

    //bool[] etats = new bool[5];
    //Console.WriteLine(etats[2]);

    //string[] noms = new string[4];
    //Console.WriteLine(etats[2]);

    #region Approche matricielle
    int[,] grilleDeJeu = new int[20, 20];
    const int AUCUN_PERSO = -1;

    for (int i = 0; i < grilleDeJeu.GetLength(0); i++)
    {
        for (int j = 0; j < grilleDeJeu.GetLength(1); j++)
        {
            grilleDeJeu[i, j] = AUCUN_PERSO;
        }
    }
    #endregion

    return grilleDeJeu;
}

void AfficherMenu()
{
    Action<object> methodeAExecuter = AfficherEnBleu;

    // menu.Afficher(methodeAExecuter);
    // menu.Afficher(AfficherEnBleu);

    var afficherEnVert = (object value) =>
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;

        Console.WriteLine(value);

        Console.ForegroundColor = ConsoleColor.White;
    };

    menu.Afficher(afficherEnVert);

    // menu.Afficher(value => Console.WriteLine(value));
}

void SaisirChoixMenu()
{
    try
    {
        menu.SaisirChoix(Console.WriteLine, Console.ReadLine);
    }
    catch (SqlException ex) when (ex.Message.StartsWith("Une erreur arrivée"))
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Un problème d'accès à la base de données a eu lieu.");
        Console.ForegroundColor = ConsoleColor.White;
    }
    catch (SqlException ex)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Un problème d'accès à la base de données a eu lieu.");
        Console.ForegroundColor = ConsoleColor.White;
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Une erreur (quelconque) est apparue");
        Console.ForegroundColor = ConsoleColor.White;
    }

}

void AfficherEnBleu(object value)
{
    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.WriteLine(value);

    Console.ForegroundColor = ConsoleColor.White;
}

#endregion

#region Initialiation Moteur de jeu
#region Approche Tableau de tableau
//int[][][] grilleDeJeu = new int[20][][];

//for (int i = 0; i < 20; i++)
//{
//    grilleDeJeu[i] = new int[20][];
//    for (int j = 0; j < 20; j++)
//    {
//        grilleDeJeu[i][j] = new int[20];

//    }
//}
#endregion

// HarryPotter.Games.Core.Player player = new HarryPotter.Games.Core.Player("yoda");
int[,] grille;

void InitDonneesJeu()
{
    grille = PrepareGrilleDuJeu();
}
InitDonneesJeu();
#endregion

AfficherMenu();
SaisirChoixMenu();








