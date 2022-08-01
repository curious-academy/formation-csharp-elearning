// See https://aka.ms/new-console-template for more information


using System.Diagnostics;

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

#region MENU
// ---- AFFICHAGE MENU ------------

string format = "{0}. {1}";

// Formattage en une étape
string itemMenu = "nouvelle partie";
Console.WriteLine(format, 1, itemMenu.Substring(0, 1).ToUpper() + itemMenu.Substring(1).ToLower());

// Formattage en 2 étapes
//string itemMenu = "nouvelle partie";
//string resultatFormattage = string.Format(format, 1, itemMenu.Substring(0, 1).ToUpper() + itemMenu.Substring(1).ToLower());
//Console.WriteLine(resultatFormattage);

itemMenu = "charger une partie";
string resultatFormattage = $"{2}. {itemMenu.Substring(0, 1).ToUpper() + itemMenu.Substring(1).ToLower()}"; 
Console.WriteLine(resultatFormattage);

itemMenu = "crédits";
resultatFormattage = string.Format(format, 3, itemMenu.Substring(0, 1).ToUpper() + itemMenu.Substring(1).ToLower());
Console.WriteLine(resultatFormattage);

itemMenu = "quitter";
resultatFormattage = string.Format(format, 4, itemMenu.Substring(0, 1).ToUpper() + itemMenu.Substring(1).ToLower());
Console.WriteLine(resultatFormattage);

// Première étape avant formattage
//string itemMenu = "nouvelle partie";
//Console.WriteLine(1 + "." + itemMenu.Substring(0, 1).ToUpper() + itemMenu.Substring(1).ToLower());

//itemMenu = "charger une partie";
//Console.WriteLine(2 + "." + itemMenu.Substring(0, 1).ToUpper() + itemMenu.Substring(1).ToLower());
//itemMenu = "crédits";
//Console.WriteLine(3 + "." + itemMenu.Substring(0, 1).ToUpper() + itemMenu.Substring(1).ToLower());
//itemMenu = "quitter";
//Console.WriteLine(4 + "." + itemMenu.Substring(0, 1).ToUpper() + itemMenu.Substring(1).ToLower());


#endregion

#region PARTIE SAISIE INFORMATIONS JOUEUR / JOUEUSE
// ---- PARTIE SAISIE INFORMATIONS JOUEUR / JOUEUSE ------------
Console.WriteLine("Ton âge s'il te plaît ?");
string ageSaisie = Console.ReadLine();

if (string.IsNullOrWhiteSpace(ageSaisie)) //== true)
{
    Console.WriteLine("Âge obligatoire !");
    Environment.Exit(-1);
}


//if (! string.IsNullOrEmpty(ageSaisie)) //== true)
//{
//    Console.WriteLine("Age bien saisie");
//}
//else
//{
//    Console.WriteLine("Âge obligatoire !");
//    Environment.Exit(-1);
//}

int agePlayer = int.Parse(ageSaisie); // int.MaxValue;
// agePlayer = agePlayer + 10;

int ageMinimum = 12;

int comparaison = agePlayer.CompareTo(ageMinimum);
Console.WriteLine(comparaison);

bool estAgeValid = comparaison >= 0;

// 3° façon if
//if (! (comparaison >= 0))
//{
//    Console.WriteLine("Âge interdit !");
//    Environment.Exit(-1);
//}

// Une ligne sous le if
//if (!estAgeValid)
//    Environment.Exit(-1);

// 2° étape if
if (! estAgeValid)
{
    Console.WriteLine("Âge interdit !");
    Environment.Exit(-1);
}
else
{
    Console.WriteLine("Yes, vous pouvez continuer la saisie !");

    if (agePlayer < 18)
    {
        Console.WriteLine("Attention tu n'es pas majeur-e ...");
    }
    else if (agePlayer < 40)
    {
        Console.WriteLine("Ca va tu n'es pas trop vieux ... !");
    }
    else
    {
        Console.WriteLine("A priori, tu as au moins 40 ou plus ;)");
    }
}

// Premiere étape if
//bool verification = estAgeValid == false;
//if (verification)
//{
//    Console.WriteLine("Âge interdit !");
//    Environment.Exit(-1);
//}

//estAgeValid = estAgeValid || false;

// pour info : Console.WriteLine(int.MinValue);
// pour info : Console.WriteLine(int.MaxValue);


Console.WriteLine(agePlayer);
#endregion

#region ---- DATE DE NAISSANCE -----
Console.WriteLine("Quelle est ta date de naissance ?");
string dateSaisie = Console.ReadLine();

DateTime dateEtHeureNaissance = DateTime.Parse(dateSaisie);

DateOnly dateNaissance = DateOnly.FromDateTime(dateEtHeureNaissance); // DateOnly.Parse(dateSaisie);

// TimeOnly time = 



Console.WriteLine("Tu as saisi " + dateNaissance);
Console.WriteLine("Tu as saisi " + dateNaissance.ToString());
#endregion

#region ---- PREPARATION ARME -----
//decimal puissanceArme = 10;
float puissanceArme = 10;
puissanceArme = 15.6f;

Console.WriteLine(puissanceArme);

int valeurParDefaultPuissanceArme = 10;
// affectation sans cast : puissanceArme = valeurParDefaultPuissanceArme;

// force cast : int valeurPuissanceX = (int) puissanceArme;
#endregion




