using DecouverteLinq;
using DecouverteLinq.Extensions;
// using DecouverteLinq.Extensions;

//List<int> compteurs = new()
//{
//    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13
//};

//int[] compteurs2 = new []
//{
//    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13
//};


//var listTest = compteurs.Where(compteur => compteur <= 10).Select(item => item);

//// En deux temps, tois mouvements
//var queryExtensionUn = compteurs.Where(compteur => compteur <= 10);
//if (true)
//{
//    queryExtensionUn = queryExtensionUn.Where(item => item > 2);
//    queryExtensionUn = queryExtensionUn.Select(item => item);
//}

//var query = from compteur in compteurs
//            where compteur <= 10
//            select compteur;

//foreach (var item in query) // c'est exécuté ici, pas quand on crée la query !
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine("-------------------------------------------");

//var query2 = from compteur in query
//             where compteur < 5
//             orderby compteur descending
//             select compteur;

//foreach (var item in query2) // c'est exécuté ici, pas quand on crée la query ! yield
//{
//    Console.WriteLine(item);
//}

//var list = query2.ToList();
//var first = query2.First();
//var last = query2.Last();
//var max = query2.Max();
//var min = query2.Min();
//var sum = query2.Sum();
//var elements = query2.SkipLast(2);
//elements = query2.Take(2);

//Func<int, int> maFonction = item => item * 10;
//var result = maFonction(10);

//elements = query2.TakeWhile(item => item % 2 == 0);
//foreach (var item in elements)
//{
//    Console.WriteLine(item);
//}

#region Méthodes d'extension
//Wizard harry = new Wizard();
//Wizard voldemort = new();

//harry.Attaquer(voldemort);
//// MethodesExtensions.Defendre(voldemort, harry);
//voldemort.Defendre(harry);
#endregion

#region Linq avec list d'objets
List<Wizard> wizards = new()
{
    new() { IsDark = true, Prenom = "Tom Jedusor", PointsDeVie = 200, BaguetteId = -1 },
    new() { IsDark = false, Prenom = "Harry Potter", PointsDeVie = 100, BaguetteId = 1 },
    new() { IsDark = false, Prenom = "Harmony Gringer", PointsDeVie = 150, BaguetteId = 2 },
    new() { IsDark = true, Prenom = "Draco Malfoy", PointsDeVie = 150, BaguetteId = 3 },
};

List<BaguetteMagique> baguettes = new List<BaguetteMagique>()
{
    new () { Id = 1, Libelle = "Baguette 1" },
    new () { Id = 2, Libelle = "Baguette 2" },
    new () { Id = 3, Libelle = "Baguette 3" }
};


var queryPlusDinfosSurLesWizards = from wizard in wizards
                                   join baguette in baguettes on wizard.BaguetteId equals baguette.Id
                                   select new { Wizard = wizard, Baguette = baguette };

foreach (var item in queryPlusDinfosSurLesWizards)
{
    item.Wizard.MaBaguette = item.Baguette;
    Console.WriteLine($"{item.Wizard.Prenom} a comme baguette : {item.Baguette.Libelle}");
}


var queryNonMalefiques = from wizard in wizards
                         let prenomNom = wizard.Prenom.Split(' ')
                         let prenomMajuscule = prenomNom[0].ToUpper()
                         where ! wizard.IsDark && prenomNom.Length > 1
                         orderby prenomNom[1]
                         select new { Prenom = prenomNom[0], Nom = prenomNom[1], PointsDeVie = wizard.PointsDeVie};

foreach (var item in queryNonMalefiques)
{
    Console.WriteLine($"{item.Prenom}:{item.Nom} -> {item.PointsDeVie}");
}

//var queryNonMalefiquesGetPointsDeVie = from wizard in wizards
//                                       where !wizard.IsDark
//                                       select new { PointsVie = wizard.PointsDeVie };

//foreach (var item in queryNonMalefiquesGetPointsDeVie)
//{
//    Console.WriteLine($"{item.PointsVie}");
//}

//var queryNonMalefiquesGetPointsDeVie = from wizard in wizards
//                                       where !wizard.IsDark
//                                       select wizard.PointsDeVie;

var queryNonMalefiquesGetPointsDeVie = wizards.Where(wizard => ! wizard.IsDark)
                                              .Select(wizard => wizard.PointsDeVie);

foreach (var item in queryNonMalefiquesGetPointsDeVie)
{
    Console.WriteLine($"{item}");
}


Console.WriteLine($"Le total des points de vie des êtres non maléfiques est de : {queryNonMalefiquesGetPointsDeVie.Sum()}");
#endregion

#region Découverte record
//var piece = new PieceMonnaie() { Value = 1 };
//var piece2 = new PieceMonnaie() { Value = 1 };
//var piece3 = new PieceMonnaie() { Value = 10 };

var piece = new PieceMonnaie(1);
var piece2 = new PieceMonnaie(1);
var piece3 = new PieceMonnaie(10);

bool identique = piece == piece2;

Console.WriteLine(identique);
#endregion

#region Découverte yield
//List<int> GetList()
//{
//    return new List<int>()
//    {
//        1, 2, 3
//    };
//}

//int GetIntList()
//{
//    return 1;
//    return 2; 
//}

IEnumerable<int> GetList()
{
    yield return 1;
    yield return 2;
    yield return 3;

    Console.WriteLine("Avant le dernier yield return");

    yield return 10;
}

var queryYield = from item in GetList()
                 where item > 1 
                 select item;

foreach (var item in queryYield)
{
    Console.WriteLine(item);
}

//foreach (var item in GetList())
//{
//    Console.WriteLine(item);
//}
#endregion