
using AsyncLoaders;

var length = await (new UrlLoader()).Load("https://learn.microsoft.com/fr-fr/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0");

Console.WriteLine("La taille du contenu web de page est : {0}", length);

Console.ReadLine();
